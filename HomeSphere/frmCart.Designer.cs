namespace HomeSphere
{
    partial class frmCart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCart));
            this.flpCart = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCartTotal = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Home = new System.Windows.Forms.ToolStripButton();
            this.tsddbUserMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiViewCart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageRecords = new System.Windows.Forms.ToolStripButton();
            this.Overview = new System.Windows.Forms.ToolStripButton();
            this.Products = new System.Windows.Forms.ToolStripButton();
            this.EventManagement = new System.Windows.Forms.ToolStripButton();
            this.flpCart.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpCart
            // 
            this.flpCart.AccessibleName = "flpCart";
            this.flpCart.Controls.Add(this.lblCartTotal);
            this.flpCart.Location = new System.Drawing.Point(0, 30);
            this.flpCart.Name = "flpCart";
            this.flpCart.Size = new System.Drawing.Size(1325, 400);
            this.flpCart.TabIndex = 0;
            // 
            // lblCartTotal
            // 
            this.lblCartTotal.AccessibleName = "lblCartTotal";
            this.lblCartTotal.AutoSize = true;
            this.lblCartTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartTotal.Location = new System.Drawing.Point(3, 0);
            this.lblCartTotal.Name = "lblCartTotal";
            this.lblCartTotal.Size = new System.Drawing.Size(105, 24);
            this.lblCartTotal.TabIndex = 0;
            this.lblCartTotal.Text = "Cart Total:";
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
            this.toolStrip1.Size = new System.Drawing.Size(1325, 27);
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
            this.tsmiLogout});
            this.tsddbUserMenu.Image = ((System.Drawing.Image)(resources.GetObject("tsddbUserMenu.Image")));
            this.tsddbUserMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbUserMenu.Name = "tsddbUserMenu";
            this.tsddbUserMenu.Size = new System.Drawing.Size(55, 24);
            this.tsddbUserMenu.Text = "User:";
            this.tsddbUserMenu.ToolTipText = "tsddbUserMenu";
            this.tsddbUserMenu.Click += new System.EventHandler(this.tsddbUserMenu_Click);
            // 
            // tsmiViewCart
            // 
            this.tsmiViewCart.AccessibleName = "tsmiViewCart";
            this.tsmiViewCart.Name = "tsmiViewCart";
            this.tsmiViewCart.Size = new System.Drawing.Size(181, 26);
            this.tsmiViewCart.Text = "View Cart";
            // 
            // tsmiLogout
            // 
            this.tsmiLogout.AccessibleName = "tsmiLogout";
            this.tsmiLogout.Name = "tsmiLogout";
            this.tsmiLogout.Size = new System.Drawing.Size(181, 26);
            this.tsmiLogout.Text = "Logout";
            this.tsmiLogout.Click += new System.EventHandler(this.tsmiLogout_Click);
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
            // frmCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 430);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.flpCart);
            this.Name = "frmCart";
            this.Text = "frmCart";
            this.flpCart.ResumeLayout(false);
            this.flpCart.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpCart;
        private System.Windows.Forms.Label lblCartTotal;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Home;
        private System.Windows.Forms.ToolStripDropDownButton tsddbUserMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewCart;
        private System.Windows.Forms.ToolStripMenuItem tsmiLogout;
        private System.Windows.Forms.ToolStripButton ManageRecords;
        private System.Windows.Forms.ToolStripButton Overview;
        private System.Windows.Forms.ToolStripButton Products;
        private System.Windows.Forms.ToolStripButton EventManagement;
    }
}