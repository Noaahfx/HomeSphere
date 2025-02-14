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
            this.SuspendLayout();
            // 
            // lblSettings
            // 
            this.lblSettings.AccessibleName = "lblSettings";
            this.lblSettings.AutoSize = true;
            this.lblSettings.Location = new System.Drawing.Point(778, 116);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(90, 25);
            this.lblSettings.TabIndex = 0;
            this.lblSettings.Text = "Settings";
            // 
            // lnkNotificationSettings
            // 
            this.lnkNotificationSettings.AccessibleName = "lnkNotificationSettings";
            this.lnkNotificationSettings.AutoSize = true;
            this.lnkNotificationSettings.Location = new System.Drawing.Point(723, 159);
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
            this.btnLogout.Location = new System.Drawing.Point(1467, 15);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(6);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(254, 52);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // frmUserHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1727, 864);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lnkNotificationSettings);
            this.Controls.Add(this.lblSettings);
            this.Name = "frmUserHomePage";
            this.Text = "frmUserHomePage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.LinkLabel lnkNotificationSettings;
        private System.Windows.Forms.Button btnLogout;
    }
}