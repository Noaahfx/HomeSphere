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
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "btnCancel";
            this.btnCancel.Location = new System.Drawing.Point(939, 351);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 42);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleName = "btnDelete";
            this.btnDelete.Location = new System.Drawing.Point(669, 351);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 42);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleName = "btnSave";
            this.btnSave.Location = new System.Drawing.Point(804, 351);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 42);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkMakeActive
            // 
            this.chkMakeActive.AccessibleName = "chkMakeActive";
            this.chkMakeActive.AutoSize = true;
            this.chkMakeActive.Location = new System.Drawing.Point(775, 297);
            this.chkMakeActive.Name = "chkMakeActive";
            this.chkMakeActive.Size = new System.Drawing.Size(162, 29);
            this.chkMakeActive.TabIndex = 8;
            this.chkMakeActive.Text = "Make Active";
            this.chkMakeActive.UseVisualStyleBackColor = true;
            // 
            // txtMessage
            // 
            this.txtMessage.AccessibleName = "txtMessage";
            this.txtMessage.Location = new System.Drawing.Point(669, 151);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(392, 130);
            this.txtMessage.TabIndex = 7;
            // 
            // lblMessage
            // 
            this.lblMessage.AccessibleName = "lblMessage";
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(779, 105);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(149, 25);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = "Edit Message:";
            // 
            // frmEditAlerts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1737, 706);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkMakeActive);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblMessage);
            this.Name = "frmEditAlerts";
            this.Text = "frmEditAlerts";
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
    }
}