﻿namespace HomeSphere
{
    partial class frmVerifyOTP
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

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.tbOTP = new System.Windows.Forms.TextBox();
            this.btnVerifyOTP = new System.Windows.Forms.Button();
            this.btnResendOTP = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(247, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(430, 96);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Verify OTP";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInstruction
            // 
            this.lblInstruction.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblInstruction.ForeColor = System.Drawing.Color.LightGray;
            this.lblInstruction.Location = new System.Drawing.Point(190, 136);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(549, 67);
            this.lblInstruction.TabIndex = 1;
            this.lblInstruction.Text = "Enter the OTP sent to your email:";
            this.lblInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbOTP
            // 
            this.tbOTP.BackColor = System.Drawing.Color.White;
            this.tbOTP.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tbOTP.ForeColor = System.Drawing.Color.Black;
            this.tbOTP.Location = new System.Drawing.Point(355, 206);
            this.tbOTP.Name = "tbOTP";
            this.tbOTP.Size = new System.Drawing.Size(218, 50);
            this.tbOTP.TabIndex = 2;
            this.tbOTP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnVerifyOTP
            // 
            this.btnVerifyOTP.BackColor = System.Drawing.Color.Teal;
            this.btnVerifyOTP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerifyOTP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnVerifyOTP.ForeColor = System.Drawing.Color.White;
            this.btnVerifyOTP.Location = new System.Drawing.Point(198, 286);
            this.btnVerifyOTP.Name = "btnVerifyOTP";
            this.btnVerifyOTP.Size = new System.Drawing.Size(234, 59);
            this.btnVerifyOTP.TabIndex = 3;
            this.btnVerifyOTP.Text = "Verify OTP";
            this.btnVerifyOTP.UseVisualStyleBackColor = false;
            this.btnVerifyOTP.Click += new System.EventHandler(this.btnVerifyOTP_Click);
            // 
            // btnResendOTP
            // 
            this.btnResendOTP.BackColor = System.Drawing.Color.Orange;
            this.btnResendOTP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResendOTP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnResendOTP.ForeColor = System.Drawing.Color.White;
            this.btnResendOTP.Location = new System.Drawing.Point(506, 286);
            this.btnResendOTP.Name = "btnResendOTP";
            this.btnResendOTP.Size = new System.Drawing.Size(233, 59);
            this.btnResendOTP.TabIndex = 4;
            this.btnResendOTP.Text = "Resend OTP";
            this.btnResendOTP.UseVisualStyleBackColor = false;
            this.btnResendOTP.Click += new System.EventHandler(this.btnResendOTP_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Red;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(722, 40);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(155, 59);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmVerifyOTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(918, 527);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.tbOTP);
            this.Controls.Add(this.btnVerifyOTP);
            this.Controls.Add(this.btnResendOTP);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmVerifyOTP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verify OTP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.TextBox tbOTP;
        private System.Windows.Forms.Button btnVerifyOTP;
        private System.Windows.Forms.Button btnResendOTP;
        private System.Windows.Forms.Button btnBack;
    }
}
