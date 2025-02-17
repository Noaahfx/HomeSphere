namespace HomeSphere
{
    partial class DayEnergyPromptForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelDayEnergy = new System.Windows.Forms.Button();
            this.btnConfirmDayEnergy = new System.Windows.Forms.Button();
            this.cmbDayEnergyOptions = new System.Windows.Forms.ComboBox();
            this.dtpDaySelector = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(90, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Type of View";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Pick the day you want to see";
            // 
            // btnCancelDayEnergy
            // 
            this.btnCancelDayEnergy.AccessibleName = "btnCancelDayEnergy";
            this.btnCancelDayEnergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelDayEnergy.Location = new System.Drawing.Point(158, 202);
            this.btnCancelDayEnergy.Name = "btnCancelDayEnergy";
            this.btnCancelDayEnergy.Size = new System.Drawing.Size(85, 32);
            this.btnCancelDayEnergy.TabIndex = 15;
            this.btnCancelDayEnergy.Text = "Cancel";
            this.btnCancelDayEnergy.UseVisualStyleBackColor = true;
            this.btnCancelDayEnergy.Click += new System.EventHandler(this.btnCancelDayEnergy_Click);
            // 
            // btnConfirmDayEnergy
            // 
            this.btnConfirmDayEnergy.AccessibleName = "btnConfirmDayEnergy";
            this.btnConfirmDayEnergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmDayEnergy.Location = new System.Drawing.Point(43, 202);
            this.btnConfirmDayEnergy.Name = "btnConfirmDayEnergy";
            this.btnConfirmDayEnergy.Size = new System.Drawing.Size(85, 32);
            this.btnConfirmDayEnergy.TabIndex = 14;
            this.btnConfirmDayEnergy.Text = "Confirm";
            this.btnConfirmDayEnergy.UseVisualStyleBackColor = true;
            this.btnConfirmDayEnergy.Click += new System.EventHandler(this.btnConfirmDayEnergy_Click);
            // 
            // cmbDayEnergyOptions
            // 
            this.cmbDayEnergyOptions.AccessibleName = "cmbDayEnergyOptions";
            this.cmbDayEnergyOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDayEnergyOptions.FormattingEnabled = true;
            this.cmbDayEnergyOptions.Location = new System.Drawing.Point(67, 143);
            this.cmbDayEnergyOptions.Name = "cmbDayEnergyOptions";
            this.cmbDayEnergyOptions.Size = new System.Drawing.Size(154, 24);
            this.cmbDayEnergyOptions.TabIndex = 13;
            // 
            // dtpDaySelector
            // 
            this.dtpDaySelector.AccessibleName = "dtpDaySelector";
            this.dtpDaySelector.CustomFormat = "dd mm yyyy";
            this.dtpDaySelector.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDaySelector.Location = new System.Drawing.Point(33, 50);
            this.dtpDaySelector.Name = "dtpDaySelector";
            this.dtpDaySelector.ShowUpDown = true;
            this.dtpDaySelector.Size = new System.Drawing.Size(219, 22);
            this.dtpDaySelector.TabIndex = 12;
            // 
            // DayEnergyPromptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelDayEnergy);
            this.Controls.Add(this.btnConfirmDayEnergy);
            this.Controls.Add(this.cmbDayEnergyOptions);
            this.Controls.Add(this.dtpDaySelector);
            this.Name = "DayEnergyPromptForm";
            this.Text = "DayEnergyPromptForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelDayEnergy;
        private System.Windows.Forms.Button btnConfirmDayEnergy;
        private System.Windows.Forms.ComboBox cmbDayEnergyOptions;
        private System.Windows.Forms.DateTimePicker dtpDaySelector;
    }
}