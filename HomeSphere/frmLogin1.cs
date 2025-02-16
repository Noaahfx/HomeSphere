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
            errorProvider1.SetError(tbUsername, "");
            errorProvider1.SetError(tbPassword, "");

            string username = SanitizeInput(tbUsername.Text.Trim());
            string password = SanitizeInput(tbPassword.Text.Trim());

            if (string.IsNullOrWhiteSpace(username) || username == "Enter your username")
            {
                errorProvider1.SetError(tbUsername, "Username is required.");
                return;
            }
            else if (username.Length > 100)
            {
                errorProvider1.SetError(tbUsername, "Username too long (max 100 chars).");
                return;
            }

            if (string.IsNullOrWhiteSpace(password) || password == "Enter your password")
            {
                errorProvider1.SetError(tbPassword, "Password is required.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(strConnectionString))
                {
                    conn.Open();
                    string query = "SELECT ID, PasswordHash FROM Users WHERE Username = @Username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = Convert.ToInt32(reader["ID"]);
                                string storedPasswordHash = reader["PasswordHash"].ToString();

                                if (!BCrypt.Net.BCrypt.Verify(password, storedPasswordHash))
                                {
                                    MessageBox.Show("Incorrect password.");
                                    return;
                                }

                                Program.CurrentUserId = userId;
                                this.Hide();
                                frmUserHomePage homePage = new frmUserHomePage(userId);
                                homePage.Show();
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
                                this.Hide(); // ✅ Hide the login form first
                                frmUserHomePage userHomePage = new frmUserHomePage(userId);
                                userHomePage.FormClosed += (s, args) => this.Show(); // ✅ Show login form when HomePage is closed
                                userHomePage.Show();
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


