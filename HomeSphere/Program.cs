using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace HomeSphere
{
    static class Program
    {
        public static string SessionId = Guid.NewGuid().ToString();
        public static int CurrentUserId { get; set; } = -1; // Default to -1 if no user is logged in
        private static Timer globalNotificationTimer;
        private static bool notificationsEnabled;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            InitializeGlobalNotificationTimer();
            Application.Run(new Form1());
        }

        public static void InitializeGlobalNotificationTimer()
        {
            globalNotificationTimer = new Timer { Interval = 10000 }; // 10 seconds
            globalNotificationTimer.Tick += GlobalNotificationTimer_Tick;
        }

        public static void StartNotifications()
        {
            // Load the user's notification preferences and start the timer if enabled
            LoadNotificationPreferences();
            if (notificationsEnabled)
            {
                globalNotificationTimer.Start();
            }
        }

        public static void StopNotifications()
        {
            // Stop the timer and reset the flag
            globalNotificationTimer.Stop();
            notificationsEnabled = false;
        }

        private static void LoadNotificationPreferences()
        {
            if (CurrentUserId == -1)
                return; // No user is logged in

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT IsEnabled FROM UserPreferences WHERE UserID = @UserID AND NotificationType = 'Time Elapsed Notification'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", CurrentUserId);
                        object result = cmd.ExecuteScalar();
                        notificationsEnabled = result != null && Convert.ToBoolean(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading notification preferences: {ex.Message}");
                notificationsEnabled = false; // Default to disabled on error
            }
        }

        private static void GlobalNotificationTimer_Tick(object sender, EventArgs e)
        {
            if (!notificationsEnabled)
                return; // Do nothing if notifications are disabled

            // Display the global notification
            MessageBox.Show($"App has been open for another 10 seconds for user ID: {CurrentUserId}.");
        }
    }
}
