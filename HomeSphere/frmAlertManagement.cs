using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace HomeSphere
{
    public partial class frmAlertManagement : Form
    {
        public frmAlertManagement()
        {
            InitializeComponent();
            LoadAlerts(); // Load alerts from the database when the form loads
        }

        private void dgvAlerts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }


        // Load alerts into DataGridView
        private void LoadAlerts()
        {
            dgvAlerts.AllowUserToAddRows = false;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT ID, Message, IsActive, StartTime, EndTime, CreatedAt FROM Alerts";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvAlerts.DataSource = dt;
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

            DateTime startTime = dtpStartTime.Value; // Get Start Time from DateTimePicker
            DateTime endTime = dtpEndTime.Value; // Get End Time from DateTimePicker

            if (endTime <= startTime)
            {
                MessageBox.Show("End time must be later than Start time.");
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
                    string query = "INSERT INTO Alerts (Message, IsActive, StartTime, EndTime, CreatedAt) " +
                                   "VALUES (@Message, 0, @StartTime, @EndTime, GETDATE())";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Message", message);
                        cmd.Parameters.AddWithValue("@StartTime", startTime);
                        cmd.Parameters.AddWithValue("@EndTime", endTime);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Scheduled alert created successfully!");

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
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void dgvAlerts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked row index is valid
            if (e.RowIndex >= 0 && dgvAlerts.Rows[e.RowIndex].Cells["ID"].Value != null)
            {
                try
                {
                    int alertId = dgvAlerts.Rows[e.RowIndex].Cells["ID"].Value != DBNull.Value
                        ? Convert.ToInt32(dgvAlerts.Rows[e.RowIndex].Cells["ID"].Value)
                        : 0;

                    string currentMessage = dgvAlerts.Rows[e.RowIndex].Cells["Message"].Value?.ToString() ?? string.Empty;

                    bool isActive = dgvAlerts.Rows[e.RowIndex].Cells["IsActive"].Value != DBNull.Value &&
                                    Convert.ToBoolean(dgvAlerts.Rows[e.RowIndex].Cells["IsActive"].Value);

                    DateTime startTime = dgvAlerts.Rows[e.RowIndex].Cells["StartTime"].Value != DBNull.Value
                        ? Convert.ToDateTime(dgvAlerts.Rows[e.RowIndex].Cells["StartTime"].Value)
                        : DateTime.Now;

                    DateTime endTime = dgvAlerts.Rows[e.RowIndex].Cells["EndTime"].Value != DBNull.Value
                        ? Convert.ToDateTime(dgvAlerts.Rows[e.RowIndex].Cells["EndTime"].Value)
                        : DateTime.Now.AddHours(1);

                    // ✅ If clicking on "IsActive" column, toggle status
                    if (e.ColumnIndex == dgvAlerts.Columns["IsActive"].Index)
                    {
                        bool newIsActive = !isActive; // Toggle the checkbox state

                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                        {
                            conn.Open();

                            string updateQuery = "UPDATE Alerts SET IsActive = @IsActive WHERE ID = @ID";

                            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@IsActive", newIsActive ? 1 : 0);
                                cmd.Parameters.AddWithValue("@ID", alertId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show($"Alert {alertId} is now {(newIsActive ? "Active" : "Inactive")}.", "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAlerts(); // Refresh the DataGridView
                    }
                    else
                    {
                        // ✅ Open Edit Form for other columns
                        using (frmEditAlert editAlertForm = new frmEditAlert(alertId, currentMessage, isActive, startTime, endTime))
                        {
                            if (editAlertForm.ShowDialog() == DialogResult.OK)
                            {
                                LoadAlerts(); // Refresh DataGridView after editing
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
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

