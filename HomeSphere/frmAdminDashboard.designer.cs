namespace HomeSphere
{
    partial class frmAdminDashboard
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
            this.dgvAlerts = new System.Windows.Forms.DataGridView();
            this.tbAlertMessage = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlerts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAlerts
            // 
            this.dgvAlerts.AccessibleName = "dgvAlerts";
            this.dgvAlerts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlerts.Location = new System.Drawing.Point(400, 165);
            this.dgvAlerts.Name = "dgvAlerts";
            this.dgvAlerts.RowTemplate.Height = 33;
            this.dgvAlerts.Size = new System.Drawing.Size(888, 307);
            this.dgvAlerts.TabIndex = 0;
            this.dgvAlerts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlerts_CellClick);
            // 
            // tbAlertMessage
            // 
            this.tbAlertMessage.AccessibleName = "tbAlertMessage";
            this.tbAlertMessage.Location = new System.Drawing.Point(561, 549);
            this.tbAlertMessage.Name = "tbAlertMessage";
            this.tbAlertMessage.Size = new System.Drawing.Size(564, 31);
            this.tbAlertMessage.TabIndex = 1;
            // 
            // btnCreate
            // 
            this.btnCreate.AccessibleName = "btnCreate";
            this.btnCreate.Location = new System.Drawing.Point(1150, 544);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(145, 41);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Create Alert";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.AccessibleName = "btnLogout";
            this.btnLogout.Location = new System.Drawing.Point(1467, 15);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(6);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(254, 52);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Back";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(390, 549);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Alert Message:";
            // 
            // frmAdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1741, 832);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.tbAlertMessage);
            this.Controls.Add(this.dgvAlerts);
            this.Name = "frmAdminDashboard";
            this.Text = "frmAdminDashboard";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlerts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAlerts;
        private System.Windows.Forms.TextBox tbAlertMessage;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label1;
    }
}