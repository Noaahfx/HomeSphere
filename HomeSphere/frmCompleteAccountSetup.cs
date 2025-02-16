using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using BCrypt.Net;

namespace HomeSphere
{
    public partial class frmCompleteAccountSetup : Form
    {
        private string userEmail;
        private string userName;

        public frmCompleteAccountSetup(string email, string name)
        {
            InitializeComponent();
            userEmail = email;
            userName = name;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text.Trim();
            string password = tbPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and Password cannot be empty!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Hash the password for security
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            int userId = -1; // Variable to store UserID

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();

                // ✅ Step 1: Check if Email Already Exists
                string checkQuery = "SELECT ID FROM Users WHERE Email = @Email";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Email", userEmail);
                    var existingUser = checkCmd.ExecuteScalar();

                    if (existingUser != null)  // Email already exists
                    {
                        MessageBox.Show("This email is already registered. Redirecting to Login Page...", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        this.Hide();
                        frmLogin1 loginForm = new frmLogin1();
                        loginForm.Show();
                        return; // Stop execution if the email already exists
                    }
                }

                // ✅ Step 2: Insert User Details
                string insertQuery = "INSERT INTO Users (Email, Username, PasswordHash, IsGoogleUser) VALUES (@Email, @Username, @Password, 1); SELECT SCOPE_IDENTITY();";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@Email", userEmail);
                    insertCmd.Parameters.AddWithValue("@Username", username);
                    insertCmd.Parameters.AddWithValue("@Password", hashedPassword);

                    var result = insertCmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out userId))
                    {
                        MessageBox.Show("Account setup completed successfully! Redirecting to Home Page...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // ✅ Step 3: If UserID Retrieval Fails, Get it Manually
                if (userId == -1)
                {
                    using (SqlCommand getUserIdCmd = new SqlCommand("SELECT ID FROM Users WHERE Email = @Email", conn))
                    {
                        getUserIdCmd.Parameters.AddWithValue("@Email", userEmail);
                        var userIdResult = getUserIdCmd.ExecuteScalar();

                        if (userIdResult != null && int.TryParse(userIdResult.ToString(), out userId))
                        {
                            MessageBox.Show("Account setup completed successfully! Redirecting to Home Page...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error retrieving User ID. Please log in manually.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Hide();
                            frmLogin1 loginForm = new frmLogin1();
                            loginForm.Show();
                            return;
                        }
                    }
                }
            }

            // ✅ Redirect to Home Page if everything worked
            this.Hide();
            frmUserHomePage userHomePage = new frmUserHomePage(userId);
            userHomePage.Show();
        }
    }
}
