using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace HomeSphere
{
    public partial class frmUserHomePage : Form
    {
        private int userId;

        public frmUserHomePage(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            CheckForActiveAlert();
        }

        private void lnkNotificationSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmNotificationPreferences notificationPreferences = new frmNotificationPreferences(userId);
            this.Hide();
            notificationPreferences.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Stop global notifications
                Program.StopNotifications();

                // Reset the global user ID
                Program.CurrentUserId = -1;

                // Close this form and show the login form
                this.Hide();
                frmLogin1 loginForm = new frmLogin1();
                loginForm.FormClosed += (s, args) => this.Close();
                loginForm.Show();
            }
        }

        // New method: Check for active alerts
        private void CheckForActiveAlert()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT TOP 1 Message FROM Alerts WHERE IsActive = 1 ORDER BY CreatedAt DESC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            string alertMessage = result.ToString();
                            MessageBox.Show(alertMessage, "Active Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking for active alerts: {ex.Message}");
            }
        }

        private void lnkMFASettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmMFASettings mfaSettings = new frmMFASettings(userId);
            this.Hide();
            mfaSettings.Show();
        }
    }
}
