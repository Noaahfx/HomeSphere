namespace HomeSphere
{
    partial class frmUserHomePage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblSettings = new System.Windows.Forms.Label();
            this.lnkNotificationSettings = new System.Windows.Forms.LinkLabel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lnkMFASettings = new System.Windows.Forms.LinkLabel();
            this.lnkUserDashboard = new System.Windows.Forms.LinkLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.lnkManageDevices = new System.Windows.Forms.LinkLabel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSettings
            // 
            this.lblSettings.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblSettings.Location = new System.Drawing.Point(422, 177);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(418, 79);
            this.lblSettings.TabIndex = 0;
            this.lblSettings.Text = "User Settings";
            this.lblSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnkNotificationSettings
            // 
            this.lnkNotificationSettings.AutoSize = true;
            this.lnkNotificationSettings.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lnkNotificationSettings.ForeColor = System.Drawing.Color.Teal;
            this.lnkNotificationSettings.LinkColor = System.Drawing.Color.Teal;
            this.lnkNotificationSettings.Location = new System.Drawing.Point(446, 293);
            this.lnkNotificationSettings.Name = "lnkNotificationSettings";
            this.lnkNotificationSettings.Size = new System.Drawing.Size(394, 51);
            this.lnkNotificationSettings.TabIndex = 1;
            this.lnkNotificationSettings.TabStop = true;
            this.lnkNotificationSettings.Text = "Notification Settings";
            this.lnkNotificationSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNotificationSettings_LinkClicked);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Red;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(971, 80);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(259, 71);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lnkMFASettings
            // 
            this.lnkMFASettings.AutoSize = true;
            this.lnkMFASettings.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lnkMFASettings.ForeColor = System.Drawing.Color.Teal;
            this.lnkMFASettings.LinkColor = System.Drawing.Color.Teal;
            this.lnkMFASettings.Location = new System.Drawing.Point(496, 343);
            this.lnkMFASettings.Name = "lnkMFASettings";
            this.lnkMFASettings.Size = new System.Drawing.Size(260, 51);
            this.lnkMFASettings.TabIndex = 2;
            this.lnkMFASettings.TabStop = true;
            this.lnkMFASettings.Text = "MFA Settings";
            this.lnkMFASettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMFASettings_LinkClicked);
            // 
            // lnkUserDashboard
            // 
            this.lnkUserDashboard.AutoSize = true;
            this.lnkUserDashboard.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lnkUserDashboard.ForeColor = System.Drawing.Color.Teal;
            this.lnkUserDashboard.LinkColor = System.Drawing.Color.Teal;
            this.lnkUserDashboard.Location = new System.Drawing.Point(466, 393);
            this.lnkUserDashboard.Name = "lnkUserDashboard";
            this.lnkUserDashboard.Size = new System.Drawing.Size(306, 51);
            this.lnkUserDashboard.TabIndex = 3;
            this.lnkUserDashboard.TabStop = true;
            this.lnkUserDashboard.Text = "User Dashboard";
            this.lnkUserDashboard.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUserDashboard_LinkClicked);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.toolStrip1.ForeColor = System.Drawing.Color.White;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1320, 52);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "Navigation";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(223, 49);
            this.toolStripButton1.Text = "MFA Settings";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripButton2.ForeColor = System.Drawing.Color.White;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(264, 49);
            this.toolStripButton2.Text = "User Dashboard";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripButton3.ForeColor = System.Drawing.Color.White;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(333, 49);
            this.toolStripButton3.Text = "Notification Settings";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripButton4.ForeColor = System.Drawing.Color.White;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(267, 49);
            this.toolStripButton4.Text = "Manage Devices";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // lnkManageDevices
            // 
            this.lnkManageDevices.AutoSize = true;
            this.lnkManageDevices.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lnkManageDevices.ForeColor = System.Drawing.Color.Teal;
            this.lnkManageDevices.LinkColor = System.Drawing.Color.Teal;
            this.lnkManageDevices.Location = new System.Drawing.Point(436, 443);
            this.lnkManageDevices.Name = "lnkManageDevices";
            this.lnkManageDevices.Size = new System.Drawing.Size(430, 51);
            this.lnkManageDevices.TabIndex = 4;
            this.lnkManageDevices.TabStop = true;
            this.lnkManageDevices.Text = "Manage Saved Devices";
            this.lnkManageDevices.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkManageDevices_LinkClicked);
            // 
            // frmUserHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1320, 632);
            this.Controls.Add(this.lblSettings);
            this.Controls.Add(this.lnkNotificationSettings);
            this.Controls.Add(this.lnkMFASettings);
            this.Controls.Add(this.lnkUserDashboard);
            this.Controls.Add(this.lnkManageDevices);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.toolStrip1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmUserHomePage";
            this.Text = "User Home - Smart System";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.LinkLabel lnkNotificationSettings, lnkMFASettings, lnkUserDashboard, lnkManageDevices;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1, toolStripButton2, toolStripButton3, toolStripButton4;
    }
}
