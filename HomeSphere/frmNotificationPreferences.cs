using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace HomeSphere
{
    public partial class frmNotificationPreferences : Form
    {
        private int userId;
        private Timer notificationTimer;
        private int elapsedTime;
        private bool notificationsEnabled; // Flag to control notifications display

        public frmNotificationPreferences(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            InitializeTimer();
            LoadPreferences();

            // Initialize the notificationsEnabled flag based on the checkbox
            notificationsEnabled = cbTimeElapsed.Checked;
        }

        private void InitializeTimer()
        {
            elapsedTime = 0;
            notificationTimer = new Timer { Interval = 10000 }; // 10 seconds
            notificationTimer.Tick += NotificationTimer_Tick;
        }

        private void LoadPreferences()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT IsEnabled FROM UserPreferences WHERE UserID = @UserID AND NotificationType = 'Time Elapsed Notification'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            cbTimeElapsed.Checked = Convert.ToBoolean(result);
                            lblStatus.Text = cbTimeElapsed.Checked ? "Notifications Enabled" : "Notifications Disabled";
                        }
                    }
                }

                // Update notificationsEnabled based on loaded preferences
                notificationsEnabled = cbTimeElapsed.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading preferences: {ex.Message}");
            }
        }

        private void SavePreferences(bool isEnabled)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = "IF EXISTS (SELECT 1 FROM UserPreferences WHERE UserID = @UserID AND NotificationType = 'Time Elapsed Notification') " +
                                   "UPDATE UserPreferences SET IsEnabled = @IsEnabled WHERE UserID = @UserID AND NotificationType = 'Time Elapsed Notification' " +
                                   "ELSE INSERT INTO UserPreferences (UserID, NotificationType, IsEnabled) VALUES (@UserID, 'Time Elapsed Notification', @IsEnabled)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@IsEnabled", isEnabled);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Update the global notification timer
                if (isEnabled)
                {
                    Program.StartNotifications();
                }
                else
                {
                    Program.StopNotifications();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving preferences: {ex.Message}");
            }
        }


        private void NotificationTimer_Tick(object sender, EventArgs e)
        {
            if (!notificationsEnabled)
            {
                return; // Do nothing if notifications are disabled
            }

            elapsedTime += 10;
            MessageBox.Show($"App has been open for {elapsedTime / 60} minutes and {elapsedTime % 60} seconds.");
        }

        private void btnSavePreferences_Click(object sender, EventArgs e)
        {
            bool isEnabled = cbTimeElapsed.Checked;
            SavePreferences(isEnabled);

            // Update the UI status based on the checkbox state
            lblStatus.Text = isEnabled ? "Notifications Enabled and Saved" : "Notifications Disabled and Saved";

            MessageBox.Show("Preferences saved successfully!");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Ensure notificationsEnabled is respected
            notificationsEnabled = cbTimeElapsed.Checked;

            // Hide the current form and return to the user home page
            this.Hide();
            frmUserHomePage userHomePage = new frmUserHomePage(Program.CurrentUserId);
            userHomePage.Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Ensure timer stops completely if the form is closed
            if (notificationTimer != null)
            {
                notificationTimer.Stop();
                notificationTimer.Dispose();
                notificationTimer = null;
            }
            base.OnFormClosing(e);
        }
    }
}
