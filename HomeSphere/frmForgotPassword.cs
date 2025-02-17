using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BCrypt.Net;

namespace HomeSphere
{
    public partial class frmForgotPassword : Form
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public frmForgotPassword()
        {
            InitializeComponent();
            
        }

      

       

        

        private void btnResetPassword_Click_1(object sender, EventArgs e)
        {
            string Username = tbUsername.Text.Trim();
            string oldPassword = tbOldPassword.Text.Trim();
            string newPassword = tbNewPassword.Text.Trim();
            string confirmPassword = tbConfirmPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(Username))
            {
                MessageBox.Show("Username is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(oldPassword))
            {
                MessageBox.Show("Old password is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(strConnectionString))
                {
                    conn.Open();
                    string query = "SELECT PasswordHash FROM Users WHERE Username = @Username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", Username);
                        object result = cmd.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Username not found.");
                            return;
                        }

                        string storedPasswordHash = result.ToString();
                        if (!BCrypt.Net.BCrypt.Verify(oldPassword, storedPasswordHash))
                        {
                            MessageBox.Show("Old password is incorrect.");
                            return;
                        }
                    }

                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
                    string updateQuery = "UPDATE Users SET PasswordHash = @PasswordHash WHERE Username = @Username";

                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                        updateCmd.Parameters.AddWithValue("@Username", Username);
                        updateCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Password updated successfully! Redirecting to login page.");
                this.Hide();
                frmLogin1 loginForm = new frmLogin1();
                loginForm.Show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
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

        private void TogglePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (TogglePassword.Checked)
            {
                tbNewPassword.UseSystemPasswordChar = false; // Show the password
            }
            else
            {
                tbNewPassword.UseSystemPasswordChar = true; // Hide the password
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (TogglePassword.Checked)
            {
                tbConfirmPassword.UseSystemPasswordChar = false; // Show the password
            }
            else
            {
                tbConfirmPassword.UseSystemPasswordChar = true; // Hide the password
            }
        }

        private void frmForgotPassword_Load(object sender, EventArgs e)
        {
            tbNewPassword.PasswordChar = '*';
            tbNewPassword.UseSystemPasswordChar = true;
            tbConfirmPassword.PasswordChar = '*';
            tbConfirmPassword.UseSystemPasswordChar = true;
        }
    }
}
