using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace HomeSphere
{
    public partial class frmAdminDashboard : Form
    {
        public frmAdminDashboard()
        {
            InitializeComponent();
            LoadAlerts(); // Load alerts from the database when the form loads
        }

        // Load alerts into DataGridView
        private void LoadAlerts()
        {
            dgvAlerts.AllowUserToAddRows = false; // Disable the "add new row" option

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT ID, Message, IsActive, CreatedAt FROM Alerts";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvAlerts.DataSource = dt; // Bind data to DataGridView
                }
            }
        }

        // Create a new alert
        private void btnCreate_Click(object sender, EventArgs e)
        {
            string message = tbAlertMessage.Text.Trim();

            if (string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("Alert message cannot be empty.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    conn.Open();

                    // Check for duplicate messages
                    string checkQuery = "SELECT COUNT(1) FROM Alerts WHERE Message = @Message";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Message", message);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("This alert message already exists. Please use a different message.");
                            return;
                        }
                    }

                    // Insert new alert
                    string query = "INSERT INTO Alerts (Message, IsActive, CreatedAt) VALUES (@Message, 0, GETDATE())";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Message", message);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Alert created successfully!");

                // Clear the text field
                tbAlertMessage.Text = string.Empty;

                // Refresh the DataGridView
                LoadAlerts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating alert: {ex.Message}");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Hide the current form and return to the admin home page
            this.Hide();
            frmAdminHomePage adminHomePage = new frmAdminHomePage();
            adminHomePage.Show();
        }

        private void dgvAlerts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked row index is valid
            if (e.RowIndex >= 0 && dgvAlerts.Rows[e.RowIndex].Cells["ID"].Value != null)
            {
                try
                {
                    // Safely retrieve and convert values
                    int alertId = dgvAlerts.Rows[e.RowIndex].Cells["ID"].Value != DBNull.Value
                        ? Convert.ToInt32(dgvAlerts.Rows[e.RowIndex].Cells["ID"].Value)
                        : 0;

                    string currentMessage = dgvAlerts.Rows[e.RowIndex].Cells["Message"].Value?.ToString() ?? string.Empty;

                    bool isActive = dgvAlerts.Rows[e.RowIndex].Cells["IsActive"].Value != DBNull.Value &&
                                    Convert.ToBoolean(dgvAlerts.Rows[e.RowIndex].Cells["IsActive"].Value);

                    // Open the edit alert form with the retrieved data
                    using (frmEditAlert editAlertForm = new frmEditAlert(alertId, currentMessage, isActive))
                    {
                        if (editAlertForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadAlerts(); // Refresh the DataGridView after editing
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log and handle unexpected errors
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid row selected. Please select a valid row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }

}

