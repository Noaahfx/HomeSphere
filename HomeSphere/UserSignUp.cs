using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net.Mail;  // ✅ Added missing namespace
using System.Net;       // ✅ Added missing namespace
using System.Windows.Forms;
using BCrypt.Net;

namespace HomeSphere
{
    public partial class UserSignUp : Form
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private string verificationCode; // ✅ Declare globally to fix "does not exist in the current context" error

        public UserSignUp()
        {

            
            InitializeComponent();
            InitializePlaceholders();

        }

        private void UserSignUp_Load(object sender, EventArgs e)
        {

        }
        private void InitializePlaceholders()
        {
            SetPlaceholder(tbEmail, "Enter your email");
            SetPlaceholder(tbUsername, "Choose a username");
            SetPlaceholder(tbPassword, "Enter a password");
            SetPlaceholder(tbConfirmPassword, "Confirm your password");

            tbEmail.GotFocus += RemovePlaceholder;
            tbEmail.LostFocus += AddPlaceholder;

            tbUsername.GotFocus += RemovePlaceholder;
            tbUsername.LostFocus += AddPlaceholder;

            tbPassword.GotFocus += RemovePlaceholder;
            tbPassword.LostFocus += AddPlaceholder;

            tbConfirmPassword.GotFocus += RemovePlaceholder;
            tbConfirmPassword.LostFocus += AddPlaceholder;
        }
        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            if (textBox == null) return;  // ✅ Prevents NullReferenceException

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
            }
        }


        private void AddPlaceholder(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox == tbEmail)
                    SetPlaceholder(textBox, "Enter your email");
                else if (textBox == tbUsername)
                    SetPlaceholder(textBox, "Choose a username");
                else if (textBox == tbPassword)
                    SetPlaceholder(textBox, "Enter a password");
                else if (textBox == tbConfirmPassword)
                    SetPlaceholder(textBox, "Confirm your password");

                textBox.UseSystemPasswordChar = false; // Show placeholder text
            }
        }


        private string SanitizeInput(string input)
        {
            return input.Replace("<", "").Replace(">", "").Trim();
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private bool IsPasswordComplex(string password)
        {
            string pattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?])" +
                             @"[A-Za-z\d!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]{8,50}$";
            return Regex.IsMatch(password, pattern);
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            string email = SanitizeInput(tbEmail.Text);
            string username = SanitizeInput(tbUsername.Text);
            string password = SanitizeInput(tbPassword.Text);
            string confirmPassword = SanitizeInput(tbConfirmPassword.Text);

            if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
            {
                errorProvider1.SetError(tbEmail, "Enter a valid email.");
                return;
            }

            if (string.IsNullOrWhiteSpace(username) || username.Length > 100)
            {
                errorProvider1.SetError(tbUsername, "Username must be between 1 and 100 characters.");
                return;
            }

            if (string.IsNullOrWhiteSpace(password) || !IsPasswordComplex(password))
            {
                errorProvider1.SetError(tbPassword, "Password must be 8–50 characters and include letters, digits, and special characters.");
                return;
            }

            if (password != confirmPassword)
            {
                errorProvider1.SetError(tbConfirmPassword, "Passwords do not match.");
                return;
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            try
            {
                using (SqlConnection conn = new SqlConnection(strConnectionString))
                {
                    conn.Open();

                    // Check if email already exists
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", email);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Email is already registered. Please log in.");
                            return;
                        }
                    }

                    // Insert new user with IsVerified = 0
                    string insertQuery = "INSERT INTO Users (Email, Username, PasswordHash, IsVerified, VerificationCode, VerificationCodeExpiryTime) " +
                                         "VALUES (@Email, @Username, @PasswordHash, 0, NULL, NULL)";

                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@Email", email);
                        insertCmd.Parameters.AddWithValue("@Username", username);
                        insertCmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                        insertCmd.ExecuteNonQuery();
                    }


                    // Generate and send OTP
                    verificationCode = new Random().Next(100000, 999999).ToString();
                    SaveOTP(email, verificationCode);
                    SendOTP(email, verificationCode);

                    // Redirect to verification form
                    this.Hide();
                    frmEmailVerification verifyForm = new frmEmailVerification(email);
                    verifyForm.Show();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SaveOTP(string email, string otp)
        {
            DateTime expiryTime = DateTime.Now.AddMinutes(5); // ✅ Set OTP expiration time

            using (SqlConnection conn = new SqlConnection(strConnectionString))
            {
                conn.Open();
                string query = "UPDATE Users SET VerificationCode = @OTP, VerificationCodeExpiryTime = @ExpiryTime WHERE Email = @Email";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@OTP", otp);
                    cmd.Parameters.AddWithValue("@ExpiryTime", expiryTime);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        private void SendOTP(string email, string otp)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            tbEmail.Text = string.Empty;
            tbUsername.Text = string.Empty;
            tbPassword.Text = string.Empty;
            tbConfirmPassword.Text = string.Empty;
            tbEmail.Focus();
        }
    }
}
