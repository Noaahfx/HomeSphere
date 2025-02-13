﻿namespace Keith_admindashboard
{
    partial class OverviewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OverviewForm));
            this.lblOverviewText = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Home = new System.Windows.Forms.ToolStripButton();
            this.Logout = new System.Windows.Forms.ToolStripButton();
            this.ManageRecords = new System.Windows.Forms.ToolStripButton();
            this.Overview = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbOverviewSort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOverviewText
            // 
            this.lblOverviewText.AccessibleName = "lblOverviewText";
            this.lblOverviewText.AutoSize = true;
            this.lblOverviewText.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverviewText.Location = new System.Drawing.Point(12, 103);
            this.lblOverviewText.Name = "lblOverviewText";
            this.lblOverviewText.Size = new System.Drawing.Size(79, 29);
            this.lblOverviewText.TabIndex = 0;
            this.lblOverviewText.Text = "label1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Home,
            this.Logout,
            this.ManageRecords,
            this.Overview});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1483, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Home
            // 
            this.Home.AccessibleName = "HomeOverview";
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
            this.Logout.AccessibleName = "LogoutOverview";
            this.Logout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Logout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Logout.Image = ((System.Drawing.Image)(resources.GetObject("Logout.Image")));
            this.Logout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(60, 24);
            this.Logout.Text = "Logout";
            // 
            // ManageRecords
            // 
            this.ManageRecords.AccessibleName = "ManageRecordsOverview";
            this.ManageRecords.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ManageRecords.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ManageRecords.Image = ((System.Drawing.Image)(resources.GetObject("ManageRecords.Image")));
            this.ManageRecords.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ManageRecords.Name = "ManageRecords";
            this.ManageRecords.Size = new System.Drawing.Size(120, 24);
            this.ManageRecords.Text = "ManageRecords";
            this.ManageRecords.Click += new System.EventHandler(this.ManageRecords_Click);
            // 
            // Overview
            // 
            this.Overview.AccessibleName = "OverviewOverview";
            this.Overview.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Overview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Overview.Image = ((System.Drawing.Image)(resources.GetObject("Overview.Image")));
            this.Overview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Overview.Name = "Overview";
            this.Overview.Size = new System.Drawing.Size(74, 24);
            this.Overview.Text = "Overview";
            this.Overview.Click += new System.EventHandler(this.Overview_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Overview:";
            // 
            // cmbOverviewSort
            // 
            this.cmbOverviewSort.AccessibleName = "cmbOverviewSort";
            this.cmbOverviewSort.FormattingEnabled = true;
            this.cmbOverviewSort.Items.AddRange(new object[] {
            "Month",
            "Week"});
            this.cmbOverviewSort.Location = new System.Drawing.Point(17, 163);
            this.cmbOverviewSort.Name = "cmbOverviewSort";
            this.cmbOverviewSort.Size = new System.Drawing.Size(121, 24);
            this.cmbOverviewSort.TabIndex = 3;
            this.cmbOverviewSort.SelectedIndexChanged += new System.EventHandler(this.cmbOverviewSort_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sort";
            // 
            // OverviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1483, 491);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbOverviewSort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lblOverviewText);
            this.Name = "OverviewForm";
            this.Text = "OverviewForm";
            this.Load += new System.EventHandler(this.OverviewForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOverviewText;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Home;
        private System.Windows.Forms.ToolStripButton Logout;
        private System.Windows.Forms.ToolStripButton ManageRecords;
        private System.Windows.Forms.ToolStripButton Overview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbOverviewSort;
        private System.Windows.Forms.Label label2;
    }
}