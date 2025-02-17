namespace HomeSphere
{
    partial class frmManageDevices
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDevices = new System.Windows.Forms.DataGridView();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.btnRenameDevice = new System.Windows.Forms.Button();
            this.btnDeleteDevice = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDevices
            // 
            this.dgvDevices.BackgroundColor = System.Drawing.Color.White;
            this.dgvDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDevices.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDevices.GridColor = System.Drawing.Color.LightGray;
            this.dgvDevices.Location = new System.Drawing.Point(60, 111);
            this.dgvDevices.Name = "dgvDevices";
            this.dgvDevices.Size = new System.Drawing.Size(783, 300);
            this.dgvDevices.TabIndex = 1;
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDeviceName.ForeColor = System.Drawing.Color.Gray;
            this.txtDeviceName.Location = new System.Drawing.Point(60, 435);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.Size = new System.Drawing.Size(402, 50);
            this.txtDeviceName.TabIndex = 2;
            this.txtDeviceName.Text = "Enter new device name...";
            this.txtDeviceName.GotFocus += new System.EventHandler(this.txtDeviceName_GotFocus);
            this.txtDeviceName.LostFocus += new System.EventHandler(this.txtDeviceName_LostFocus);
            // 
            // btnRenameDevice
            // 
            this.btnRenameDevice.BackColor = System.Drawing.Color.Teal;
            this.btnRenameDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenameDevice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRenameDevice.ForeColor = System.Drawing.Color.White;
            this.btnRenameDevice.Location = new System.Drawing.Point(478, 435);
            this.btnRenameDevice.Name = "btnRenameDevice";
            this.btnRenameDevice.Size = new System.Drawing.Size(166, 50);
            this.btnRenameDevice.TabIndex = 3;
            this.btnRenameDevice.Text = "Rename";
            this.btnRenameDevice.UseVisualStyleBackColor = false;
            this.btnRenameDevice.Click += new System.EventHandler(this.btnRenameDevice_Click);
            // 
            // btnDeleteDevice
            // 
            this.btnDeleteDevice.BackColor = System.Drawing.Color.Red;
            this.btnDeleteDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteDevice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDeleteDevice.ForeColor = System.Drawing.Color.White;
            this.btnDeleteDevice.Location = new System.Drawing.Point(677, 435);
            this.btnDeleteDevice.Name = "btnDeleteDevice";
            this.btnDeleteDevice.Size = new System.Drawing.Size(166, 50);
            this.btnDeleteDevice.TabIndex = 4;
            this.btnDeleteDevice.Text = "Delete";
            this.btnDeleteDevice.UseVisualStyleBackColor = false;
            this.btnDeleteDevice.Click += new System.EventHandler(this.btnDeleteDevice_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Gray;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(862, 24);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 54);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(61, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(782, 99);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Manage Your Devices";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmManageDevices
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1060, 640);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvDevices);
            this.Controls.Add(this.txtDeviceName);
            this.Controls.Add(this.btnRenameDevice);
            this.Controls.Add(this.btnDeleteDevice);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmManageDevices";
            this.Text = "Manage Devices";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDevices;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.Button btnRenameDevice;
        private System.Windows.Forms.Button btnDeleteDevice;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
    }
}
