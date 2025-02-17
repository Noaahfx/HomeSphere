using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace HomeSphere
{
    public partial class frmEmailVerification : Form
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private string userEmail;

        public frmEmailVerification(string email)
        {
            InitializeComponent();
            userEmail = email;
        }

        private void btnVerifyOTP_Click(object sender, EventArgs e)
        {
            string enteredOTP = tbOTP.Text.Trim();

            // ✅ Prevent blank OTP verification
            if (string.IsNullOrWhiteSpace(enteredOTP))
            {
                MessageBox.Show("Please enter the OTP before verifying!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(strConnectionString))
            {
                conn.Open();
                string query = "SELECT VerificationCode, VerificationCodeExpiryTime FROM Users WHERE Email = @Email AND IsVerified = 0";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", userEmail);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string savedOTP = reader["VerificationCode"].ToString();
                            DateTime expiryTime = reader["VerificationCodeExpiryTime"] != DBNull.Value ? Convert.ToDateTime(reader["VerificationCodeExpiryTime"]) : DateTime.MinValue;

                            // ✅ Check if OTP matches and is still valid
                            if (savedOTP == enteredOTP && DateTime.Now <= expiryTime)
                            {
                                reader.Close();
                                string updateQuery = "UPDATE Users SET IsVerified = 1, VerificationCode = NULL, VerificationCodeExpiryTime = NULL WHERE Email = @Email";
                                using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                                {
                                    updateCmd.Parameters.AddWithValue("@Email", userEmail);
                                    updateCmd.ExecuteNonQuery();
                                }
                                MessageBox.Show("Verification successful! You may now log in.");
                                this.Hide();
                                frmLogin1 loginForm = new frmLogin1();
                                loginForm.Show();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Invalid or expired OTP.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
            }

            MessageBox.Show("Invalid OTP or already verified.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private void btnResendOTP_Click(object sender, EventArgs e)
        {
            string newOTP = new Random().Next(100000, 999999).ToString();
            DateTime expiryTime = DateTime.Now.AddMinutes(5); // ✅ OTP expires in 5 minutes

            using (SqlConnection conn = new SqlConnection(strConnectionString))
            {
                conn.Open();
                string updateQuery = "UPDATE Users SET VerificationCode = @OTP, VerificationCodeExpiryTime = @ExpiryTime WHERE Email = @Email AND IsVerified = 0";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@OTP", newOTP);
                    cmd.Parameters.AddWithValue("@ExpiryTime", expiryTime);
                    cmd.Parameters.AddWithValue("@Email", userEmail);
                    cmd.ExecuteNonQuery();
                }
            }

            SendOTPEmail(userEmail, newOTP);
            MessageBox.Show("New OTP sent to your email. It will expire in 5 minutes.");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin1 loginForm = Application.OpenForms["frmLogin1"] as frmLogin1;

            if (loginForm != null)
            {
                loginForm.Show();
            }
            else
            {
                new frmLogin1().Show();
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
    }
}
