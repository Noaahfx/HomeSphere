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
            InitializePlaceholders();
        }

        private void InitializePlaceholders()
        {
            SetPlaceholder(tbEmail, "Enter your Email");
            SetPlaceholder(tbOldPassword, "Enter old password");
            SetPlaceholder(tbNewPassword, "Enter new password");
            SetPlaceholder(tbConfirmPassword, "Confirm new password");

            tbEmail.GotFocus += RemovePlaceholder;
            tbEmail.LostFocus += AddPlaceholder;

            tbOldPassword.GotFocus += RemovePlaceholder;
            tbOldPassword.LostFocus += AddPlaceholder;

            tbNewPassword.GotFocus += RemovePlaceholder;
            tbNewPassword.LostFocus += AddPlaceholder;

            tbConfirmPassword.GotFocus += RemovePlaceholder;
            tbConfirmPassword.LostFocus += AddPlaceholder;
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
                if (textBox == tbOldPassword || textBox == tbNewPassword || textBox == tbConfirmPassword)
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
                if (textBox == tbEmail)
                    SetPlaceholder(textBox, "Enter your email");
                else if (textBox == tbOldPassword)
                    SetPlaceholder(textBox, "Enter old password");
                else if (textBox == tbNewPassword)
                    SetPlaceholder(textBox, "Enter new password");
                else if (textBox == tbConfirmPassword)
                    SetPlaceholder(textBox, "Confirm new password");
                textBox.UseSystemPasswordChar = false;
            }
        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin1 loginForm = new frmLogin1();
            loginForm.Show();
        }

        private void btnResetPassword_Click_1(object sender, EventArgs e)
        {
            string username = tbEmail.Text.Trim();
            string oldPassword = tbOldPassword.Text.Trim();
            string newPassword = tbNewPassword.Text.Trim();
            string confirmPassword = tbConfirmPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username))
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
                        cmd.Parameters.AddWithValue("@Username", username);
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
                        updateCmd.Parameters.AddWithValue("@Username", username);
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
    }
}
