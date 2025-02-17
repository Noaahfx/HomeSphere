using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace HomeSphere
{
    public partial class frmUserManagement : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private DataTable userTable;

        public frmUserManagement()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT ID, Email, IsDisabled 
                    FROM Users
                    ORDER BY ID ASC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                userTable = new DataTable();
                adapter.Fill(userTable);
                dgvUsers.DataSource = userTable;
            }

            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.ReadOnly = true;
        }

        private void PerformSearch()
        {
            string filter = txtSearch.Text.Trim();
            DataView dv = new DataView(userTable);

            if (string.IsNullOrEmpty(filter))
            {
                dgvUsers.DataSource = userTable;
            }
            else
            {
                dv.RowFilter = $"Email LIKE '%{filter}%'";
                dgvUsers.DataSource = dv;
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            PerformSearch();
        }

        /// <summary>
        /// Retrieves the numeric user ID from the selected row's underlying DataRow.
        /// </summary>
        /// <returns>The numeric user ID.</returns>
        private int GetSelectedUserId()
        {
            if (dgvUsers.SelectedRows.Count == 0)
                throw new Exception("No row selected.");

            // Retrieve the underlying DataRowView to get the actual data from the DataTable.
            DataRowView drv = (DataRowView)dgvUsers.SelectedRows[0].DataBoundItem;
            return Convert.ToInt32(drv["ID"]);
        }

        private void btnDisableUser_Click_1(object sender, EventArgs e)
        {
            int userId;
            try
            {
                userId = GetSelectedUserId();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving user ID: " + ex.Message);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Users SET IsDisabled = 1 WHERE ID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadUsers();
            MessageBox.Show("User has been disabled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEnableUser_Click_1(object sender, EventArgs e)
        {
            int userId;
            try
            {
                userId = GetSelectedUserId();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving user ID: " + ex.Message);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Users SET IsDisabled = 0 WHERE ID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.ExecuteNonQuery();
                }
            }

            LoadUsers();
            MessageBox.Show("User has been enabled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDisableAllUsers_Click_1(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to disable all users?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Users SET IsDisabled = 1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            LoadUsers();
            MessageBox.Show("All users have been disabled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEnableAllUsers_Click_1(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to enable all users?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Users SET IsDisabled = 0";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            LoadUsers();
            MessageBox.Show("All users have been enabled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteUser_Click_1(object sender, EventArgs e)
        {
            string userId;
            try
            {
                userId = GetSelectedUserId().ToString();  // Convert user ID to string since DB uses NVARCHAR
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving user ID: " + ex.Message);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this user? This will remove their order history and cart data.",
                                          "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Delete user's cart data
                string deleteCart = "DELETE FROM CartItems WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(deleteCart, conn))
                {
                    cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 50).Value = userId;
                    cmd.ExecuteNonQuery();
                }

                // Delete user's orders (ensure NVARCHAR matching)
                string deleteOrders = "DELETE FROM Orders WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(deleteOrders, conn))
                {
                    cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 50).Value = userId;
                    cmd.ExecuteNonQuery();
                }

                // Delete the user from Users table
                string deleteUser = "DELETE FROM Users WHERE ID = @UserID";
                using (SqlCommand cmd = new SqlCommand(deleteUser, conn))
                {
                    cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 50).Value = userId;
                    cmd.ExecuteNonQuery();
                }
            }

            LoadUsers();
            MessageBox.Show("User has been deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteAllUsers_Click_1(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to delete ALL users? This will remove all order history and cart data.",
                                          "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Delete all cart data
                string deleteCart = "DELETE FROM CartItems";
                using (SqlCommand cmd = new SqlCommand(deleteCart, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Delete all orders (ensuring UserID is handled as NVARCHAR)
                string deleteOrders = "DELETE FROM Orders";
                using (SqlCommand cmd = new SqlCommand(deleteOrders, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Delete all users
                string deleteUser = "DELETE FROM Users";
                using (SqlCommand cmd = new SqlCommand(deleteUser, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            LoadUsers();
            MessageBox.Show("All users have been deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 Form1 = new Form1();
            Form1.Show();
        }
    }
}
