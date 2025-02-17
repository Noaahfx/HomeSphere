namespace HomeSphere
{
    partial class SoundChartForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.soundChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBackToHome2 = new System.Windows.Forms.Button();
            this.comboFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.soundChart)).BeginInit();
            this.SuspendLayout();
            // 
            // soundChart
            // 
            this.soundChart.AccessibleName = "soundChart";
            chartArea1.Name = "ChartArea1";
            this.soundChart.ChartAreas.Add(chartArea1);
            this.soundChart.Dock = System.Windows.Forms.DockStyle.Left;
            legend1.Name = "Legend1";
            this.soundChart.Legends.Add(legend1);
            this.soundChart.Location = new System.Drawing.Point(0, 0);
            this.soundChart.Name = "soundChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.soundChart.Series.Add(series1);
            this.soundChart.Size = new System.Drawing.Size(875, 459);
            this.soundChart.TabIndex = 4;
            this.soundChart.Text = "soundChart";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(989, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Filters";
            // 
            // btnBackToHome2
            // 
            this.btnBackToHome2.AccessibleName = "btnBackToHome2";
            this.btnBackToHome2.BackColor = System.Drawing.Color.Red;
            this.btnBackToHome2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBackToHome2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToHome2.Location = new System.Drawing.Point(974, 366);
            this.btnBackToHome2.Name = "btnBackToHome2";
            this.btnBackToHome2.Size = new System.Drawing.Size(95, 45);
            this.btnBackToHome2.TabIndex = 11;
            this.btnBackToHome2.Text = "Return";
            this.btnBackToHome2.UseVisualStyleBackColor = false;
            this.btnBackToHome2.Click += new System.EventHandler(this.btnBackToHome2_Click);
            // 
            // comboFilter
            // 
            this.comboFilter.AccessibleName = "comboFilter";
            this.comboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFilter.FormattingEnabled = true;
            this.comboFilter.Location = new System.Drawing.Point(950, 119);
            this.comboFilter.Name = "comboFilter";
            this.comboFilter.Size = new System.Drawing.Size(142, 24);
            this.comboFilter.TabIndex = 13;
            // 
            // SoundChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 459);
            this.Controls.Add(this.comboFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBackToHome2);
            this.Controls.Add(this.soundChart);
            this.Name = "SoundChartForm";
            this.Text = "SoundChartForm";
            ((System.ComponentModel.ISupportInitialize)(this.soundChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart soundChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBackToHome2;
        private System.Windows.Forms.ComboBox comboFilter;
    }
}