using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace HomeSphere
{
    public partial class frmVerifyOTP : Form
    {
        private int userId;
        private string email;
        private bool rememberDevice; // ✅ Add this variable

        public frmVerifyOTP(int userId, string email, bool rememberDevice) // ✅ Accept rememberDevice
        {
            InitializeComponent();
            this.userId = userId;
            this.email = email;
            this.rememberDevice = rememberDevice; // ✅ Store the value

            // Automatically send OTP when form loads
            GenerateAndSendOTP();
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



        private void btnVerifyOTP_Click(object sender, EventArgs e)
        {
            string enteredOTP = tbOTP.Text.Trim();
            string deviceIdentifier = GetDeviceIdentifier();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT OTP, ExpiryTime FROM Users WHERE ID = @UserID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string savedOTP = reader["OTP"].ToString();
                            DateTime expiryTime = Convert.ToDateTime(reader["ExpiryTime"]);

                            if (savedOTP == enteredOTP && DateTime.Now <= expiryTime)
                            {
                                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // ✅ Always send login alert for new devices (even if "Remember Device" is NOT checked)
                                if (!IsDeviceSaved(userId, deviceIdentifier))
                                {
                                    SendLoginNotification(email, deviceIdentifier);

                                    // ✅ Only save the device if "Remember Device" is checked
                                    if (this.rememberDevice)
                                    {
                                        SaveDevice(userId, deviceIdentifier);
                                    }
                                }

                                CheckForActiveAlert(userId);
                                // ✅ Redirect user after OTP verification
                                this.Hide();
                                frmUserHomePage homePage = new frmUserHomePage(userId);
                                homePage.Show();
                                return;
                            }
                        }
                    }
                }
            }

            MessageBox.Show("Invalid or expired OTP!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private bool IsDeviceSaved(int userId, string deviceIdentifier)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
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
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
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




        private void btnResendOTP_Click(object sender, EventArgs e)
        {
            GenerateAndSendOTP();
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


        private void GenerateAndSendOTP()
        {
            string otp = new Random().Next(100000, 999999).ToString();
            DateTime expiryTime = DateTime.Now.AddMinutes(5);

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();
                string query = "UPDATE Users SET OTP = @OTP, ExpiryTime = @ExpiryTime WHERE ID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@OTP", otp);
                    cmd.Parameters.AddWithValue("@ExpiryTime", expiryTime);
                    cmd.ExecuteNonQuery();
                }
            }

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
