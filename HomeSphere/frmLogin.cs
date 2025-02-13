using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace HomeSphere
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSendOTP_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text.Trim();
            string otp = new Random().Next(100000, 999999).ToString();
            DateTime expiryTime = DateTime.Now.AddMinutes(5);

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();

                string query = "SELECT COUNT(1) FROM Users WHERE Email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    int count = (int)cmd.ExecuteScalar();

                    query = count > 0
                        ? "UPDATE Users SET OTP = @OTP, ExpiryTime = @ExpiryTime WHERE Email = @Email"
                        : "INSERT INTO Users (Email, OTP, ExpiryTime) VALUES (@Email, @OTP, @ExpiryTime)";

                    using (SqlCommand cmd2 = new SqlCommand(query, conn))
                    {
                        cmd2.Parameters.AddWithValue("@Email", email);
                        cmd2.Parameters.AddWithValue("@OTP", otp);
                        cmd2.Parameters.AddWithValue("@ExpiryTime", expiryTime);
                        cmd2.ExecuteNonQuery();
                    }
                }
            }

            try
            {
                MailMessage mail = new MailMessage("smarthomesystemsapplication@gmail.com", email)
                {
                    Subject = "Your OTP Code from Smart Home System",
                    Body = @"
        <html>
            <body style='font-family: Arial, sans-serif; line-height: 1.6;'>
                <h2 style='color: #4CAF50;'>Your One-Time Password (OTP)</h2>
                <p>Dear user,</p>
                <p>Your OTP code for accessing the <strong>Smart Home System</strong> is:</p>
                <div style='font-size: 24px; font-weight: bold; margin: 10px 0; color: #333;'>"
                                + otp +
                                @"</div>
                <p>This code is valid for <strong>5 minutes</strong>. Please do not share this code with anyone.</p>
                <p>Thank you for using <strong>Smart Home System</strong>!</p>
                <hr style='border: none; border-top: 1px solid #ccc;' />
                <p style='font-size: 12px; color: #999;'>If you did not request this OTP, please ignore this email or contact support.</p>
            </body>
        </html>",
                    IsBodyHtml = true
                };


                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("smarthomesystemsapplication@gmail.com", "dfwn lflx wmba cwfz"),
                    EnableSsl = true
                };

                smtpClient.Send(mail);
                MessageBox.Show("OTP sent successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending OTP: " + ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text.Trim();
            string otp = tbOTP.Text.Trim();
            string deviceIdentifier = GetDeviceIdentifier();
            bool saveDevice = cbSaveDevice.Checked;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();

                string query = "SELECT ID FROM Users WHERE Email = @Email";
                int userId = -1;

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Email not found!");
                        return;
                    }
                    userId = Convert.ToInt32(result);

                    // Set the global user ID
                    Program.CurrentUserId = userId;

                    // Start global notifications after login
                    Program.StartNotifications();
                }

                query = "SELECT OTP, ExpiryTime FROM Users WHERE ID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string savedOtp = reader["OTP"].ToString();
                            DateTime expiryTime = Convert.ToDateTime(reader["ExpiryTime"]);

                            if (savedOtp == otp && DateTime.Now <= expiryTime)
                            {
                                reader.Close();
                                query = "SELECT IsNotified FROM Devices WHERE UserID = @UserID AND DeviceIdentifier = @DeviceIdentifier";
                                using (SqlCommand deviceCmd = new SqlCommand(query, conn))
                                {
                                    deviceCmd.Parameters.AddWithValue("@UserID", userId);
                                    deviceCmd.Parameters.AddWithValue("@DeviceIdentifier", deviceIdentifier);
                                    object result = deviceCmd.ExecuteScalar();

                                    if (result == null)
                                    {
                                        if (saveDevice)
                                        {
                                            query = "INSERT INTO Devices (UserID, DeviceIdentifier, IsNotified) VALUES (@UserID, @DeviceIdentifier, @IsNotified)";
                                            using (SqlCommand insertCmd = new SqlCommand(query, conn))
                                            {
                                                insertCmd.Parameters.AddWithValue("@UserID", userId);
                                                insertCmd.Parameters.AddWithValue("@DeviceIdentifier", deviceIdentifier);
                                                insertCmd.Parameters.AddWithValue("@IsNotified", true);
                                                insertCmd.ExecuteNonQuery();
                                            }
                                        }
                                        SendLoginNotification(email, deviceIdentifier);
                                    }
                                    else if (!(bool)result)
                                    {
                                        if (saveDevice)
                                        {
                                            query = "UPDATE Devices SET IsNotified = 1 WHERE UserID = @UserID AND DeviceIdentifier = @DeviceIdentifier";
                                            using (SqlCommand updateCmd = new SqlCommand(query, conn))
                                            {
                                                updateCmd.Parameters.AddWithValue("@UserID", userId);
                                                updateCmd.Parameters.AddWithValue("@DeviceIdentifier", deviceIdentifier);
                                                updateCmd.ExecuteNonQuery();
                                            }
                                        }
                                        SendLoginNotification(email, deviceIdentifier);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Login successful! No notification sent for this saved device.");
                                        this.Hide();

                                        // Navigate to the User Home Page
                                        frmUserHomePage userHomePage = new frmUserHomePage(Program.CurrentUserId);
                                        userHomePage.Show();
                                        return;
                                    }
                                }

                                MessageBox.Show("Login successful!");
                                this.Hide();

                                // Navigate to the User Home Page
                                frmUserHomePage preferencesForm = new frmUserHomePage(Program.CurrentUserId);
                                preferencesForm.Show();
                                return;
                            }
                            MessageBox.Show("Invalid or expired OTP!");
                        }
                        else
                        {
                            MessageBox.Show("OTP not found or expired!");
                        }
                    }
                }
            }
        }

        private string GetDeviceIdentifier()
        {
            return $"{Environment.MachineName}-{Program.SessionId}";
        }

        private void SendLoginNotification(string email, string deviceIdentifier)
        {
            try
            {
                MailMessage mail = new MailMessage("smarthomesystemsapplication@gmail.com", email)
                {
                    Subject = "New Device Login Alert - Smart Home System",
                    Body = @"
        <html>
            <body style='font-family: Arial, sans-serif; line-height: 1.6;'>
                <h2 style='color: #FF5722;'>New Device Login Alert</h2>
                <p>Dear user,</p>
                <p>A login attempt was detected on a new device:</p>
                <ul style='background-color: #f9f9f9; padding: 15px; border: 1px solid #ddd;'>
                    <li><strong>Device Identifier:</strong> " + deviceIdentifier + @"</li>
                    <li><strong>Date & Time:</strong> " + DateTime.Now.ToString("f") + @"</li>
                </ul>
                <p>If this was you, no further action is needed. However, if this was not you, please secure your account immediately by resetting your password.</p>
                <p>Thank you for choosing <strong>Smart Home System</strong>.</p>
                <hr style='border: none; border-top: 1px solid #ccc;' />
                <p style='font-size: 12px; color: #999;'>If you have any questions or need assistance, contact support at <a href='mailto:support@smarthomesystem.com'>support@smarthomesystem.com</a>.</p>
            </body>
        </html>",
                    IsBodyHtml = true
                };


                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("smarthomesystemsapplication@gmail.com", "dfwn lflx wmba cwfz"),
                    EnableSsl = true
                };

                smtpClient.Send(mail);
                MessageBox.Show("Login notification sent!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending notification: " + ex.Message);
            }
        }

        private void lnkLoginAsAdmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Close the current login form
            frmAdminLogin adminLoginForm = new frmAdminLogin();
            adminLoginForm.Show(); // Show the admin login form
            this.Hide();
        }

        private void btnLoginWithoutOTP_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text.Trim();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();

                string query = "SELECT ID FROM Users WHERE Email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Email not found!");
                        return;
                    }

                    int userId = Convert.ToInt32(result);

                    // Set Program.CurrentUserId for global access
                    Program.CurrentUserId = userId;

                    // Start global notifications after login
                    Program.StartNotifications();

                    MessageBox.Show("Login successful without OTP!");
                    this.Hide();
                    frmUserHomePage userHomePage = new frmUserHomePage(userId);
                    userHomePage.Show();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit the application?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Shut down the application
            }
        }

        private void btnLoginForSavedDevice_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text.Trim();
            string deviceIdentifier = GetDeviceIdentifier();

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email cannot be empty. Please enter your email.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["IotPrj_NoahDB"].ConnectionString))
            {
                try
                {
                    conn.Open();

                    // Check if the email exists in the database
                    string query = "SELECT ID FROM Users WHERE Email = @Email";
                    int userId = -1;

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        object result = cmd.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Email not found! Please register or check your email.");
                            return;
                        }

                        userId = Convert.ToInt32(result);
                    }

                    // Check if the device is saved for the user
                    query = "SELECT IsNotified FROM Devices WHERE UserID = @UserID AND DeviceIdentifier = @DeviceIdentifier";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@DeviceIdentifier", deviceIdentifier);

                        object result = cmd.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("This device is not registered as a saved device for this email. Please use OTP login.");
                            return;
                        }

                        bool isNotified = (bool)result;

                        if (!isNotified)
                        {
                            MessageBox.Show("Device exists but not verified. Please use OTP login to verify this device.");
                            return;
                        }
                    }

                    // If validation passes, log the user in
                    Program.CurrentUserId = userId;
                    Program.StartNotifications();

                    MessageBox.Show("Login successful for saved device!");
                    this.Hide();
                    frmUserHomePage userHomePage = new frmUserHomePage(userId);
                    userHomePage.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while processing the request: " + ex.Message);
                }
            }
        }

    }
}
