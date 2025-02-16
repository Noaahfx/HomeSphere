namespace HomeSphere
{
    partial class frmEmailVerification
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
            this.btnResendOTP = new System.Windows.Forms.Button();
            this.btnVerifyOTP = new System.Windows.Forms.Button();
            this.tbOTP = new System.Windows.Forms.TextBox();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnResendOTP
            // 
            this.btnResendOTP.AccessibleName = "btnResendOTP";
            this.btnResendOTP.Location = new System.Drawing.Point(298, 142);
            this.btnResendOTP.Name = "btnResendOTP";
            this.btnResendOTP.Size = new System.Drawing.Size(75, 23);
            this.btnResendOTP.TabIndex = 7;
            this.btnResendOTP.Text = "Resend OTP";
            this.btnResendOTP.UseVisualStyleBackColor = true;
            this.btnResendOTP.Click += new System.EventHandler(this.btnResendOTP_Click);
            // 
            // btnVerifyOTP
            // 
            this.btnVerifyOTP.AccessibleName = "btnVerifyOTP";
            this.btnVerifyOTP.Location = new System.Drawing.Point(213, 142);
            this.btnVerifyOTP.Name = "btnVerifyOTP";
            this.btnVerifyOTP.Size = new System.Drawing.Size(75, 23);
            this.btnVerifyOTP.TabIndex = 6;
            this.btnVerifyOTP.Text = "Verify OTP";
            this.btnVerifyOTP.UseVisualStyleBackColor = true;
            this.btnVerifyOTP.Click += new System.EventHandler(this.btnVerifyOTP_Click);
            // 
            // tbOTP
            // 
            this.tbOTP.AccessibleName = "tbOTP";
            this.tbOTP.Location = new System.Drawing.Point(243, 110);
            this.tbOTP.Name = "tbOTP";
            this.tbOTP.Size = new System.Drawing.Size(100, 20);
            this.tbOTP.TabIndex = 5;
            // 
            // lblInstruction
            // 
            this.lblInstruction.AccessibleName = "lblInstruction";
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Location = new System.Drawing.Point(210, 85);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(163, 13);
            this.lblInstruction.TabIndex = 4;
            this.lblInstruction.Text = "Enter the OTP sent to your email:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Email Verification";
            // 
            // frmEmailVerification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 396);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnResendOTP);
            this.Controls.Add(this.btnVerifyOTP);
            this.Controls.Add(this.tbOTP);
            this.Controls.Add(this.lblInstruction);
            this.Name = "frmEmailVerification";
            this.Text = "frmEmailVerification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnResendOTP;
        private System.Windows.Forms.Button btnVerifyOTP;
        private System.Windows.Forms.TextBox tbOTP;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Label label1;
    }
}