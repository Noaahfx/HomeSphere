namespace HomeSphere
{
    partial class MonthEnergyPromptForm
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
            this.btnCancelMonthEnergy = new System.Windows.Forms.Button();
            this.btnConfirmMonthEnergy = new System.Windows.Forms.Button();
            this.cmbMonthEnergyOptions = new System.Windows.Forms.ComboBox();
            this.dtpMonthSelector = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(97, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Type of View";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Pick the Month you want to see";
            // 
            // btnCancelMonthEnergy
            // 
            this.btnCancelMonthEnergy.AccessibleName = "btnCancelMonthEnergy";
            this.btnCancelMonthEnergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelMonthEnergy.Location = new System.Drawing.Point(165, 206);
            this.btnCancelMonthEnergy.Name = "btnCancelMonthEnergy";
            this.btnCancelMonthEnergy.Size = new System.Drawing.Size(85, 32);
            this.btnCancelMonthEnergy.TabIndex = 9;
            this.btnCancelMonthEnergy.Text = "Cancel";
            this.btnCancelMonthEnergy.UseVisualStyleBackColor = true;
            this.btnCancelMonthEnergy.Click += new System.EventHandler(this.btnCancelMonthEnergy_Click);
            // 
            // btnConfirmMonthEnergy
            // 
            this.btnConfirmMonthEnergy.AccessibleName = "btnConfirmMonthEnergy";
            this.btnConfirmMonthEnergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmMonthEnergy.Location = new System.Drawing.Point(50, 206);
            this.btnConfirmMonthEnergy.Name = "btnConfirmMonthEnergy";
            this.btnConfirmMonthEnergy.Size = new System.Drawing.Size(85, 32);
            this.btnConfirmMonthEnergy.TabIndex = 8;
            this.btnConfirmMonthEnergy.Text = "Confirm";
            this.btnConfirmMonthEnergy.UseVisualStyleBackColor = true;
            this.btnConfirmMonthEnergy.Click += new System.EventHandler(this.btnConfirmMonthEnergy_Click);
            // 
            // cmbMonthEnergyOptions
            // 
            this.cmbMonthEnergyOptions.AccessibleName = "cmbMonthEnergyOptions";
            this.cmbMonthEnergyOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonthEnergyOptions.FormattingEnabled = true;
            this.cmbMonthEnergyOptions.Location = new System.Drawing.Point(74, 147);
            this.cmbMonthEnergyOptions.Name = "cmbMonthEnergyOptions";
            this.cmbMonthEnergyOptions.Size = new System.Drawing.Size(154, 24);
            this.cmbMonthEnergyOptions.TabIndex = 7;
            this.cmbMonthEnergyOptions.SelectedIndexChanged += new System.EventHandler(this.cmbMonthEnergyOptions_SelectedIndexChanged);
            // 
            // dtpMonthSelector
            // 
            this.dtpMonthSelector.AccessibleName = "dtpMonthSelector";
            this.dtpMonthSelector.CustomFormat = "MMMM yyyy";
            this.dtpMonthSelector.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonthSelector.Location = new System.Drawing.Point(40, 54);
            this.dtpMonthSelector.Name = "dtpMonthSelector";
            this.dtpMonthSelector.ShowUpDown = true;
            this.dtpMonthSelector.Size = new System.Drawing.Size(219, 22);
            this.dtpMonthSelector.TabIndex = 6;
            this.dtpMonthSelector.ValueChanged += new System.EventHandler(this.dtpMonthSelector_ValueChanged);
            // 
            // MonthEnergyPromptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelMonthEnergy);
            this.Controls.Add(this.btnConfirmMonthEnergy);
            this.Controls.Add(this.cmbMonthEnergyOptions);
            this.Controls.Add(this.dtpMonthSelector);
            this.Name = "MonthEnergyPromptForm";
            this.Text = "MonthEnergyPromptForm";
            this.Load += new System.EventHandler(this.MonthEnergyPromptForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelMonthEnergy;
        private System.Windows.Forms.Button btnConfirmMonthEnergy;
        private System.Windows.Forms.ComboBox cmbMonthEnergyOptions;
        private System.Windows.Forms.DateTimePicker dtpMonthSelector;
    }
}