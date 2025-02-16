namespace HomeSphere
{
    partial class frmMFASettings
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

        private void InitializeComponent()
        {
            this.cmbMFAType = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbMFAType
            // 
            this.cmbMFAType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMFAType.FormattingEnabled = true;
            this.cmbMFAType.Location = new System.Drawing.Point(20, 30);
            this.cmbMFAType.Name = "cmbMFAType";
            this.cmbMFAType.Size = new System.Drawing.Size(180, 24);
            this.cmbMFAType.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(20, 80);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(120, 80);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 30);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmMFASettings
            // 
            this.ClientSize = new System.Drawing.Size(249, 147);
            this.Controls.Add(this.cmbMFAType);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnBack);
            this.Name = "frmMFASettings";
            this.Text = "MFA Settings";
            this.Load += new System.EventHandler(this.frmMFASettings_Load);
            this.ResumeLayout(false);

        }


        private System.Windows.Forms.ComboBox cmbMFAType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBack;
    }
}
