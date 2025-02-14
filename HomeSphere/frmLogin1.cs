using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Data.SqlClient;
//using System.Configuration;

//namespace PracticalADO_ReadDB
//{
//    public partial class frmLogin : Form
//    {
//        private string strConnectionString =
//          ConfigurationManager.ConnectionStrings["SampleDBConnection"].ConnectionString;
//        public frmLogin()
//        {
//            InitializeComponent();

//        }

//        ///
//        private void label1_Click(object sender, EventArgs e)
//        {

//        }

//        private void label2_Click(object sender, EventArgs e)
//        {

//        }


//        private void btnCancel_Click(object sender, EventArgs e)
//        {
//            this.Close();
//        }

//        private void btnLogin_Click_1(object sender, EventArgs e)
//        {
//            SqlConnection myconnect = new SqlConnection(strConnectionString);
//            string strCommandText = "SELECT Name, Password FROM MyUser";
//            strCommandText += " WHERE Name=@uname AND Password=@pwd";
//            SqlCommand cmd = new SqlCommand(strCommandText, myconnect);
//            cmd.Parameters.AddWithValue("@uname", tbUsername.Text);
//            cmd.Parameters.AddWithValue("@pwd", tbPassword.Text);

//            try
//            {
//                myconnect.Open();

//                SqlDataReader reader = cmd.ExecuteReader();
//                if (reader.Read())
//                    MessageBox.Show("Login Successful");
//                else
//                    MessageBox.Show("Login Fail");

//                reader.Close();
//            }
//            catch (SqlException ex)
//            {
//                MessageBox.Show("Error: " + ex.Message.ToString());
//            }
//            finally
//            {
//                myconnect.Close();
//            }

//        }
//    }
//}

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;

namespace PracticalADO_ReadDB
{
    public partial class frmLogin : Form
    {
        
        private string strConnectionString =
            ConfigurationManager.ConnectionStrings["SampleDBConnection"].ConnectionString;

        public frmLogin()
        {
            InitializeComponent();
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
            // Clear old errors
            errorProvider1.SetError(tbUsername, "");
            errorProvider1.SetError(tbPassword, "");

            bool isValid = true;

            // 1) Get the raw input from textboxes
            string usernameRaw = tbUsername.Text.Trim();
            string passwordRaw = tbPassword.Text.Trim();

            // 2) Sanitize to remove < or > to mitigate naive HTML injection
            string username = SanitizeInput(usernameRaw);
            string password = SanitizeInput(passwordRaw);

            // 3) Validate Username
            if (string.IsNullOrWhiteSpace(username))
            {
                errorProvider1.SetError(tbUsername, "Username is required.");
                isValid = false;
            }
            else if (username.Length > 50)
            {
                errorProvider1.SetError(tbUsername, "Username too long (max 50 chars).");
                isValid = false;
            }
            // Optional additional check:
            // if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
            // {
            //     errorProvider1.SetError(tbUsername, "Username contains invalid characters.");
            //     isValid = false;
            // }

            // 4) Validate Password (complexity, length, etc.)
            if (string.IsNullOrWhiteSpace(password))
            {
                errorProvider1.SetError(tbPassword, "Password is required.");
                isValid = false;
            }
            else
            {
                // Check if it meets complexity: 8–50 chars, must have letter, digit, special char
                if (!IsPasswordComplex(password))
                {
                    errorProvider1.SetError(tbPassword,
                        "Must be 8–50 chars long & include letters, digits, and special characters.");
                    isValid = false;
                }
            }

            // If any validation failed, stop
            if (!isValid) return;

            // 5) Attempt login with parameterized SQL query to prevent SQL injection
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnectionString))
                {
                    conn.Open();
                    string strCommandText =
                        @"SELECT Name, Password , UniqueRFID
                          FROM MyUser
                          WHERE Name = @uname 
                            AND Password = @pwd";

                    using (SqlCommand cmd = new SqlCommand(strCommandText, conn))
                    {
                        cmd.Parameters.AddWithValue("@uname", username);
                        cmd.Parameters.AddWithValue("@pwd", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("Login Successful!");
                                // e.g., proceed to main form
                                int uniqueRFID = Convert.ToInt32(reader["UniqueRFID"]);
                                Graph dashboard = new Graph(uniqueRFID);  // "Graph" is your other form
                                dashboard.Show();

                                // Option A: Hide this login form (so the user can’t go back)
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Login Failed!");
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}


