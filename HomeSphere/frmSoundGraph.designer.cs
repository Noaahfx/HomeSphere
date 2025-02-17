namespace HomeSphere
{
    partial class frmSoundGraph
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
            this.chartSound = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartSound)).BeginInit();
            this.SuspendLayout();
            // 
            // chartSound
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSound.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSound.Legends.Add(legend1);
            this.chartSound.Location = new System.Drawing.Point(12, 24);
            this.chartSound.Name = "chartSound";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartSound.Series.Add(series1);
            this.chartSound.Size = new System.Drawing.Size(654, 551);
            this.chartSound.TabIndex = 0;
            this.chartSound.Text = "chart1";
            // 
            // frmSoundGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 575);
            this.Controls.Add(this.chartSound);
            this.Name = "frmSoundGraph";
            this.Text = "frmSoundGraph";
            ((System.ComponentModel.ISupportInitialize)(this.chartSound)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSound;
    }
}