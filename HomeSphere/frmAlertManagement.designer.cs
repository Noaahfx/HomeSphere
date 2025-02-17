namespace HomeSphere
{
    partial class frmAlertManagement
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
            this.lblAlertMessage = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.grpSchedule = new System.Windows.Forms.GroupBox();

            ((System.ComponentModel.ISupportInitialize)(this.dgvAlerts)).BeginInit();
            this.SuspendLayout();

            // 
            // lblHeader (Form Title)
            // 
            this.lblHeader.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(20, 10);
            this.lblHeader.Size = new System.Drawing.Size(300, 30);
            this.lblHeader.Text = "Alert Management";

            // 
            // dgvAlerts (Data Grid View)
            // 
            this.dgvAlerts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlerts.Location = new System.Drawing.Point(20, 50);
            this.dgvAlerts.Size = new System.Drawing.Size(800, 250);
            this.dgvAlerts.TabIndex = 0;
            this.dgvAlerts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlerts_CellClick);
            this.dgvAlerts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlerts_CellContentClick);

            // 
            // grpSchedule (Group Box for Scheduling)
            // 
            this.grpSchedule.Location = new System.Drawing.Point(20, 320);
            this.grpSchedule.Size = new System.Drawing.Size(800, 120);
            this.grpSchedule.Text = "Schedule Alert";

            // 
            // lblStartTime (Start Time Label)
            // 
            this.lblStartTime.Location = new System.Drawing.Point(30, 30);
            this.lblStartTime.Text = "Start Time:";
            this.lblStartTime.Font = new System.Drawing.Font("Arial", 10F);

            // 
            // dtpStartTime (Start Time Picker)
            // 
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStartTime.Location = new System.Drawing.Point(130, 27);
            this.dtpStartTime.Size = new System.Drawing.Size(200, 25);
            this.dtpStartTime.Font = new System.Drawing.Font("Arial", 10F);

            // 
            // lblEndTime (End Time Label)
            // 
            this.lblEndTime.Location = new System.Drawing.Point(400, 30);
            this.lblEndTime.Text = "End Time:";
            this.lblEndTime.Font = new System.Drawing.Font("Arial", 10F);

            // 
            // dtpEndTime (End Time Picker)
            // 
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndTime.Location = new System.Drawing.Point(500, 27);
            this.dtpEndTime.Size = new System.Drawing.Size(200, 25);
            this.dtpEndTime.Font = new System.Drawing.Font("Arial", 10F);

            // 
            // lblAlertMessage (Label for Message)
            // 
            this.lblAlertMessage.Location = new System.Drawing.Point(20, 470);
            this.lblAlertMessage.Size = new System.Drawing.Size(150, 20);
            this.lblAlertMessage.Text = "Alert Message:";
            this.lblAlertMessage.Font = new System.Drawing.Font("Arial", 10F);

            // 
            // tbAlertMessage (Alert Message TextBox)
            // 
            this.tbAlertMessage.Location = new System.Drawing.Point(170, 465);
            this.tbAlertMessage.Size = new System.Drawing.Size(500, 25);
            this.tbAlertMessage.Font = new System.Drawing.Font("Arial", 10F);

            // 
            // btnCreate (Create Alert Button)
            // 
            this.btnCreate.Location = new System.Drawing.Point(690, 460);
            this.btnCreate.Size = new System.Drawing.Size(120, 30);
            this.btnCreate.Text = "Create Alert";
            this.btnCreate.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnCreate.BackColor = System.Drawing.Color.Teal;
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);

            // 
            // btnLogout (Back Button)
            // 
            this.btnLogout.Location = new System.Drawing.Point(750, 10);
            this.btnLogout.Size = new System.Drawing.Size(80, 30);
            this.btnLogout.Text = "Back";
            this.btnLogout.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.BackColor = System.Drawing.Color.DarkRed;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // 
            // Add controls to the form
            // 
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.dgvAlerts);
            this.Controls.Add(this.grpSchedule);
            this.Controls.Add(this.lblAlertMessage);
            this.Controls.Add(this.tbAlertMessage);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnLogout);

            this.grpSchedule.Controls.Add(this.lblStartTime);
            this.grpSchedule.Controls.Add(this.dtpStartTime);
            this.grpSchedule.Controls.Add(this.lblEndTime);
            this.grpSchedule.Controls.Add(this.dtpEndTime);

            // 
            // Form Properties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 520);
            this.Text = "Alert Management";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.dgvAlerts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        #endregion

        private System.Windows.Forms.DataGridView dgvAlerts;
        private System.Windows.Forms.TextBox tbAlertMessage;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label lblAlertMessage;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.GroupBox grpSchedule;

    }
}