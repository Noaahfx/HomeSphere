namespace Keith_admindashboard
{
    partial class LightingChartForm
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
            this.lightingChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnBackToHome1 = new System.Windows.Forms.Button();
            this.btnDay = new System.Windows.Forms.Button();
            this.btnWeek = new System.Windows.Forms.Button();
            this.btnMonth = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lightingChart)).BeginInit();
            this.SuspendLayout();
            // 
            // lightingChart
            // 
            this.lightingChart.AccessibleName = "lightingChart";
            chartArea6.Name = "ChartArea1";
            this.lightingChart.ChartAreas.Add(chartArea6);
            this.lightingChart.Dock = System.Windows.Forms.DockStyle.Left;
            legend6.Name = "Legend1";
            this.lightingChart.Legends.Add(legend6);
            this.lightingChart.Location = new System.Drawing.Point(0, 0);
            this.lightingChart.Name = "lightingChart";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.lightingChart.Series.Add(series6);
            this.lightingChart.Size = new System.Drawing.Size(978, 455);
            this.lightingChart.TabIndex = 0;
            this.lightingChart.Text = "lightingChart";
            // 
            // btnBackToHome1
            // 
            this.btnBackToHome1.AccessibleName = "btnBackToHome1";
            this.btnBackToHome1.BackColor = System.Drawing.Color.Red;
            this.btnBackToHome1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToHome1.Location = new System.Drawing.Point(1017, 368);
            this.btnBackToHome1.Name = "btnBackToHome1";
            this.btnBackToHome1.Size = new System.Drawing.Size(95, 45);
            this.btnBackToHome1.TabIndex = 2;
            this.btnBackToHome1.Text = "Return";
            this.btnBackToHome1.UseVisualStyleBackColor = false;
            this.btnBackToHome1.Click += new System.EventHandler(this.btnBackToHome1_Click);
            // 
            // btnDay
            // 
            this.btnDay.AccessibleName = "btnDay";
            this.btnDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDay.Location = new System.Drawing.Point(1017, 160);
            this.btnDay.Name = "btnDay";
            this.btnDay.Size = new System.Drawing.Size(95, 37);
            this.btnDay.TabIndex = 3;
            this.btnDay.Text = "Day";
            this.btnDay.UseVisualStyleBackColor = true;
            this.btnDay.Click += new System.EventHandler(this.btnDay_Click);
            // 
            // btnWeek
            // 
            this.btnWeek.AccessibleName = "btnWeek";
            this.btnWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWeek.Location = new System.Drawing.Point(1020, 100);
            this.btnWeek.Name = "btnWeek";
            this.btnWeek.Size = new System.Drawing.Size(92, 37);
            this.btnWeek.TabIndex = 4;
            this.btnWeek.Text = "Week";
            this.btnWeek.UseVisualStyleBackColor = true;
            this.btnWeek.Click += new System.EventHandler(this.btnWeek_Click);
            // 
            // btnMonth
            // 
            this.btnMonth.AccessibleName = "btnMonth";
            this.btnMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonth.Location = new System.Drawing.Point(1020, 45);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.Size = new System.Drawing.Size(92, 37);
            this.btnMonth.TabIndex = 5;
            this.btnMonth.Text = "Month";
            this.btnMonth.UseVisualStyleBackColor = true;
            this.btnMonth.Click += new System.EventHandler(this.btnMonth_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1038, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Filters";
            // 
            // LightingChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 455);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMonth);
            this.Controls.Add(this.btnWeek);
            this.Controls.Add(this.btnDay);
            this.Controls.Add(this.btnBackToHome1);
            this.Controls.Add(this.lightingChart);
            this.Name = "LightingChartForm";
            this.Text = "LightingChartForm";
            this.Load += new System.EventHandler(this.LightingChartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lightingChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart lightingChart;
        private System.Windows.Forms.Button btnBackToHome1;
        private System.Windows.Forms.Button btnDay;
        private System.Windows.Forms.Button btnWeek;
        private System.Windows.Forms.Button btnMonth;
        private System.Windows.Forms.Label label1;
    }
}