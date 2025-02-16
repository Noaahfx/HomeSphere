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
            this.lblSettings = new System.Windows.Forms.Label();
            this.lnkNotificationSettings = new System.Windows.Forms.LinkLabel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lnkMFASettings = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblSettings
            // 
            this.lblSettings.AccessibleName = "lblSettings";
            this.lblSettings.AutoSize = true;
            this.lblSettings.Location = new System.Drawing.Point(389, 60);
            this.lblSettings.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(45, 13);
            this.lblSettings.TabIndex = 0;
            this.lblSettings.Text = "Settings";
            // 
            // lnkNotificationSettings
            // 
            this.lnkNotificationSettings.AccessibleName = "lnkNotificationSettings";
            this.lnkNotificationSettings.AutoSize = true;
            this.lnkNotificationSettings.Location = new System.Drawing.Point(362, 83);
            this.lnkNotificationSettings.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkNotificationSettings.Name = "lnkNotificationSettings";
            this.lnkNotificationSettings.Size = new System.Drawing.Size(101, 13);
            this.lnkNotificationSettings.TabIndex = 1;
            this.lnkNotificationSettings.TabStop = true;
            this.lnkNotificationSettings.Text = "Notification Settings";
            this.lnkNotificationSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNotificationSettings_LinkClicked);
            // 
            // btnLogout
            // 
            this.btnLogout.AccessibleName = "btnLogout";
            this.btnLogout.Location = new System.Drawing.Point(734, 8);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(127, 27);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lnkMFASettings
            // 
            this.lnkMFASettings.AccessibleName = "lnkMFASettings";
            this.lnkMFASettings.AutoSize = true;
            this.lnkMFASettings.Location = new System.Drawing.Point(378, 107);
            this.lnkMFASettings.Name = "lnkMFASettings";
            this.lnkMFASettings.Size = new System.Drawing.Size(70, 13);
            this.lnkMFASettings.TabIndex = 3;
            this.lnkMFASettings.TabStop = true;
            this.lnkMFASettings.Text = "MFA Settings";
            this.lnkMFASettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMFASettings_LinkClicked);
            // 
            // frmUserHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 449);
            this.Controls.Add(this.lnkMFASettings);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lnkNotificationSettings);
            this.Controls.Add(this.lblSettings);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmUserHomePage";
            this.Text = "frmUserHomePage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.LinkLabel lnkNotificationSettings;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.LinkLabel lnkMFASettings;

    }
}