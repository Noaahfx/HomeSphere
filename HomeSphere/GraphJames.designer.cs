namespace HomeSphere
{
    partial class GraphJames
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.temptab = new System.Windows.Forms.TabPage();
            this.btnRefreshGraph = new System.Windows.Forms.Button();
            this.chartTemperature = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.temptab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperature)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.temptab);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1552, 974);
            this.tabControl1.TabIndex = 0;
            // 
            // temptab
            // 
            this.temptab.Controls.Add(this.btnRefreshGraph);
            this.temptab.Controls.Add(this.chartTemperature);
            this.temptab.Location = new System.Drawing.Point(4, 25);
            this.temptab.Name = "temptab";
            this.temptab.Padding = new System.Windows.Forms.Padding(3);
            this.temptab.Size = new System.Drawing.Size(1544, 945);
            this.temptab.TabIndex = 0;
            this.temptab.Text = "temperature";
            this.temptab.UseVisualStyleBackColor = true;
            this.temptab.Click += new System.EventHandler(this.temptab_Click);
            // 
            // btnRefreshGraph
            // 
            this.btnRefreshGraph.Location = new System.Drawing.Point(38, 22);
            this.btnRefreshGraph.Name = "btnRefreshGraph";
            this.btnRefreshGraph.Size = new System.Drawing.Size(98, 23);
            this.btnRefreshGraph.TabIndex = 1;
            this.btnRefreshGraph.Text = "Refresh";
            this.btnRefreshGraph.UseVisualStyleBackColor = true;
            this.btnRefreshGraph.Click += new System.EventHandler(this.btnRefreshGraph_Click);
            // 
            // chartTemperature
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTemperature.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTemperature.Legends.Add(legend1);
            this.chartTemperature.Location = new System.Drawing.Point(26, 66);
            this.chartTemperature.Name = "chartTemperature";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTemperature.Series.Add(series1);
            this.chartTemperature.Size = new System.Drawing.Size(1090, 791);
            this.chartTemperature.TabIndex = 0;
            this.chartTemperature.Text = "chart1";
            this.chartTemperature.Click += new System.EventHandler(this.chartTemperature_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1544, 1075);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 922);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form2";
            this.Text = "graphs";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabControl1.ResumeLayout(false);
            this.temptab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperature)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage temptab;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTemperature;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnRefreshGraph;
    }
}