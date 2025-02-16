namespace HomeSphere
{
    partial class Graph
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartTemperature = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbRoom = new System.Windows.Forms.ComboBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chartNoise = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartAggregate = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartEnergy = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnLoadAllCharts = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rooomSettingsBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNoise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAggregate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEnergy)).BeginInit();
            this.SuspendLayout();
            // 
            // chartTemperature
            // 
            this.chartTemperature.AccessibleName = "chartTemperature";
            chartArea1.Name = "ChartArea1";
            this.chartTemperature.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTemperature.Legends.Add(legend1);
            this.chartTemperature.Location = new System.Drawing.Point(33, 79);
            this.chartTemperature.Name = "chartTemperature";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTemperature.Series.Add(series1);
            this.chartTemperature.Size = new System.Drawing.Size(863, 432);
            this.chartTemperature.TabIndex = 0;
            this.chartTemperature.Text = "chart1";
            this.chartTemperature.Click += new System.EventHandler(this.chartTemperature_Click);
            // 
            // cmbRoom
            // 
            this.cmbRoom.AccessibleName = " cmbRoom";
            this.cmbRoom.FormattingEnabled = true;
            this.cmbRoom.Location = new System.Drawing.Point(50, 26);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(150, 21);
            this.cmbRoom.TabIndex = 1;
            this.cmbRoom.SelectedIndexChanged += new System.EventHandler(this.cmbRoom_SelectedIndexChanged);
            // 
            // dtpStart
            // 
            this.dtpStart.AccessibleName = "dtpStart";
            this.dtpStart.Location = new System.Drawing.Point(228, 27);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 20);
            this.dtpStart.TabIndex = 2;
            // 
            // chartNoise
            // 
            this.chartNoise.AccessibleName = "chartNoise";
            chartArea2.Name = "ChartArea1";
            this.chartNoise.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartNoise.Legends.Add(legend2);
            this.chartNoise.Location = new System.Drawing.Point(33, 556);
            this.chartNoise.Name = "chartNoise";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartNoise.Series.Add(series2);
            this.chartNoise.Size = new System.Drawing.Size(863, 432);
            this.chartNoise.TabIndex = 3;
            // 
            // chartAggregate
            // 
            this.chartAggregate.AccessibleName = "chartAggregate ";
            chartArea3.Name = "ChartArea1";
            this.chartAggregate.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartAggregate.Legends.Add(legend3);
            this.chartAggregate.Location = new System.Drawing.Point(922, 608);
            this.chartAggregate.Name = "chartAggregate";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartAggregate.Series.Add(series3);
            this.chartAggregate.Size = new System.Drawing.Size(751, 432);
            this.chartAggregate.TabIndex = 4;
            this.chartAggregate.Text = "chart3";
            this.chartAggregate.Click += new System.EventHandler(this.chart3_Click);
            // 
            // chartEnergy
            // 
            this.chartEnergy.AccessibleName = "chartEnergy";
            chartArea4.Name = "ChartArea1";
            this.chartEnergy.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartEnergy.Legends.Add(legend4);
            this.chartEnergy.Location = new System.Drawing.Point(922, 27);
            this.chartEnergy.Name = "chartEnergy";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartEnergy.Series.Add(series4);
            this.chartEnergy.Size = new System.Drawing.Size(990, 546);
            this.chartEnergy.TabIndex = 5;
            this.chartEnergy.Text = " ";
            this.chartEnergy.Click += new System.EventHandler(this.chart4_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.AccessibleName = "dtpEnd";
            this.dtpEnd.Location = new System.Drawing.Point(444, 26);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 20);
            this.dtpEnd.TabIndex = 6;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // btnLoadAllCharts
            // 
            this.btnLoadAllCharts.AccessibleName = "btnLoadAllCharts";
            this.btnLoadAllCharts.Location = new System.Drawing.Point(1783, 597);
            this.btnLoadAllCharts.Name = "btnLoadAllCharts";
            this.btnLoadAllCharts.Size = new System.Drawing.Size(129, 115);
            this.btnLoadAllCharts.TabIndex = 7;
            this.btnLoadAllCharts.Text = "Load Charts";
            this.btnLoadAllCharts.UseVisualStyleBackColor = true;
            this.btnLoadAllCharts.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(333, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Temperature";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1193, 576);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Total Energy Per Room";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(346, 524);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Noise Levels";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1256, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 18);
            this.label4.TabIndex = 11;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Select Room";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(227, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Start Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(441, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "End Room";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1294, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 24);
            this.label8.TabIndex = 15;
            this.label8.Text = "Energy Usage";
            // 
            // rooomSettingsBtn
            // 
            this.rooomSettingsBtn.Location = new System.Drawing.Point(1755, 780);
            this.rooomSettingsBtn.Name = "rooomSettingsBtn";
            this.rooomSettingsBtn.Size = new System.Drawing.Size(120, 49);
            this.rooomSettingsBtn.TabIndex = 16;
            this.rooomSettingsBtn.Text = "Room Settings";
            this.rooomSettingsBtn.UseVisualStyleBackColor = true;
            this.rooomSettingsBtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 721);
            this.Controls.Add(this.rooomSettingsBtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadAllCharts);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.chartEnergy);
            this.Controls.Add(this.chartAggregate);
            this.Controls.Add(this.chartNoise);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.cmbRoom);
            this.Controls.Add(this.chartTemperature);
            this.Name = "Graph";
            this.Text = "  ";
            this.Load += new System.EventHandler(this.Graph_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNoise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAggregate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEnergy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartTemperature;
        private System.Windows.Forms.ComboBox cmbRoom;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNoise;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAggregate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEnergy;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnLoadAllCharts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button rooomSettingsBtn;
    }
}