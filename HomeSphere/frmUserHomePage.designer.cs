namespace HomeSphere
{
    partial class frmUserHomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserHomePage));
            this.lblSettings = new System.Windows.Forms.Label();
            this.lnkNotificationSettings = new System.Windows.Forms.LinkLabel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lnkMFASettings = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSettings
            // 
            this.lblSettings.AccessibleName = "lblSettings";
            this.lblSettings.AutoSize = true;
            this.lblSettings.Location = new System.Drawing.Point(778, 115);
            this.lblSettings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(86, 25);
            this.lblSettings.TabIndex = 0;
            this.lblSettings.Text = "Options";
            // 
            // lnkNotificationSettings
            // 
            this.lnkNotificationSettings.AccessibleName = "lnkNotificationSettings";
            this.lnkNotificationSettings.AutoSize = true;
            this.lnkNotificationSettings.Location = new System.Drawing.Point(724, 160);
            this.lnkNotificationSettings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkNotificationSettings.Name = "lnkNotificationSettings";
            this.lnkNotificationSettings.Size = new System.Drawing.Size(203, 25);
            this.lnkNotificationSettings.TabIndex = 1;
            this.lnkNotificationSettings.TabStop = true;
            this.lnkNotificationSettings.Text = "Notification Settings";
            this.lnkNotificationSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNotificationSettings_LinkClicked);
            // 
            // btnLogout
            // 
            this.btnLogout.AccessibleName = "btnLogout";
            this.btnLogout.Location = new System.Drawing.Point(1468, 15);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(254, 52);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lnkMFASettings
            // 
            this.lnkMFASettings.AccessibleName = "lnkMFASettings";
            this.lnkMFASettings.AutoSize = true;
            this.lnkMFASettings.Location = new System.Drawing.Point(756, 206);
            this.lnkMFASettings.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lnkMFASettings.Name = "lnkMFASettings";
            this.lnkMFASettings.Size = new System.Drawing.Size(141, 25);
            this.lnkMFASettings.TabIndex = 3;
            this.lnkMFASettings.TabStop = true;
            this.lnkMFASettings.Text = "MFA Settings";
            this.lnkMFASettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMFASettings_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AccessibleName = "lnkMFASettings";
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(746, 250);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(168, 25);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "User Dashboard";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1728, 39);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(160, 36);
            this.toolStripButton1.Text = "MFA Settings";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripButton2.Size = new System.Drawing.Size(188, 36);
            this.toolStripButton2.Text = "User Dashboard";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(230, 36);
            this.toolStripButton3.Text = "NotificationSettings";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // frmUserHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1728, 863);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lnkMFASettings);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lnkNotificationSettings);
            this.Controls.Add(this.lblSettings);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmUserHomePage";
            this.Text = "frmUserHomePage";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.LinkLabel lnkNotificationSettings;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.LinkLabel lnkMFASettings;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}