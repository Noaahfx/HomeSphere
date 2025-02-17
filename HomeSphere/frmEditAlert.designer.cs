namespace HomeSphere
{
    partial class frmEditAlert
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkMakeActive = new System.Windows.Forms.CheckBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "btnCancel";
            this.btnCancel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(373, 217);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleName = "btnDelete";
            this.btnDelete.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Location = new System.Drawing.Point(270, 219);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(64, 28);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleName = "btnSave";
            this.btnSave.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(165, 219);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 28);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkMakeActive
            // 
            this.chkMakeActive.AccessibleName = "chkMakeActive";
            this.chkMakeActive.AutoSize = true;
            this.chkMakeActive.Font = new System.Drawing.Font("Arial", 10F);
            this.chkMakeActive.Location = new System.Drawing.Point(246, 189);
            this.chkMakeActive.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkMakeActive.Name = "chkMakeActive";
            this.chkMakeActive.Size = new System.Drawing.Size(102, 20);
            this.chkMakeActive.TabIndex = 4;
            this.chkMakeActive.Text = "Make Active";
            this.chkMakeActive.UseVisualStyleBackColor = true;
            // 
            // txtMessage
            // 
            this.txtMessage.AccessibleName = "txtMessage";
            this.txtMessage.Location = new System.Drawing.Point(165, 63);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(272, 54);
            this.txtMessage.TabIndex = 1;
            // 
            // lblMessage
            // 
            this.lblMessage.AccessibleName = "lblMessage";
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblMessage.Location = new System.Drawing.Point(243, 34);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(113, 18);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Alert Message:";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.AccessibleName = "dtpStartTime";
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStartTime.Font = new System.Drawing.Font("Arial", 10F);
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(246, 125);
            this.dtpStartTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(191, 23);
            this.dtpStartTime.TabIndex = 2;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.AccessibleName = "dtpEndTime";
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndTime.Font = new System.Drawing.Font("Arial", 10F);
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(246, 157);
            this.dtpEndTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(191, 23);
            this.dtpEndTime.TabIndex = 3;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AccessibleName = "lblStartTime";
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Arial", 10F);
            this.lblStartTime.Location = new System.Drawing.Point(162, 130);
            this.lblStartTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(76, 16);
            this.lblStartTime.TabIndex = 2;
            this.lblStartTime.Text = "Start Time:";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AccessibleName = "lblEndTime";
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Arial", 10F);
            this.lblEndTime.Location = new System.Drawing.Point(162, 157);
            this.lblEndTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(71, 16);
            this.lblEndTime.TabIndex = 3;
            this.lblEndTime.Text = "End Time:";
            // 
            // frmEditAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 325);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.dtpEndTime);
            this.Controls.Add(this.chkMakeActive);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmEditAlert";
            this.Text = "Edit Alert";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkMakeActive;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblEndTime;


    }
}