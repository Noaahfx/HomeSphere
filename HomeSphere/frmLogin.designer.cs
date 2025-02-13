namespace HomeSphere
{
    partial class frmLogin
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
            this.lblEmail = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.btnSendOTP = new System.Windows.Forms.Button();
            this.lblOTP = new System.Windows.Forms.Label();
            this.tbOTP = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.cbSaveDevice = new System.Windows.Forms.CheckBox();
            this.lnkLoginAsAdmin = new System.Windows.Forms.LinkLabel();
            this.btnLoginWithoutOTP = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLoginForSavedDevice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEmail
            // 
            this.lblEmail.AccessibleName = "lblEmail";
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(583, 196);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(71, 25);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "Email:";
            // 
            // tbEmail
            // 
            this.tbEmail.AccessibleName = "tbEmail";
            this.tbEmail.Location = new System.Drawing.Point(665, 183);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(6);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(496, 31);
            this.tbEmail.TabIndex = 1;
            // 
            // btnSendOTP
            // 
            this.btnSendOTP.AccessibleName = "btnSendOTP";
            this.btnSendOTP.Location = new System.Drawing.Point(715, 331);
            this.btnSendOTP.Margin = new System.Windows.Forms.Padding(6);
            this.btnSendOTP.Name = "btnSendOTP";
            this.btnSendOTP.Size = new System.Drawing.Size(338, 60);
            this.btnSendOTP.TabIndex = 2;
            this.btnSendOTP.Text = "Send OTP";
            this.btnSendOTP.UseVisualStyleBackColor = true;
            this.btnSendOTP.Click += new System.EventHandler(this.btnSendOTP_Click);
            // 
            // lblOTP
            // 
            this.lblOTP.AccessibleName = "lblOTP";
            this.lblOTP.AutoSize = true;
            this.lblOTP.Location = new System.Drawing.Point(589, 491);
            this.lblOTP.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblOTP.Name = "lblOTP";
            this.lblOTP.Size = new System.Drawing.Size(61, 25);
            this.lblOTP.TabIndex = 3;
            this.lblOTP.Text = "OTP:";
            // 
            // tbOTP
            // 
            this.tbOTP.AccessibleName = "tbOTP";
            this.tbOTP.Location = new System.Drawing.Point(667, 475);
            this.tbOTP.Margin = new System.Windows.Forms.Padding(6);
            this.tbOTP.Name = "tbOTP";
            this.tbOTP.Size = new System.Drawing.Size(494, 31);
            this.tbOTP.TabIndex = 4;
            // 
            // btnLogin
            // 
            this.btnLogin.AccessibleName = "btnLogin";
            this.btnLogin.Location = new System.Drawing.Point(715, 560);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(6);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(338, 63);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // cbSaveDevice
            // 
            this.cbSaveDevice.AccessibleName = "cbSaveDevice";
            this.cbSaveDevice.AutoSize = true;
            this.cbSaveDevice.Location = new System.Drawing.Point(785, 652);
            this.cbSaveDevice.Margin = new System.Windows.Forms.Padding(6);
            this.cbSaveDevice.Name = "cbSaveDevice";
            this.cbSaveDevice.Size = new System.Drawing.Size(202, 29);
            this.cbSaveDevice.TabIndex = 6;
            this.cbSaveDevice.Text = "Save this device";
            this.cbSaveDevice.UseVisualStyleBackColor = true;
            // 
            // lnkLoginAsAdmin
            // 
            this.lnkLoginAsAdmin.AccessibleName = "lnkLoginAsAdmin";
            this.lnkLoginAsAdmin.AutoSize = true;
            this.lnkLoginAsAdmin.Location = new System.Drawing.Point(806, 732);
            this.lnkLoginAsAdmin.Name = "lnkLoginAsAdmin";
            this.lnkLoginAsAdmin.Size = new System.Drawing.Size(160, 25);
            this.lnkLoginAsAdmin.TabIndex = 7;
            this.lnkLoginAsAdmin.TabStop = true;
            this.lnkLoginAsAdmin.Text = "Login as Admin";
            this.lnkLoginAsAdmin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLoginAsAdmin_LinkClicked);
            // 
            // btnLoginWithoutOTP
            // 
            this.btnLoginWithoutOTP.AccessibleName = "btnLoginWithoutOTP";
            this.btnLoginWithoutOTP.Location = new System.Drawing.Point(1188, 174);
            this.btnLoginWithoutOTP.Name = "btnLoginWithoutOTP";
            this.btnLoginWithoutOTP.Size = new System.Drawing.Size(234, 48);
            this.btnLoginWithoutOTP.TabIndex = 8;
            this.btnLoginWithoutOTP.Text = "Login Without OTP";
            this.btnLoginWithoutOTP.UseVisualStyleBackColor = true;
            this.btnLoginWithoutOTP.Click += new System.EventHandler(this.btnLoginWithoutOTP_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleName = "btnExit";
            this.btnExit.Location = new System.Drawing.Point(1467, 15);
            this.btnExit.Margin = new System.Windows.Forms.Padding(6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(254, 52);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit Application";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLoginForSavedDevice
            // 
            this.btnLoginForSavedDevice.AccessibleName = "btnLoginForSavedDevice";
            this.btnLoginForSavedDevice.Location = new System.Drawing.Point(715, 248);
            this.btnLoginForSavedDevice.Name = "btnLoginForSavedDevice";
            this.btnLoginForSavedDevice.Size = new System.Drawing.Size(338, 60);
            this.btnLoginForSavedDevice.TabIndex = 10;
            this.btnLoginForSavedDevice.Text = "Login for Saved Device";
            this.btnLoginForSavedDevice.UseVisualStyleBackColor = true;
            this.btnLoginForSavedDevice.Click += new System.EventHandler(this.btnLoginForSavedDevice_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1735, 816);
            this.Controls.Add(this.btnLoginForSavedDevice);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLoginWithoutOTP);
            this.Controls.Add(this.lnkLoginAsAdmin);
            this.Controls.Add(this.cbSaveDevice);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbOTP);
            this.Controls.Add(this.lblOTP);
            this.Controls.Add(this.btnSendOTP);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lblEmail);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmLogin";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Button btnSendOTP;
        private System.Windows.Forms.Label lblOTP;
        private System.Windows.Forms.TextBox tbOTP;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox cbSaveDevice;
        private System.Windows.Forms.LinkLabel lnkLoginAsAdmin;
        private System.Windows.Forms.Button btnLoginWithoutOTP;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLoginForSavedDevice;
    }
}

