namespace Keith_admindashboard
{
    partial class EnergyChartForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.energyChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnBackToHome2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMonthEnergy = new System.Windows.Forms.Button();
            this.btnWeekEnergy = new System.Windows.Forms.Button();
            this.btnDayEnergy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.energyChart)).BeginInit();
            this.SuspendLayout();
            // 
            // energyChart
            // 
            this.energyChart.AccessibleName = "energyChart";
            chartArea6.Name = "ChartArea1";
            this.energyChart.ChartAreas.Add(chartArea6);
            this.energyChart.Dock = System.Windows.Forms.DockStyle.Left;
            legend6.Name = "Legend1";
            this.energyChart.Legends.Add(legend6);
            this.energyChart.Location = new System.Drawing.Point(0, 0);
            this.energyChart.Name = "energyChart";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.energyChart.Series.Add(series6);
            this.energyChart.Size = new System.Drawing.Size(947, 475);
            this.energyChart.TabIndex = 0;
            this.energyChart.Text = "energyChart";
            // 
            // btnBackToHome2
            // 
            this.btnBackToHome2.AccessibleName = "btnBackToHome2";
            this.btnBackToHome2.BackColor = System.Drawing.Color.Red;
            this.btnBackToHome2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBackToHome2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToHome2.Location = new System.Drawing.Point(988, 393);
            this.btnBackToHome2.Name = "btnBackToHome2";
            this.btnBackToHome2.Size = new System.Drawing.Size(95, 45);
            this.btnBackToHome2.TabIndex = 3;
            this.btnBackToHome2.Text = "Return";
            this.btnBackToHome2.UseVisualStyleBackColor = false;
            this.btnBackToHome2.Click += new System.EventHandler(this.btnBackToHome2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1008, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Filters";
            // 
            // btnMonthEnergy
            // 
            this.btnMonthEnergy.AccessibleName = "btnMonthEnergy";
            this.btnMonthEnergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonthEnergy.Location = new System.Drawing.Point(990, 79);
            this.btnMonthEnergy.Name = "btnMonthEnergy";
            this.btnMonthEnergy.Size = new System.Drawing.Size(92, 37);
            this.btnMonthEnergy.TabIndex = 9;
            this.btnMonthEnergy.Text = "Month";
            this.btnMonthEnergy.UseVisualStyleBackColor = true;
            this.btnMonthEnergy.Click += new System.EventHandler(this.btnMonthEnergy_Click);
            // 
            // btnWeekEnergy
            // 
            this.btnWeekEnergy.AccessibleName = "btnWeekEnergy";
            this.btnWeekEnergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWeekEnergy.Location = new System.Drawing.Point(990, 134);
            this.btnWeekEnergy.Name = "btnWeekEnergy";
            this.btnWeekEnergy.Size = new System.Drawing.Size(92, 37);
            this.btnWeekEnergy.TabIndex = 8;
            this.btnWeekEnergy.Text = "Week";
            this.btnWeekEnergy.UseVisualStyleBackColor = true;
            this.btnWeekEnergy.Click += new System.EventHandler(this.btnWeekEnergy_Click);
            // 
            // btnDayEnergy
            // 
            this.btnDayEnergy.AccessibleName = "btnDayEnergy";
            this.btnDayEnergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDayEnergy.Location = new System.Drawing.Point(963, 189);
            this.btnDayEnergy.Name = "btnDayEnergy";
            this.btnDayEnergy.Size = new System.Drawing.Size(162, 37);
            this.btnDayEnergy.TabIndex = 7;
            this.btnDayEnergy.Text = "Specific Month";
            this.btnDayEnergy.UseVisualStyleBackColor = true;
            this.btnDayEnergy.Click += new System.EventHandler(this.btnDayEnergy_Click);
            // 
            // EnergyChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 475);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMonthEnergy);
            this.Controls.Add(this.btnWeekEnergy);
            this.Controls.Add(this.btnDayEnergy);
            this.Controls.Add(this.btnBackToHome2);
            this.Controls.Add(this.energyChart);
            this.Name = "EnergyChartForm";
            this.Text = "EnergyChartForm";
            this.Load += new System.EventHandler(this.EnergyChartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.energyChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart energyChart;
        private System.Windows.Forms.Button btnBackToHome2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMonthEnergy;
        private System.Windows.Forms.Button btnWeekEnergy;
        private System.Windows.Forms.Button btnDayEnergy;
    }
}