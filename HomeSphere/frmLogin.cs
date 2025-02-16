using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Oauth2.v2;
using Google.Apis.Oauth2.v2.Data;


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
                    Body = "Your OTP Code is: " + otp,
                    IsBodyHtml = false
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

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();

                // ✅ Check if user is disabled
                string query = "SELECT ID, IsDisabled FROM Users WHERE Email = @Email";
                int userId = -1;
                bool isDisabled = false;

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show("Email not found!");
                            return;
                        }
                        userId = Convert.ToInt32(reader["ID"]);
                        isDisabled = Convert.ToBoolean(reader["IsDisabled"]);
                    }
                }

                if (isDisabled)
                {
                    MessageBox.Show("User account is temporarily disabled.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Proceed with OTP verification
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
                                MessageBox.Show("Login successful!");
                                this.Hide();
                                frmUserHomePage userHomePage = new frmUserHomePage(userId);
                                userHomePage.Show();
                                return;
                            }
                        }
                    }
                }

                MessageBox.Show("Invalid or expired OTP!");
            }
        }

        private void btnLoginWithoutOTP_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text.Trim();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();

                // ✅ Check if user is disabled
                string query = "SELECT ID, IsDisabled FROM Users WHERE Email = @Email";
                int userId = -1;
                bool isDisabled = false;

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show("Email not found!");
                            return;
                        }
                        userId = Convert.ToInt32(reader["ID"]);
                        isDisabled = Convert.ToBoolean(reader["IsDisabled"]);
                    }
                }

                if (isDisabled)
                {
                    MessageBox.Show("User account is temporarily disabled.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Login successful without OTP!");
                this.Hide();
                frmUserHomePage userHomePage = new frmUserHomePage(userId);
                userHomePage.Show();
            }
        }

        private void btnLoginForSavedDevice_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text.Trim();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();

                // ✅ Check if user is disabled
                string query = "SELECT ID, IsDisabled FROM Users WHERE Email = @Email";
                int userId = -1;
                bool isDisabled = false;

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show("Email not found!");
                            return;
                        }
                        userId = Convert.ToInt32(reader["ID"]);
                        isDisabled = Convert.ToBoolean(reader["IsDisabled"]);
                    }
                }

                if (isDisabled)
                {
                    MessageBox.Show("User account is temporarily disabled.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Login successful for saved device!");
                this.Hide();
                frmUserHomePage userHomePage = new frmUserHomePage(userId);
                userHomePage.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit the application?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


    }
}
