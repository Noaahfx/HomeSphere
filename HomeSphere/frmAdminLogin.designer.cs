namespace HomeSphere
{
    partial class frmAdminLogin
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
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lnkLoginAsUser = new System.Windows.Forms.LinkLabel();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbUsername
            // 
            this.tbUsername.AccessibleName = "tbUsername";
            this.tbUsername.Location = new System.Drawing.Point(831, 277);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(196, 31);
            this.tbUsername.TabIndex = 0;
            // 
            // tbPassword
            // 
            this.tbPassword.AccessibleName = "tbPassword";
            this.tbPassword.Location = new System.Drawing.Point(831, 363);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(196, 31);
            this.tbPassword.TabIndex = 1;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(709, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(709, 363);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // btnLogin
            // 
            this.btnLogin.AccessibleName = "btnLogin";
            this.btnLogin.Location = new System.Drawing.Point(796, 420);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(140, 41);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lnkLoginAsUser
            // 
            this.lnkLoginAsUser.AccessibleName = "lnkLoginAsUser";
            this.lnkLoginAsUser.AutoSize = true;
            this.lnkLoginAsUser.Location = new System.Drawing.Point(791, 487);
            this.lnkLoginAsUser.Name = "lnkLoginAsUser";
            this.lnkLoginAsUser.Size = new System.Drawing.Size(145, 25);
            this.lnkLoginAsUser.TabIndex = 5;
            this.lnkLoginAsUser.TabStop = true;
            this.lnkLoginAsUser.Text = "Login as User";
            this.lnkLoginAsUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLoginAsUser_LinkClicked);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleName = "btnExit";
            this.btnExit.Location = new System.Drawing.Point(1467, 15);
            this.btnExit.Margin = new System.Windows.Forms.Padding(6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(254, 52);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit Application";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmAdminLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1735, 816);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lnkLoginAsUser);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUsername);
            this.Name = "frmAdminLogin";
            this.Text = "frmAdminLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel lnkLoginAsUser;
        private System.Windows.Forms.Button btnExit;
    }
}