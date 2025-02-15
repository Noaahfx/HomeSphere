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
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(1) FROM Admins WHERE Username = @Username AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        int count = (int)cmd.ExecuteScalar();

                        if (count == 1)
                        {
                            MessageBox.Show("Admin login successful!");

                            // ✅ Set CurrentUser in CartManager so the admin's cart is correctly loaded
                            CartManager.CurrentUser = username;

                            this.Hide(); // Hide login form
                            Form1 form1 = new Form1();
                            form1.Show(); // Use Show() instead of ShowDialog()
                        }
                        else
                        {
                            MessageBox.Show("Invalid admin credentials! Please check the username and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while logging in: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void lnkLoginAsUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide(); // Hide instead of closing to allow returning if needed
            frmLogin loginForm = new frmLogin();
            loginForm.ShowDialog();
            this.Show(); // Re-show login form if user login is canceled
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
