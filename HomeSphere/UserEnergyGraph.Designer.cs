namespace HomeSphere
{
    partial class UserEnergyGraph
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
            this.energyChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtpSelectedDate = new System.Windows.Forms.DateTimePicker();
            this.btnViewEnergy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.energyChart)).BeginInit();
            this.SuspendLayout();
            // 
            // energyChart
            // 
            chartArea1.Name = "ChartArea1";
            this.energyChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.energyChart.Legends.Add(legend1);
            this.energyChart.Location = new System.Drawing.Point(25, 41);
            this.energyChart.Name = "energyChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.energyChart.Series.Add(series1);
            this.energyChart.Size = new System.Drawing.Size(1134, 850);
            this.energyChart.TabIndex = 0;
            this.energyChart.Text = "chart1";
            // 
            // dtpSelectedDate
            // 
            this.dtpSelectedDate.Location = new System.Drawing.Point(1197, 85);
            this.dtpSelectedDate.Name = "dtpSelectedDate";
            this.dtpSelectedDate.Size = new System.Drawing.Size(200, 31);
            this.dtpSelectedDate.TabIndex = 1;
            this.dtpSelectedDate.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // btnViewEnergy
            // 
            this.btnViewEnergy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnViewEnergy.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnViewEnergy.FlatAppearance.BorderSize = 0;
            this.btnViewEnergy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnViewEnergy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnViewEnergy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewEnergy.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewEnergy.ForeColor = System.Drawing.Color.White;
            this.btnViewEnergy.Location = new System.Drawing.Point(1221, 321);
            this.btnViewEnergy.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewEnergy.Name = "btnViewEnergy";
            this.btnViewEnergy.Size = new System.Drawing.Size(150, 85);
            this.btnViewEnergy.TabIndex = 28;
            this.btnViewEnergy.Text = "View";
            this.btnViewEnergy.UseVisualStyleBackColor = false;
            this.btnViewEnergy.Click += new System.EventHandler(this.btnViewEnergy_Click_1);
            // 
            // UserEnergyGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 927);
            this.Controls.Add(this.btnViewEnergy);
            this.Controls.Add(this.dtpSelectedDate);
            this.Controls.Add(this.energyChart);
            this.Name = "UserEnergyGraph";
            this.Text = "UserEnergyGraph";
            ((System.ComponentModel.ISupportInitialize)(this.energyChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart energyChart;
        private System.Windows.Forms.DateTimePicker dtpSelectedDate;
        private System.Windows.Forms.Button btnViewEnergy;
    }
}