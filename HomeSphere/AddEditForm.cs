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

namespace HomeSphere
{
    public partial class AddEditForm : Form
    {
        private readonly bool isEditMode;
        private readonly int? recordId; // Nullable in case it's an Add operation
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public AddEditForm(bool isEditMode, int? recordId = null)
        {
            InitializeComponent();
            this.isEditMode = isEditMode;
            this.recordId = recordId;

            // Configure the ComboBox
            cmbDayOfWeek.DropDownStyle = ComboBoxStyle.DropDownList; // Restrict to selection only
            cmbDayOfWeek.Items.AddRange(new string[]
            {
                "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
            });

            // Configure the time picker
            dtpTime.Format = DateTimePickerFormat.Time;
            dtpTime.ShowUpDown = true;
        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {
            if (isEditMode && recordId.HasValue)
            {
                LoadRecordData(recordId.Value); // Load data for editing
            }
            else
            {
                dtpDate_ValueChanged(null, null); // Trigger day-of-week synchronization
            }
        }

        private void LoadRecordData(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT LightUsage, EnergyUsage, Date, DayOfWeek, Time FROM [Table] WHERE SensorDataID = @SensorDataID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SensorDataID", id);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        numLightUsage.Value = Convert.ToDecimal(reader["LightUsage"]);
                        numEnergyUsage.Value = Convert.ToDecimal(reader["EnergyUsage"]);
                        dtpDate.Value = Convert.ToDateTime(reader["Date"]); // Assuming there's a DateTimePicker for Date
                        cmbDayOfWeek.Text = reader["DayOfWeek"].ToString();
                        dtpTime.Text = reader["Time"].ToString();
                    }
                }
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            // Automatically update the DayOfWeek ComboBox based on the selected date
            cmbDayOfWeek.SelectedItem = dtpDate.Value.DayOfWeek.ToString();
        }

        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            // Handle time changes if needed (currently no additional logic required)
        }

        private void numLightUsage_ValueChanged(object sender, EventArgs e)
        {
            // Handle light usage changes if needed (currently no additional logic required)
        }

        private void numEnergyUsage_ValueChanged(object sender, EventArgs e)
        {
            // Handle energy usage changes if needed (currently no additional logic required)
        }

        private void cmbDayOfWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Prevent manual mismatch: force the DayOfWeek to match the selected date
            if (cmbDayOfWeek.SelectedItem != null &&
                !cmbDayOfWeek.SelectedItem.ToString().Equals(dtpDate.Value.DayOfWeek.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("The Day of the Week must match the selected Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDayOfWeek.SelectedItem = dtpDate.Value.DayOfWeek.ToString();
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                if (isEditMode && recordId.HasValue)
                {
                    UpdateRecord(recordId.Value);
                }
                else
                {
                    AddNewRecord();
                }

                this.DialogResult = DialogResult.OK; // Close form and indicate success
                this.Close();
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(cmbDayOfWeek.Text))
            {
                MessageBox.Show("Day of the Week is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(dtpTime.Text))
            {
                MessageBox.Show("Time is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void AddNewRecord()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Check for duplicate entries in the application logic
                string checkQuery = "SELECT COUNT(*) FROM [Table] WHERE Date = @Date AND Time = @Time";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@Date", dtpDate.Value.Date);
                checkCommand.Parameters.AddWithValue("@Time", dtpTime.Text);

                connection.Open();
                int count = (int)checkCommand.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("A record for this date and time already exists. Please update the existing record instead.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Exit without inserting
                }

                // Insert new record
                string query = "INSERT INTO [Table] (LightUsage, EnergyUsage, Date, DayOfWeek, Time) VALUES (@LightUsage, @EnergyUsage, @Date, @DayOfWeek, @Time)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LightUsage", numLightUsage.Value);
                command.Parameters.AddWithValue("@EnergyUsage", numEnergyUsage.Value);
                command.Parameters.AddWithValue("@Date", dtpDate.Value.Date);
                command.Parameters.AddWithValue("@DayOfWeek", cmbDayOfWeek.Text);
                command.Parameters.AddWithValue("@Time", dtpTime.Text);

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Record added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex) when (ex.Number == 2627) // SQL Server error for unique constraint violation
                {
                    MessageBox.Show("This entry already exists in the database. Please update the existing record or use a different time.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateRecord(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE [Table] SET LightUsage = @LightUsage, EnergyUsage = @EnergyUsage, Date = @Date, DayOfWeek = @DayOfWeek, Time = @Time WHERE SensorDataID = @SensorDataID";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@LightUsage", numLightUsage.Value);
                command.Parameters.AddWithValue("@EnergyUsage", numEnergyUsage.Value);
                command.Parameters.AddWithValue("@Date", dtpDate.Value);
                command.Parameters.AddWithValue("@DayOfWeek", cmbDayOfWeek.Text);
                command.Parameters.AddWithValue("@Time", dtpTime.Text);
                command.Parameters.AddWithValue("@SensorDataID", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Close form without saving
            this.Close();
        }
    }
}