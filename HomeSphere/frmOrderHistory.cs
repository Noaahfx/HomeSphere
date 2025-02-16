using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace HomeSphere
{
    public partial class frmOrderHistory : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private DataTable orderTable;

        public frmOrderHistory()
        {
            InitializeComponent();
            LoadOrderHistory();
        }

        private void LoadOrderHistory()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT ProductName AS 'Product', Price, Quantity, OrderDate
                    FROM Orders
                    WHERE UserID = @UserID
                    ORDER BY OrderDate DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@UserID", CartManager.CurrentUser);
                orderTable = new DataTable();
                adapter.Fill(orderTable);

                dgvOrderHistory.DataSource = orderTable;
            }

            dgvOrderHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderHistory.ReadOnly = true;

            // ✅ Update total for the full dataset initially
            UpdateTotalSpent(orderTable.DefaultView);
        }

        private void UpdateTotalSpent(DataView dv)
        {
            decimal totalSpent = 0;

            foreach (DataRowView row in dv)
            {
                decimal price = Convert.ToDecimal(row["Price"]);
                int quantity = Convert.ToInt32(row["Quantity"]);
                totalSpent += price * quantity;
            }

            lblTotalSpent.Text = $"Total Spent: ${totalSpent:F2}";
        }

        private void PerformSearch()
        {
            string filter = txtSearch.Text.Trim();
            DataView dv = new DataView(orderTable);

            if (string.IsNullOrEmpty(filter))
            {
                dgvOrderHistory.DataSource = orderTable;
                UpdateTotalSpent(orderTable.DefaultView); // ✅ Update total for full dataset
            }
            else
            {
                dv.RowFilter = $"Product LIKE '%{filter}%'";
                dgvOrderHistory.DataSource = dv;
                UpdateTotalSpent(dv); // ✅ Update total based on filtered dataset
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        // 🟢 NAVIGATION CONTROLS (Same as your other forms)

        private void Home_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Overview_Click(object sender, EventArgs e)
        {
            OverviewForm overviewForm = new OverviewForm();
            overviewForm.Show();
            this.Hide();
        }

        private void ManageRecords_Click(object sender, EventArgs e)
        {
            DataViewJames tableManagement = new DataViewJames();
            tableManagement.Show();
            this.Hide();
        }

        private void EventManagement_Click(object sender, EventArgs e)
        {
            frmAlertManagement alertManagement = new frmAlertManagement();
            this.Hide();
            alertManagement.Show();
        }

        private void Products_Click(object sender, EventArgs e)
        {
            frmProductPage frmproductpage = new frmProductPage();
            frmproductpage.Show();
            this.Hide();
        }

        private void tsddbUserMenu_Click(object sender, EventArgs e)
        {
        }

        private void tsmiLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Logout Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                this.Close();
                frmAdminLogin adminLoginForm = new frmAdminLogin();
                adminLoginForm.Show();
            }
        }

        private void tsmiViewCart_Click(object sender, EventArgs e)
        {
            frmCart frmcart = new frmCart();
            frmcart.Show();
            this.Hide();
        }

        private void tsmiOrderHistory_Click(object sender, EventArgs e)
        {
            frmOrderHistory orderHistoryForm = new frmOrderHistory();
            orderHistoryForm.Show();
            this.Hide();
        }
    }
}
