namespace HomeSphere
{
    partial class frmOrderHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderHistory));
            this.dgvOrderHistory = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Home = new System.Windows.Forms.ToolStripButton();
            this.tsddbUserMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiViewCart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOrderHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageRecords = new System.Windows.Forms.ToolStripButton();
            this.Overview = new System.Windows.Forms.ToolStripButton();
            this.Products = new System.Windows.Forms.ToolStripButton();
            this.EventManagement = new System.Windows.Forms.ToolStripButton();
            this.lbltitle = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblsearch = new System.Windows.Forms.Label();
            this.lblTotalSpent = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderHistory)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOrderHistory
            // 
            this.dgvOrderHistory.AccessibleName = "dgvOrderHistory";
            this.dgvOrderHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderHistory.Location = new System.Drawing.Point(12, 66);
            this.dgvOrderHistory.Name = "dgvOrderHistory";
            this.dgvOrderHistory.RowTemplate.Height = 24;
            this.dgvOrderHistory.Size = new System.Drawing.Size(780, 445);
            this.dgvOrderHistory.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Home,
            this.tsddbUserMenu,
            this.ManageRecords,
            this.Overview,
            this.Products,
            this.EventManagement});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1361, 27);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
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
            // tsddbUserMenu
            // 
            this.tsddbUserMenu.AccessibleName = "tsddbUserMenu";
            this.tsddbUserMenu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsddbUserMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddbUserMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiViewCart,
            this.tsmiLogout,
            this.tsmiOrderHistory});
            this.tsddbUserMenu.Image = ((System.Drawing.Image)(resources.GetObject("tsddbUserMenu.Image")));
            this.tsddbUserMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbUserMenu.Name = "tsddbUserMenu";
            this.tsddbUserMenu.Size = new System.Drawing.Size(70, 24);
            this.tsddbUserMenu.Text = "Admin:";
            this.tsddbUserMenu.ToolTipText = "tsddbUserMenu";
            this.tsddbUserMenu.Click += new System.EventHandler(this.tsddbUserMenu_Click);
            // 
            // tsmiViewCart
            // 
            this.tsmiViewCart.AccessibleName = "tsmiViewCart";
            this.tsmiViewCart.Name = "tsmiViewCart";
            this.tsmiViewCart.Size = new System.Drawing.Size(181, 26);
            this.tsmiViewCart.Text = "View Cart";
            this.tsmiViewCart.Click += new System.EventHandler(this.tsmiViewCart_Click);
            // 
            // tsmiLogout
            // 
            this.tsmiLogout.AccessibleName = "tsmiLogout";
            this.tsmiLogout.Name = "tsmiLogout";
            this.tsmiLogout.Size = new System.Drawing.Size(181, 26);
            this.tsmiLogout.Text = "Logout";
            this.tsmiLogout.Click += new System.EventHandler(this.tsmiLogout_Click);
            // 
            // tsmiOrderHistory
            // 
            this.tsmiOrderHistory.AccessibleName = "tsmiOrderHistory";
            this.tsmiOrderHistory.Name = "tsmiOrderHistory";
            this.tsmiOrderHistory.Size = new System.Drawing.Size(181, 26);
            this.tsmiOrderHistory.Text = "Order History";
            this.tsmiOrderHistory.Click += new System.EventHandler(this.tsmiOrderHistory_Click);
            // 
            // ManageRecords
            // 
            this.ManageRecords.AccessibleName = "ManageRecords";
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
            // lbltitle
            // 
            this.lbltitle.AccessibleName = "lbltitle";
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.Location = new System.Drawing.Point(12, 37);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(147, 25);
            this.lbltitle.TabIndex = 15;
            this.lbltitle.Text = "Order History:";
            // 
            // txtSearch
            // 
            this.txtSearch.AccessibleName = "txtSearch";
            this.txtSearch.Location = new System.Drawing.Point(798, 91);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(170, 22);
            this.txtSearch.TabIndex = 16;
            // 
            // lblsearch
            // 
            this.lblsearch.AccessibleName = "lblsearch";
            this.lblsearch.AutoSize = true;
            this.lblsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsearch.Location = new System.Drawing.Point(798, 66);
            this.lblsearch.Name = "lblsearch";
            this.lblsearch.Size = new System.Drawing.Size(82, 24);
            this.lblsearch.TabIndex = 17;
            this.lblsearch.Text = "Search:";
            // 
            // lblTotalSpent
            // 
            this.lblTotalSpent.AccessibleName = "lblTotalSpent";
            this.lblTotalSpent.AutoSize = true;
            this.lblTotalSpent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSpent.Location = new System.Drawing.Point(798, 243);
            this.lblTotalSpent.Name = "lblTotalSpent";
            this.lblTotalSpent.Size = new System.Drawing.Size(119, 25);
            this.lblTotalSpent.TabIndex = 18;
            this.lblTotalSpent.Text = "Total Spent:";
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleName = "btnSearch";
            this.btnSearch.Location = new System.Drawing.Point(974, 89);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 26);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Confirm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmOrderHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 523);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblTotalSpent);
            this.Controls.Add(this.lblsearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgvOrderHistory);
            this.Name = "frmOrderHistory";
            this.Text = "frmOrderHistory";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderHistory)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrderHistory;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Home;
        private System.Windows.Forms.ToolStripDropDownButton tsddbUserMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewCart;
        private System.Windows.Forms.ToolStripMenuItem tsmiLogout;
        private System.Windows.Forms.ToolStripMenuItem tsmiOrderHistory;
        private System.Windows.Forms.ToolStripButton ManageRecords;
        private System.Windows.Forms.ToolStripButton Overview;
        private System.Windows.Forms.ToolStripButton Products;
        private System.Windows.Forms.ToolStripButton EventManagement;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblsearch;
        private System.Windows.Forms.Label lblTotalSpent;
        private System.Windows.Forms.Button btnSearch;
    }
}