namespace HomeSphere
{
    partial class frmAdminHomePage
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
            this.btnLogout = new System.Windows.Forms.Button();
            this.lnkAlertManagement = new System.Windows.Forms.LinkLabel();
            this.lblSettings = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.AccessibleName = "btnLogout";
            this.btnLogout.Location = new System.Drawing.Point(1467, 15);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(6);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(254, 52);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lnkAlertManagement
            // 
            this.lnkAlertManagement.AccessibleName = "lnkAlertManagement";
            this.lnkAlertManagement.AutoSize = true;
            this.lnkAlertManagement.Location = new System.Drawing.Point(750, 159);
            this.lnkAlertManagement.Name = "lnkAlertManagement";
            this.lnkAlertManagement.Size = new System.Drawing.Size(187, 25);
            this.lnkAlertManagement.TabIndex = 4;
            this.lnkAlertManagement.TabStop = true;
            this.lnkAlertManagement.Text = "Alert Management";
            this.lnkAlertManagement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAlertManagement_LinkClicked);
            // 
            // lblSettings
            // 
            this.lblSettings.AccessibleName = "lblSettings";
            this.lblSettings.AutoSize = true;
            this.lblSettings.Location = new System.Drawing.Point(795, 119);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(90, 25);
            this.lblSettings.TabIndex = 3;
            this.lblSettings.Text = "Settings";
            // 
            // frmAdminHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1736, 870);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lnkAlertManagement);
            this.Controls.Add(this.lblSettings);
            this.Name = "frmAdminHomePage";
            this.Text = "frmAdminHomePage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.LinkLabel lnkAlertManagement;
        private System.Windows.Forms.Label lblSettings;
    }
}