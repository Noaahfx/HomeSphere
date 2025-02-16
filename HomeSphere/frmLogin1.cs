using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Oauth2.v2;
using Google.Apis.Oauth2.v2.Data;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;

namespace HomeSphere
{
    public partial class frmLogin1 : Form
    {
        
        private string strConnectionString =
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public frmLogin1()
        {
            InitializeComponent();
            InitializePlaceholders();
        }
        private void InitializePlaceholders()
        {
            SetPlaceholder(tbUsername, "Enter your username");
            SetPlaceholder(tbPassword, "Enter your password");

            tbUsername.GotFocus += RemovePlaceholder;
            tbUsername.LostFocus += AddPlaceholder;

            tbPassword.GotFocus += RemovePlaceholder;
            tbPassword.LostFocus += AddPlaceholder;
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = System.Drawing.Color.Gray;
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.ForeColor == System.Drawing.Color.Gray)
            {
                textBox.Text = "";
                textBox.ForeColor = System.Drawing.Color.Black;
                if (textBox == tbPassword)
                {
                    textBox.UseSystemPasswordChar = true;
                }
            }
        }

        private void AddPlaceholder(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox == tbUsername)
                    SetPlaceholder(textBox, "Enter your username");
                else if (textBox == tbPassword)
                    SetPlaceholder(textBox, "Enter your password");

                textBox.UseSystemPasswordChar = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Clear the text in the email and password fields
            tbUsername.Text = string.Empty;
            tbPassword.Text = string.Empty;

            // Optionally, set focus back to the first field
            tbUsername.Focus();
        }

        /// <summary>
        /// Remove potentially dangerous characters like '<' or '>'
        /// to reduce the risk of naive HTML/JS injection.
        /// </summary>
        private string SanitizeInput(string input)
        {
            return input.Replace("<", string.Empty)
                        .Replace(">", string.Empty);
        }

        /// <summary>
        /// Regex-based check for password complexity:
        /// - 8 to 50 characters
        /// - Must include a letter, a digit, and a special character from a defined set
        /// </summary>
        private bool IsPasswordComplex(string password)
        {
            // Adjust the special characters set to your needs:
            //  - Must have at least 1 letter, 1 digit, 1 special char from the set
            //  - Overall length must be between 8 and 50
            string pattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?])" +
                             @"[A-Za-z\d!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]{8,50}$";

            return Regex.IsMatch(password, pattern);
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            int userId = -1;
            string email = string.Empty;
            errorProvider1.SetError(tbUsername, "");
            errorProvider1.SetError(tbPassword, "");

            string username = SanitizeInput(tbUsername.Text.Trim());
            string password = SanitizeInput(tbPassword.Text.Trim());
            string deviceIdentifier = GetDeviceIdentifier();
            bool rememberDevice = cbRememberDevice.Checked; // ✅ Ensure checkbox value is retrieved

            if (string.IsNullOrWhiteSpace(username))
            {
                errorProvider1.SetError(tbUsername, "Username is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                errorProvider1.SetError(tbPassword, "Password is required.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(strConnectionString))
                {
                    conn.Open();
                    string query = "SELECT ID, PasswordHash, Email, ISNULL(MFAType, 'None') AS MFAType, IsVerified FROM Users WHERE Username = @Username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userId = Convert.ToInt32(reader["ID"]);  // ✅ Correct: Assign value instead of redeclaring
                                email = reader["Email"].ToString();      // ✅ Correct: Assign value instead of redeclaring
                                string storedPasswordHash = reader["PasswordHash"].ToString();
                                string mfaType = reader["MFAType"].ToString().Trim().ToLower();
                                int isVerified = Convert.ToInt32(reader["IsVerified"]); // Check verification status

                                if (!BCrypt.Net.BCrypt.Verify(password, storedPasswordHash))
                                {
                                    MessageBox.Show("Incorrect password.");
                                    return;
                                }

                                if (isVerified == 0)
                                {
                                    string verificationCode = new Random().Next(100000, 999999).ToString();
                                    DateTime expiryTime = DateTime.Now.AddMinutes(5);

                                    using (SqlConnection updateConn = new SqlConnection(strConnectionString))
                                    {
                                        updateConn.Open();
                                        string updateQuery = "UPDATE Users SET VerificationCode = @OTP, VerificationCodeExpiryTime = @ExpiryTime WHERE Email = @Email";

                                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, updateConn))
                                        {
                                            updateCmd.Parameters.AddWithValue("@OTP", verificationCode);
                                            updateCmd.Parameters.AddWithValue("@ExpiryTime", expiryTime);
                                            updateCmd.Parameters.AddWithValue("@Email", email);
                                            updateCmd.ExecuteNonQuery();
                                        }
                                    }

                                    MessageBox.Show("Your account is not verified. An OTP has been sent to your email. Please verify before logging in.", "Verification Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    SendOTPEmail(email, verificationCode);
                                    

                                    this.Hide();
                                    frmEmailVerification verifyForm = new frmEmailVerification(email);
                                    verifyForm.Show();
                                    return;
                                }


                                // ✅ Check if device is already saved (bypass 2FA)
                                if (IsDeviceSaved(userId, deviceIdentifier))
                                {
                                    MessageBox.Show("Device recognized. Bypassing 2FA and/or Login Alerts.");
                                    Program.CurrentUserId = userId;
                                    this.Hide();
                                    frmUserHomePage homePage = new frmUserHomePage(userId);
                                    homePage.Show();
                                    return;
                                }

                                // ✅ If device is NOT saved, enforce 2FA if enabled
                                if (mfaType.Contains("email"))
                                {
                                    MessageBox.Show("Redirecting to OTP Page...");
                                    this.Hide();
                                    frmVerifyOTP otpForm = new frmVerifyOTP(userId, email, rememberDevice); // ✅ Pass the missing argument
                                    otpForm.Show();
                                    return;
                                }

                                // ✅ Send login alert only if the device is NOT already saved
                                if (!IsDeviceSaved(userId, deviceIdentifier))
                                {
                                    SendLoginNotification(email, deviceIdentifier);

                                    // ✅ Only save the device if "Remember This Device" is checked
                                    if (rememberDevice)
                                    {
                                        SaveDevice(userId, deviceIdentifier);
                                    }
                                }

                                Program.CurrentUserId = userId;
                                this.Hide();
                                frmUserHomePage homePage2 = new frmUserHomePage(userId);
                                homePage2.Show();
                            }
                            else
                            {
                                MessageBox.Show("Login Failed! Username not found.");
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendOTPEmail(string email, string otp)
        {
            try
            {
                // Create email message
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("smarthomesystemsapplication@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Your OTP Code from Smart Home System";
                mail.Body = $@"
                <html>
                <head>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            color: #333;
                        }}
                        .container {{
                            max-width: 600px;
                            margin: 0 auto;
                            padding: 20px;
                            border: 1px solid #ddd;
                            border-radius: 8px;
                            background-color: #f9f9f9;
                        }}
                        .header {{
                            font-size: 24px;
                            font-weight: bold;
                            color: #007bff;
                            text-align: center;
                            margin-bottom: 20px;
                        }}
                        .otp-code {{
                            font-size: 22px;
                            font-weight: bold;
                            color: #28a745;
                            text-align: center;
                            margin: 20px 0;
                            padding: 10px;
                            border: 2px dashed #28a745;
                            display: inline-block;
                        }}
                        .footer {{
                            font-size: 12px;
                            text-align: center;
                            color: #555;
                            margin-top: 20px;
                        }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>Smart Home System - OTP Verification</div>
                        <p>Hello,</p>
                        <p>Your One-Time Password (OTP) for login is:</p>
                        <div class='otp-code'>{otp}</div>
                        <p>This code is valid for <b>5 minutes</b>. Please do not share it with anyone.</p>
                        <p>If you did not request this OTP, please ignore this email.</p>
                        <div class='footer'>
                            Need help? Contact <a href='mailto:support@smarthomesystem.com'>support@smarthomesystem.com</a>.
                        </div>
                    </div>
                </body>
                </html>";
                mail.IsBodyHtml = true;


                // Configure SMTP client
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("smarthomesystemsapplication@gmail.com", "dfwn lflx wmba cwfz"),
                    EnableSsl = true
                };

                // Send email
                smtpClient.Send(mail);
                MessageBox.Show($"OTP sent to {email}. Please check your inbox.", "OTP Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending OTP: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsDeviceSaved(int userId, string deviceIdentifier)
        {
            using (SqlConnection conn = new SqlConnection(strConnectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(1) FROM Devices WHERE UserID = @UserID AND DeviceIdentifier = @DeviceIdentifier";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@DeviceIdentifier", deviceIdentifier);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private void SaveDevice(int userId, string deviceIdentifier)
        {
            using (SqlConnection conn = new SqlConnection(strConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO Devices (UserID, DeviceIdentifier) VALUES (@UserID, @DeviceIdentifier)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@DeviceIdentifier", deviceIdentifier);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void SendLoginNotification(string email, string deviceIdentifier)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("smarthomesystemsapplication@gmail.com");
                mail.To.Add(email);
                mail.Subject = "New Device Login Alert - Smart Home System";
                mail.Body = $@"
        <html>
        <head>
            <style>
                body {{
                    font-family: Arial, sans-serif;
                    color: #333;
                }}
                .container {{
                    max-width: 600px;
                    margin: 0 auto;
                    padding: 20px;
                    border: 1px solid #ddd;
                    border-radius: 8px;
                    background-color: #f9f9f9;
                }}
                .header {{
                    font-size: 24px;
                    font-weight: bold;
                    color: #FF5722;
                    text-align: center;
                    margin-bottom: 20px;
                }}
                .device-info {{
                    font-size: 16px;
                    font-weight: bold;
                    color: #333;
                    text-align: center;
                    margin: 10px 0;
                    padding: 10px;
                    border: 2px dashed #FF5722;
                    display: inline-block;
                }}
                .footer {{
                    font-size: 12px;
                    text-align: center;
                    color: #555;
                    margin-top: 20px;
                }}
            </style>
        </head>
        <body>
            <div class='container'>
                <div class='header'>New Device Login Alert</div>
                <p>Hello,</p>
                <p>A login attempt was detected from the following device:</p>
                <div class='device-info'>{deviceIdentifier}</div>
                <p><b>Date & Time:</b> {DateTime.Now.ToString("f")}</p>
                <p>If this was you, no further action is needed. If this was not you, please secure your account immediately.</p>
                <div class='footer'>
                    Need help? Contact <a href='mailto:support@smarthomesystem.com'>support@smarthomesystem.com</a>.
                </div>
            </div>
        </body>
        </html>";
                mail.IsBodyHtml = true;

                // Configure SMTP Client
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("smarthomesystemsapplication@gmail.com", "dfwn lflx wmba cwfz"),
                    EnableSsl = true
                };

                smtpClient.Send(mail);
                MessageBox.Show($"Login alert sent to {email}.", "Notification Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending login alert: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetDeviceIdentifier()
        {
            return $"{Environment.MachineName}-{Program.SessionId}";
        }




        private void label1_Click(object sender, EventArgs e)
        {
            // Typically no action needed
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Typically no action needed
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = !tbPassword.UseSystemPasswordChar;

            // Change the button text or image for visual feedback
          
        }

        private void button1_Click(object sender, EventArgs e)

        {
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void SignUpUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserSignUp signUpForm = new UserSignUp();
            signUpForm.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmForgotPassword forgotPasswordForm = new frmForgotPassword();
            forgotPasswordForm.Show();
            this.Hide();
        }

        private async void btnGoogleLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string[] scopes = { "https://www.googleapis.com/auth/userinfo.profile", "https://www.googleapis.com/auth/userinfo.email" };
                string credentialPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "client_secret.json");

                // ✅ Step 1: Clear previous token (forces Google Sign-In prompt)
                string tokenPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GoogleOAuthToken");
                if (Directory.Exists(tokenPath))
                {
                    Directory.Delete(tokenPath, true); // Deletes saved credentials
                }

                using (var stream = new FileStream(credentialPath, FileMode.Open, FileAccess.Read))
                {
                    var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(tokenPath, false) // ✅ Prevents saving credentials
                    );

                    var oauthService = new Oauth2Service(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "Smart Home System"
                    });

                    // ✅ Get User Information
                    Userinfo userInfo = await oauthService.Userinfo.Get().ExecuteAsync();
                    string googleEmail = userInfo.Email;
                    string googleName = userInfo.Name;

                    MessageBox.Show($"Login Successful!\n\nWelcome {googleName}\nEmail: {googleEmail}", "Google Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // ✅ Redirect Logic (Check If User Exists or Needs Setup)
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                    {
                        conn.Open();
                        string query = "SELECT ID FROM Users WHERE Email = @Email";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Email", googleEmail);
                            var result = cmd.ExecuteScalar();

                            if (result != null)
                            {
                                int userId = Convert.ToInt32(result);

                                // ✅ Check MFAType for Google Login
                                string mfaType = "None";
                                using (SqlCommand cmd2 = new SqlCommand("SELECT ISNULL(MFAType, 'None') AS MFAType FROM Users WHERE ID = @UserID", conn))
                                {
                                    cmd2.Parameters.AddWithValue("@UserID", userId);
                                    object mfaResult = cmd2.ExecuteScalar();
                                    if (mfaResult != null)
                                    {
                                        mfaType = mfaResult.ToString().Trim().ToLower();
                                    }
                                }

                                MessageBox.Show($"MFAType for Google User: {mfaType}", "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // ✅ Check if the device is already saved (bypass 2FA & no alerts)
                                string deviceIdentifier = GetDeviceIdentifier();
                                bool rememberDevice = cbRememberDevice.Checked;

                                if (IsDeviceSaved(userId, deviceIdentifier))
                                {
                                    MessageBox.Show("Device recognized. Bypassing 2FA and/or Login Alerts.");
                                    this.Hide();
                                    frmUserHomePage userHomePage = new frmUserHomePage(userId);
                                    userHomePage.Show();
                                    return;
                                }

                                // ✅ If the device is new, enforce 2FA if enabled
                                if (mfaType.Contains("email"))
                                {
                                    MessageBox.Show("Redirecting to OTP Page...");
                                    this.Hide();
                                    frmVerifyOTP otpForm = new frmVerifyOTP(userId, googleEmail, rememberDevice);
                                    otpForm.Show();
                                    return;
                                }

                                // ✅ Send login alert for new devices (even if "Remember Device" is NOT checked)
                                SendLoginNotification(googleEmail, deviceIdentifier);

                                // ✅ Only save device if "Remember Device" is checked
                                if (rememberDevice)
                                {
                                    SaveDevice(userId, deviceIdentifier);
                                }

                                // ✅ Redirect to home page
                                this.Hide();
                                frmUserHomePage homePage = new frmUserHomePage(userId);
                                homePage.FormClosed += (s, args) => this.Show();
                                homePage.Show();
                            }
                            else
                            {
                                this.Hide();
                                frmCompleteAccountSetup setupForm = new frmCompleteAccountSetup(googleEmail, googleName);
                                setupForm.Show();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Google Login Failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void lnkLoginAsAdmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAdminLogin adminLoginForm = new frmAdminLogin();
            adminLoginForm.Show();
            this.Hide();
        }
    }
}