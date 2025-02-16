namespace HomeSphere
{
    partial class frmVerifyOTP
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
            this.lblInstruction = new System.Windows.Forms.Label();
            this.tbOTP = new System.Windows.Forms.TextBox();
            this.btnVerifyOTP = new System.Windows.Forms.Button();
            this.btnResendOTP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInstruction
            // 
            this.lblInstruction.AccessibleName = "lblInstruction";
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Location = new System.Drawing.Point(170, 50);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(163, 13);
            this.lblInstruction.TabIndex = 0;
            this.lblInstruction.Text = "Enter the OTP sent to your email:";
            // 
            // tbOTP
            // 
            this.tbOTP.AccessibleName = "tbOTP";
            this.tbOTP.Location = new System.Drawing.Point(203, 75);
            this.tbOTP.Name = "tbOTP";
            this.tbOTP.Size = new System.Drawing.Size(100, 20);
            this.tbOTP.TabIndex = 1;
            // 
            // btnVerifyOTP
            // 
            this.btnVerifyOTP.AccessibleName = "btnVerifyOTP";
            this.btnVerifyOTP.Location = new System.Drawing.Point(173, 107);
            this.btnVerifyOTP.Name = "btnVerifyOTP";
            this.btnVerifyOTP.Size = new System.Drawing.Size(75, 23);
            this.btnVerifyOTP.TabIndex = 2;
            this.btnVerifyOTP.Text = "Verify OTP";
            this.btnVerifyOTP.UseVisualStyleBackColor = true;
            this.btnVerifyOTP.Click += new System.EventHandler(this.btnVerifyOTP_Click);
            // 
            // btnResendOTP
            // 
            this.btnResendOTP.AccessibleName = "btnResendOTP";
            this.btnResendOTP.Location = new System.Drawing.Point(258, 107);
            this.btnResendOTP.Name = "btnResendOTP";
            this.btnResendOTP.Size = new System.Drawing.Size(75, 23);
            this.btnResendOTP.TabIndex = 3;
            this.btnResendOTP.Text = "Resend OTP";
            this.btnResendOTP.UseVisualStyleBackColor = true;
            this.btnResendOTP.Click += new System.EventHandler(this.btnResendOTP_Click);
            // 
            // frmVerifyOTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 338);
            this.Controls.Add(this.btnResendOTP);
            this.Controls.Add(this.btnVerifyOTP);
            this.Controls.Add(this.tbOTP);
            this.Controls.Add(this.lblInstruction);
            this.Name = "frmVerifyOTP";
            this.Text = "frmVerifyOTP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.TextBox tbOTP;
        private System.Windows.Forms.Button btnVerifyOTP;
        private System.Windows.Forms.Button btnResendOTP;
    }
}