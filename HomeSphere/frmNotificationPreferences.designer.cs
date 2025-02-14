namespace HomeSphere
{
    partial class frmNotificationPreferences
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
            this.cbTimeElapsed = new System.Windows.Forms.CheckBox();
            this.btnSavePreferences = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.Noti = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbTimeElapsed
            // 
            this.cbTimeElapsed.AccessibleName = "cbTimeElapsed";
            this.cbTimeElapsed.AutoSize = true;
            this.cbTimeElapsed.Location = new System.Drawing.Point(702, 208);
            this.cbTimeElapsed.Margin = new System.Windows.Forms.Padding(6);
            this.cbTimeElapsed.Name = "cbTimeElapsed";
            this.cbTimeElapsed.Size = new System.Drawing.Size(372, 29);
            this.cbTimeElapsed.TabIndex = 0;
            this.cbTimeElapsed.Text = "Enable Time Elapsed Notifications";
            this.cbTimeElapsed.UseVisualStyleBackColor = true;
            // 
            // btnSavePreferences
            // 
            this.btnSavePreferences.AccessibleName = "btnSavePreferences";
            this.btnSavePreferences.Location = new System.Drawing.Point(762, 281);
            this.btnSavePreferences.Margin = new System.Windows.Forms.Padding(6);
            this.btnSavePreferences.Name = "btnSavePreferences";
            this.btnSavePreferences.Size = new System.Drawing.Size(254, 44);
            this.btnSavePreferences.TabIndex = 1;
            this.btnSavePreferences.Text = "Save Preferences";
            this.btnSavePreferences.UseVisualStyleBackColor = true;
            this.btnSavePreferences.Click += new System.EventHandler(this.btnSavePreferences_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.AccessibleName = "btnLogout";
            this.btnLogout.Location = new System.Drawing.Point(1467, 15);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(6);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(254, 52);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Back";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AccessibleName = "lblStatus";
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(1428, 91);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(79, 25);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status:";
            // 
            // Noti
            // 
            this.Noti.AccessibleName = "Noti";
            this.Noti.AutoSize = true;
            this.Noti.Location = new System.Drawing.Point(788, 141);
            this.Noti.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Noti.Name = "Noti";
            this.Noti.Size = new System.Drawing.Size(203, 25);
            this.Noti.TabIndex = 5;
            this.Noti.Text = "Notification Settings";
            // 
            // frmNotificationPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1736, 816);
            this.Controls.Add(this.Noti);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnSavePreferences);
            this.Controls.Add(this.cbTimeElapsed);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmNotificationPreferences";
            this.Text = "frmNotificationPreferences";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbTimeElapsed;
        private System.Windows.Forms.Button btnSavePreferences;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label Noti;
    }
}