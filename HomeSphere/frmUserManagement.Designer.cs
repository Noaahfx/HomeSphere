namespace HomeSphere
{
    partial class frmUserManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnDisableUser = new System.Windows.Forms.Button();
            this.btnDisableAllUsers = new System.Windows.Forms.Button();
            this.btnEnableUser = new System.Windows.Forms.Button();
            this.btnEnableAllUsers = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnDeleteAllUsers = new System.Windows.Forms.Button();
            this.lbltitle = new System.Windows.Forms.Label();
            this.lblsearchbar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            this.dgvUsers.AccessibleName = "dgvUsers";
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(12, 52);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowTemplate.Height = 24;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(840, 299);
            this.dgvUsers.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.AccessibleName = "txtSearch";
            this.txtSearch.Location = new System.Drawing.Point(858, 52);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(149, 22);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnDisableUser
            // 
            this.btnDisableUser.AccessibleName = "btnDisableUser";
            this.btnDisableUser.BackColor = System.Drawing.Color.Cyan;
            this.btnDisableUser.Location = new System.Drawing.Point(454, 368);
            this.btnDisableUser.Name = "btnDisableUser";
            this.btnDisableUser.Size = new System.Drawing.Size(116, 40);
            this.btnDisableUser.TabIndex = 3;
            this.btnDisableUser.Text = "Disable User";
            this.btnDisableUser.UseVisualStyleBackColor = false;
            this.btnDisableUser.Click += new System.EventHandler(this.btnDisableUser_Click_1);
            // 
            // btnDisableAllUsers
            // 
            this.btnDisableAllUsers.AccessibleName = "btnDisableAllUsers";
            this.btnDisableAllUsers.BackColor = System.Drawing.Color.Cyan;
            this.btnDisableAllUsers.Location = new System.Drawing.Point(172, 367);
            this.btnDisableAllUsers.Name = "btnDisableAllUsers";
            this.btnDisableAllUsers.Size = new System.Drawing.Size(154, 40);
            this.btnDisableAllUsers.TabIndex = 4;
            this.btnDisableAllUsers.Text = "Disable All Users";
            this.btnDisableAllUsers.UseVisualStyleBackColor = false;
            this.btnDisableAllUsers.Click += new System.EventHandler(this.btnDisableAllUsers_Click_1);
            // 
            // btnEnableUser
            // 
            this.btnEnableUser.AccessibleName = "btnEnableUser";
            this.btnEnableUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnEnableUser.Location = new System.Drawing.Point(332, 367);
            this.btnEnableUser.Name = "btnEnableUser";
            this.btnEnableUser.Size = new System.Drawing.Size(116, 41);
            this.btnEnableUser.TabIndex = 5;
            this.btnEnableUser.Text = "Enable User";
            this.btnEnableUser.UseVisualStyleBackColor = false;
            this.btnEnableUser.Click += new System.EventHandler(this.btnEnableUser_Click_1);
            // 
            // btnEnableAllUsers
            // 
            this.btnEnableAllUsers.AccessibleName = "btnEnableAllUsers";
            this.btnEnableAllUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnEnableAllUsers.Location = new System.Drawing.Point(12, 366);
            this.btnEnableAllUsers.Name = "btnEnableAllUsers";
            this.btnEnableAllUsers.Size = new System.Drawing.Size(154, 40);
            this.btnEnableAllUsers.TabIndex = 6;
            this.btnEnableAllUsers.Text = "Enable All Users";
            this.btnEnableAllUsers.UseVisualStyleBackColor = false;
            this.btnEnableAllUsers.Click += new System.EventHandler(this.btnEnableAllUsers_Click_1);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.AccessibleName = "btnDeleteUser";
            this.btnDeleteUser.BackColor = System.Drawing.Color.Red;
            this.btnDeleteUser.Location = new System.Drawing.Point(736, 368);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(116, 40);
            this.btnDeleteUser.TabIndex = 7;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click_1);
            // 
            // btnDeleteAllUsers
            // 
            this.btnDeleteAllUsers.AccessibleName = "btnDeleteAllUsers";
            this.btnDeleteAllUsers.BackColor = System.Drawing.Color.Red;
            this.btnDeleteAllUsers.Location = new System.Drawing.Point(576, 368);
            this.btnDeleteAllUsers.Name = "btnDeleteAllUsers";
            this.btnDeleteAllUsers.Size = new System.Drawing.Size(154, 40);
            this.btnDeleteAllUsers.TabIndex = 8;
            this.btnDeleteAllUsers.Text = "Delete All Users";
            this.btnDeleteAllUsers.UseVisualStyleBackColor = false;
            this.btnDeleteAllUsers.Click += new System.EventHandler(this.btnDeleteAllUsers_Click_1);
            // 
            // lbltitle
            // 
            this.lbltitle.AccessibleName = "lbltitle";
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.Location = new System.Drawing.Point(12, 24);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(195, 25);
            this.lbltitle.TabIndex = 9;
            this.lbltitle.Text = "User Management:";
            // 
            // lblsearchbar
            // 
            this.lblsearchbar.AccessibleName = "lblsearchbar";
            this.lblsearchbar.AutoSize = true;
            this.lblsearchbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsearchbar.Location = new System.Drawing.Point(866, 23);
            this.lblsearchbar.Name = "lblsearchbar";
            this.lblsearchbar.Size = new System.Drawing.Size(62, 20);
            this.lblsearchbar.TabIndex = 10;
            this.lblsearchbar.Text = "Search";
            // 
            // frmUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 520);
            this.Controls.Add(this.lblsearchbar);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.btnDeleteAllUsers);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnEnableAllUsers);
            this.Controls.Add(this.btnEnableUser);
            this.Controls.Add(this.btnDisableAllUsers);
            this.Controls.Add(this.btnDisableUser);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvUsers);
            this.Name = "frmUserManagement";
            this.Text = "frmUserManagement";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnDisableUser;
        private System.Windows.Forms.Button btnDisableAllUsers;
        private System.Windows.Forms.Button btnEnableUser;
        private System.Windows.Forms.Button btnEnableAllUsers;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnDeleteAllUsers;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Label lblsearchbar;
    }
}