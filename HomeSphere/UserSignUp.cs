using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BCrypt.Net;

namespace HomeSphere
{
    public partial class UserSignUp : Form
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
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

                    // Insert new user
                    string insertQuery = "INSERT INTO Users (Email, Username, PasswordHash) VALUES (@Email, @Username, @PasswordHash)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@Email", email);
                        insertCmd.Parameters.AddWithValue("@Username", username);
                        insertCmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                        insertCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Registration successful!");
                frmLogin1 loginForm = new frmLogin1();
                loginForm.Show();
                this.Hide();

                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
