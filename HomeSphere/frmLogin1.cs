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
             // Ensures password is hidden by default

            InitializeComponent();
            
        }

       

      
        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit the application?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Shut down the application
            }
        }

        /// <summary>
        /// Sanitizes input based on whether the input is a password or not.
        /// For non-password fields (e.g. usernames or emails), only allow alphanumeric characters,
        /// underscore, dash, dot, and the '@' symbol.
        /// For passwords, only remove characters that might lead to HTML injection.
        /// </summary>
        private string SanitizeInput(string input, bool isPassword = false)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // Trim any leading/trailing whitespace
            input = input.Trim();

            if (!isPassword)
            {
                // For usernames/emails: allow letters, digits, underscore, dash, dot, and @.
                return Regex.Replace(input, @"[^\w\-.@]", "");
            }
            else
            {
                // For passwords: remove characters that could be interpreted as HTML.
                return input.Replace("<", string.Empty).Replace(">", string.Empty);
            }
        }

        /// <summary>
        /// Checks password complexity using regex:
        /// - Length 8 to 50 characters
        /// - Must include a letter, a digit, and a special character
        /// </summary>
        private bool IsPasswordComplex(string password)
        {
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

            // Use the improved sanitization methods:
            string username = SanitizeInput(tbUsername.Text, isPassword: false);
            string password = SanitizeInput(tbPassword.Text, isPassword: true);
            string deviceIdentifier = GetDeviceIdentifier();
            bool rememberDevice = cbRememberDevice.Checked;

            // Additional validations:
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
                    string query = "SELECT ID, PasswordHash, Email, ISNULL(MFAType, 'None') AS MFAType, IsVerified, IsDisabled FROM Users WHERE Username = @Username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userId = Convert.ToInt32(reader["ID"]);
                                email = reader["Email"].ToString();
                                string storedPasswordHash = reader["PasswordHash"].ToString();
                                string mfaType = reader["MFAType"].ToString().Trim().ToLower();
                                int isVerified = Convert.ToInt32(reader["IsVerified"]);

                                bool isDisabled = Convert.ToBoolean(reader["IsDisabled"]);
                                if (isDisabled)
                                {
                                    MessageBox.Show("Your account has been disabled. Please contact support.", "Account Disabled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

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

                                    MessageBox.Show("Your account is not verified. An OTP has been sent to your email. Please verify before logging in.",
                                        "Verification Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    SendOTPEmail(email, verificationCode);

                                    this.Hide();
                                    frmEmailVerification verifyForm = new frmEmailVerification(email);
                                    verifyForm.Show();
                                    return;
                                }

                                // Check if the device is already saved (bypass 2FA)
                                if (IsDeviceSaved(userId, deviceIdentifier))
                                {
                                    MessageBox.Show("Device recognized. Bypassing 2FA and/or Login Alerts.");
                                    Program.CurrentUserId = userId;
                                    this.Hide();
                                    frmUserHomePage homePage = new frmUserHomePage(userId);
                                    homePage.Show();
                                    return;
                                }

                                // If the device is not saved, enforce 2FA if enabled.
                                if (mfaType.Contains("email"))
                                {
                                    MessageBox.Show("Redirecting to OTP Page...");
                                    this.Hide();
                                    frmVerifyOTP otpForm = new frmVerifyOTP(userId, email, rememberDevice);
                                    otpForm.Show();
                                    return;
                                }

                                // Send login alert for new devices.
                                if (!IsDeviceSaved(userId, deviceIdentifier))
                                {
                                    SendLoginNotification(email, deviceIdentifier);

                                    // Save the device if "Remember Device" is checked.
                                    if (rememberDevice)
                                    {
                                        SaveDevice(userId, deviceIdentifier);
                                    }
                                }

                                CheckForActiveAlert(userId);

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
                // Output encode OTP even though it is internally generated.
                string encodedOtp = WebUtility.HtmlEncode(otp);

                // Create email message.
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
                        <div class='otp-code'>{encodedOtp}</div>
                        <p>This code is valid for <b>5 minutes</b>. Please do not share it with anyone.</p>
                        <p>If you did not request this OTP, please ignore this email.</p>
                        <div class='footer'>
                            Need help? Contact <a href='mailto:support@smarthomesystem.com'>support@smarthomesystem.com</a>.
                        </div>
                    </div>
                </body>
                </html>";
                mail.IsBodyHtml = true;

                // Configure and send using SMTP.
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("smarthomesystemsapplication@gmail.com", "dfwn lflx wmba cwfz"),
                    EnableSsl = true
                };

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
                // Encode the device identifier for safe HTML output.
                string encodedDeviceIdentifier = WebUtility.HtmlEncode(deviceIdentifier);

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
                <div class='device-info'>{encodedDeviceIdentifier}</div>
                <p><b>Date & Time:</b> {DateTime.Now.ToString("f")}</p>
                <p>If this was you, no further action is needed. If this was not you, please secure your account immediately.</p>
                <div class='footer'>
                    Need help? Contact <a href='mailto:support@smarthomesystem.com'>support@smarthomesystem.com</a>.
                </div>
            </div>
        </body>
        </html>";
                mail.IsBodyHtml = true;

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
            // Typically no action needed.
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Typically no action needed.
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            // Optionally add logic here.
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Typically no action needed.
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Optionally add logic here.
            tbPassword.PasswordChar = '*';
            tbPassword.UseSystemPasswordChar = true;
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            // Optionally add logic here.
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = !tbPassword.UseSystemPasswordChar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Optionally add logic here.
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Optionally add logic here.
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

                // Clear previous token (forces Google Sign-In prompt)
                string tokenPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GoogleOAuthToken");
                if (Directory.Exists(tokenPath))
                {
                    Directory.Delete(tokenPath, true);
                }

                using (var stream = new FileStream(credentialPath, FileMode.Open, FileAccess.Read))
                {
                    var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(tokenPath, false)
                    );

                    var oauthService = new Oauth2Service(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "Smart Home System"
                    });

                    Userinfo userInfo = await oauthService.Userinfo.Get().ExecuteAsync();
                    string googleEmail = userInfo.Email;
                    string googleName = userInfo.Name;

                    MessageBox.Show($"Login Successful!\n\nWelcome {googleName}\nEmail: {googleEmail}",
                        "Google Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                    {
                        conn.Open();
                        string query = "SELECT ID, IsDisabled FROM Users WHERE Email = @Email";
                        int userId = -1;
                        bool isDisabled = false;

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Email", googleEmail);

                            // Use ExecuteReader() instead of ExecuteScalar() to get multiple columns.
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    userId = Convert.ToInt32(reader["ID"]);
                                    isDisabled = Convert.ToBoolean(reader["IsDisabled"]);
                                }
                            }
                        }

                        // Check if the account is disabled
                        if (isDisabled)
                        {
                            MessageBox.Show("Your account has been disabled. Please contact support.", "Account Disabled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

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

                        if (mfaType.Contains("email"))
                        {
                            MessageBox.Show("Redirecting to OTP Page...");
                            this.Hide();
                            frmVerifyOTP otpForm = new frmVerifyOTP(userId, googleEmail, rememberDevice);
                            otpForm.Show();
                            return;
                        }

                        SendLoginNotification(googleEmail, deviceIdentifier);

                        if (rememberDevice)
                        {
                            SaveDevice(userId, deviceIdentifier);
                        }

                        CheckForActiveAlert(userId);
                        this.Hide();
                        frmUserHomePage homePage = new frmUserHomePage(userId);
                        homePage.FormClosed += (s, args) => this.Show();
                        homePage.Show();
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

        private void CheckForActiveAlert(int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT Message FROM Alerts WHERE IsActive = 1 AND StartTime <= GETDATE() AND EndTime >= GETDATE() ORDER BY CreatedAt DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string alertMessage = reader["Message"].ToString();
                                MessageBox.Show(alertMessage, "Scheduled Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking for scheduled alerts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void TogglePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (TogglePassword.Checked)
            {
                tbPassword.UseSystemPasswordChar = false; // Show the password
            }
            else
            {
                tbPassword.UseSystemPasswordChar = true; // Hide the password
            }
        }
    }
}
