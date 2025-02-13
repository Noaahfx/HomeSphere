using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Keith_admindashboard
{
    public partial class TableManagement : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public TableManagement()
        {
            InitializeComponent();
            LoadRecords(); // Load data into DataGridView when the form loads
        }

        private void LoadRecords()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM [Table]";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvRecords.DataSource = dataTable; // Use dgvRecords here
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading records: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Home_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Close(); // Close current form
        }

        private void Overview_Click(object sender, EventArgs e)
        {
            OverviewForm overviewForm = new OverviewForm();
            overviewForm.Show();
            this.Hide();
        }

        private void Logout_Click(object sender, EventArgs e)
        {

        }

        private void ManageRecords_Click(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            using (AddEditForm addForm = new AddEditForm(false)) // Add mode
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadRecords(); // Reload DataGridView
                }
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (dgvRecords.CurrentRow != null)
            {
                int recordId = Convert.ToInt32(dgvRecords.CurrentRow.Cells["SensorDataID"].Value);
                using (AddEditForm editForm = new AddEditForm(true, recordId)) // Edit mode
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadRecords(); // Reload DataGridView
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a record to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (dgvRecords.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvRecords.SelectedRows[0].Cells["SensorDataID"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "DELETE FROM [Table] WHERE SensorDataID = @id";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@id", id);
                            connection.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Record deleted successfully.", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadRecords();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            LoadRecords(); // Reload records

        }
    }
}
