﻿using System;
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

        private void lnkMFASettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmMFASettings mfaSettings = new frmMFASettings(userId);
            this.Hide();
            mfaSettings.Show();
        }

        private void Products_Click(object sender, EventArgs e)
        {
            frmProductPage frmproductpage = new frmProductPage();
            this.Hide();
            frmproductpage.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmMFASettings mfaSettings = new frmMFASettings(userId);
            this.Hide();
            mfaSettings.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            UserDashboard userdashboard = new UserDashboard(userId);
            this.Hide();
            userdashboard.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmNotificationPreferences notificationPreferences = new frmNotificationPreferences(userId);
            this.Hide();
            notificationPreferences.Show();
        }

        private void lnkManageDevices_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmManageDevices manageDevicesForm = new frmManageDevices(userId);
            manageDevicesForm.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frmManageDevices manageDevicesForm = new frmManageDevices(userId);
            manageDevicesForm.Show();
        }

        private void lnkUserDashboard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserDashboard userdashboard = new UserDashboard(userId);
            this.Hide();
            userdashboard.Show();
        }
    }
}
