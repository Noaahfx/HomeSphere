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

                            this.Hide(); // ✅ Hide login form first
                            Form1 form1 = new Form1();
                            form1.FormClosed += (s, args) => this.Close(); // ✅ Ensure `frmAdminLogin` closes when `Form1` is closed
                            form1.Show();
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
            this.Hide(); // ✅ Hide `frmAdminLogin`
            frmLogin loginForm = new frmLogin();
            loginForm.FormClosed += (s, args) => this.Close(); // ✅ Close `frmAdminLogin` when `frmLogin` closes
            loginForm.Show();
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
