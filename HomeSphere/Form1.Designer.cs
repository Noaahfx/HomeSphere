namespace HomeSphere
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lighting = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.energy = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTemperature = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chartUltrasonic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Home = new System.Windows.Forms.ToolStripButton();
            this.Logout = new System.Windows.Forms.ToolStripButton();
            this.ManageRecords = new System.Windows.Forms.ToolStripButton();
            this.Overview = new System.Windows.Forms.ToolStripButton();
            this.Products = new System.Windows.Forms.ToolStripButton();
            this.EventManagement = new System.Windows.Forms.ToolStripButton();
            this.UserManagement = new System.Windows.Forms.ToolStripButton();
            this.lighting = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.energy = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTemperature = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.energy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperature)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Home,
            this.Logout,
            this.ManageRecords,
            this.Overview,
            this.Products,
            this.EventManagement,
            this.UserManagement});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1329, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // lighting
            // 
            this.lighting.AccessibleName = "lighting";
            chartArea1.Name = "ChartArea1";
            this.lighting.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.lighting.Legends.Add(legend1);
            this.lighting.Location = new System.Drawing.Point(28, 60);
            this.lighting.Name = "lighting";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.lighting.Series.Add(series1);
            this.lighting.Size = new System.Drawing.Size(649, 369);
            this.lighting.TabIndex = 1;
            this.lighting.Text = "lighting";
            this.lighting.Click += new System.EventHandler(this.lighting_Click);
            // 
            // energy
            // 
            this.energy.AccessibleName = "energy";
            chartArea2.Name = "ChartArea1";
            this.energy.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.energy.Legends.Add(legend2);
            this.energy.Location = new System.Drawing.Point(694, 60);
            this.energy.Name = "energy";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.energy.Series.Add(series2);
            this.energy.Size = new System.Drawing.Size(574, 369);
            this.energy.TabIndex = 2;
            this.energy.Text = "energy";
            this.energy.Click += new System.EventHandler(this.energy_Click);
            // 
            // chartTemperature
            // 
            chartArea3.Name = "ChartArea1";
            this.chartTemperature.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartTemperature.Legends.Add(legend3);
            this.chartTemperature.Location = new System.Drawing.Point(28, 475);
            this.chartTemperature.Name = "chartTemperature";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartTemperature.Series.Add(series3);
            this.chartTemperature.Size = new System.Drawing.Size(649, 451);
            this.chartTemperature.TabIndex = 3;
            this.chartTemperature.Text = "chart1";
            this.chartTemperature.Click += new System.EventHandler(this.chartTemperature_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 445);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Temperature Graph";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(646, 442);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(757, 445);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ultrasonic Graph";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // chartUltrasonic
            // 
            chartArea4.Name = "ChartArea1";
            this.chartUltrasonic.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartUltrasonic.Legends.Add(legend4);
            this.chartUltrasonic.Location = new System.Drawing.Point(694, 475);
            this.chartUltrasonic.Name = "chartUltrasonic";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartUltrasonic.Series.Add(series4);
            this.chartUltrasonic.Size = new System.Drawing.Size(574, 451);
            this.chartUltrasonic.TabIndex = 7;
            this.chartUltrasonic.Text = "chart1";
            this.chartUltrasonic.Click += new System.EventHandler(this.chartUltrasonic_Click);
            // 
            // Home
            // 
            this.Home.AccessibleName = "Home";
            this.Home.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Home.Image = ((System.Drawing.Image)(resources.GetObject("Home.Image")));
            this.Home.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(54, 24);
            this.Home.Text = "Home";
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // Logout
            // 
            this.Logout.AccessibleName = "Logout";
            this.Logout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Logout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Logout.Image = ((System.Drawing.Image)(resources.GetObject("Logout.Image")));
            this.Logout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(60, 24);
            this.Logout.Text = "Logout";
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // ManageRecords
            // 
            this.ManageRecords.AccessibleName = "ManageRecords";
            this.ManageRecords.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ManageRecords.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ManageRecords.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ManageRecords.Name = "ManageRecords";
            this.ManageRecords.Size = new System.Drawing.Size(120, 24);
            this.ManageRecords.Text = "ManageRecords";
            this.ManageRecords.Click += new System.EventHandler(this.ManageRecords_Click);
            // 
            // Overview
            // 
            this.Overview.AccessibleName = "Overview";
            this.Overview.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Overview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Overview.Image = ((System.Drawing.Image)(resources.GetObject("Overview.Image")));
            this.Overview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Overview.Name = "Overview";
            this.Overview.Size = new System.Drawing.Size(74, 24);
            this.Overview.Text = "Overview";
            this.Overview.Click += new System.EventHandler(this.Overview_Click);
            // 
            // Products
            // 
            this.Products.AccessibleName = "Products";
            this.Products.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Products.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Products.Image = ((System.Drawing.Image)(resources.GetObject("Products.Image")));
            this.Products.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Products.Name = "Products";
            this.Products.Size = new System.Drawing.Size(70, 24);
            this.Products.Text = "Products";
            this.Products.Click += new System.EventHandler(this.Products_Click);
            // 
            // EventManagement
            // 
            this.EventManagement.AccessibleName = "EventManagement";
            this.EventManagement.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.EventManagement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.EventManagement.Image = ((System.Drawing.Image)(resources.GetObject("EventManagement.Image")));
            this.EventManagement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EventManagement.Name = "EventManagement";
            this.EventManagement.Size = new System.Drawing.Size(51, 24);
            this.EventManagement.Text = "Alerts";
            this.EventManagement.Click += new System.EventHandler(this.EventManagement_Click);
            // 
            // UserManagement
            // 
            this.UserManagement.AccessibleName = "UserManagement";
            this.UserManagement.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.UserManagement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.UserManagement.Image = ((System.Drawing.Image)(resources.GetObject("UserManagement.Image")));
            this.UserManagement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UserManagement.Name = "UserManagement";
            this.UserManagement.Size = new System.Drawing.Size(106, 24);
            this.UserManagement.Text = "Manage Users";
            this.UserManagement.Click += new System.EventHandler(this.UserManagement_Click);
            // 
            // lighting
            // 
            this.lighting.AccessibleName = "lighting";
            chartArea1.Name = "ChartArea1";
            this.lighting.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.lighting.Legends.Add(legend1);
            this.lighting.Location = new System.Drawing.Point(28, 60);
            this.lighting.Name = "lighting";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.lighting.Series.Add(series1);
            this.lighting.Size = new System.Drawing.Size(649, 369);
            this.lighting.TabIndex = 1;
            this.lighting.Text = "lighting";
            this.lighting.Click += new System.EventHandler(this.lighting_Click);
            // 
            // energy
            // 
            this.energy.AccessibleName = "energy";
            chartArea2.Name = "ChartArea1";
            this.energy.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.energy.Legends.Add(legend2);
            this.energy.Location = new System.Drawing.Point(694, 60);
            this.energy.Name = "energy";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.energy.Series.Add(series2);
            this.energy.Size = new System.Drawing.Size(574, 369);
            this.energy.TabIndex = 2;
            this.energy.Text = "energy";
            this.energy.Click += new System.EventHandler(this.energy_Click);
            // 
            // chartTemperature
            // 
            chartArea3.Name = "ChartArea1";
            this.chartTemperature.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartTemperature.Legends.Add(legend3);
            this.chartTemperature.Location = new System.Drawing.Point(28, 475);
            this.chartTemperature.Name = "chartTemperature";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartTemperature.Series.Add(series3);
            this.chartTemperature.Size = new System.Drawing.Size(649, 451);
            this.chartTemperature.TabIndex = 3;
            this.chartTemperature.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 445);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Temperature Graph";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(204, 442);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1329, 947);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartTemperature);
            this.Controls.Add(this.energy);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.energy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperature)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Home;
        private System.Windows.Forms.ToolStripButton Overview;
        private System.Windows.Forms.ToolStripButton Logout;
        private System.Windows.Forms.DataVisualization.Charting.Chart energy;
        private System.Windows.Forms.ToolStripButton ManageRecords;
        private System.Windows.Forms.ToolStripButton EventManagement;
        private System.Windows.Forms.ToolStripButton Products;
        private System.Windows.Forms.ToolStripButton UserManagement;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTemperature;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
    }
}

