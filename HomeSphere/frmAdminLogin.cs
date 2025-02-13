using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace HomeSphere
{
    public partial class frmAdminLogin : Form
    {
        public frmAdminLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text.Trim();
            string password = tbPassword.Text.Trim();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(1) FROM Admins WHERE Username = @Username AND Password = @Password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password); // Pass plaintext for now

                    int count = (int)cmd.ExecuteScalar();

                    if (count == 1)
                    {
                        MessageBox.Show("Admin login successful!");
                        this.Close(); // Properly close the admin login form
                        frmAdminHomePage adminHomePage = new frmAdminHomePage();
                        adminHomePage.Show(); // Open the admin dashboard
                    }
                    else
                    {
                        MessageBox.Show("Invalid admin credentials! Please check the username and password.");
                    }
                }
            }
        }

        private void lnkLoginAsUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close(); // Close the current admin login form
            frmLogin loginForm = new frmLogin();
            loginForm.Show(); // Show the user login form
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit the application?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Shut down the application
            }
        }

    }
}
