using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HomeSphere
{
    public partial class UserEnergyGraph : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public string SelectedDate => dtpSelectedDate.Value.ToString("dd MM yyyy");
        public UserEnergyGraph()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads energy usage data for a specific date.
        /// The user can only view the full day trend.
        /// </summary>
        private void LoadUserSpecificDayChart(string selectedDate)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT FORMAT(Timestamp, 'HH:mm:ss') AS Time, (Voltage * 0.5) AS EnergyUsage
                        FROM LEDSensorData
                        WHERE FORMAT(Timestamp, 'dd MM yyyy') = @SelectedDate
                        ORDER BY Timestamp ASC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@SelectedDate", selectedDate);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No data available for the selected day.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Clear old chart data and create new series
                    energyChart.Series.Clear();
                    Series series = new Series("Daily Energy Usage")
                    {
                        XValueType = ChartValueType.String,
                        ChartType = SeriesChartType.Line
                    };

                    foreach (DataRow row in dataTable.Rows)
                    {
                        double usage = Convert.ToDouble(row["EnergyUsage"]);
                        string timeLabel = row["Time"].ToString();
                        series.Points.AddXY(timeLabel, usage);
                    }

                    energyChart.Series.Add(series);

                    // Chart styling
                    energyChart.ChartAreas[0].AxisX.Title = "Time (HH:mm:ss)";
                    energyChart.ChartAreas[0].AxisY.Title = "Energy Usage (W)";
                    energyChart.Titles.Clear();
                    energyChart.Titles.Add($"Energy Usage for {selectedDate}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the daily chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Button Click Handlers ---

        private void btnViewEnergy_Click(object sender, EventArgs e)
        {
            UserEnergyGraph dayPrompt = new UserEnergyGraph();
            if (dayPrompt.ShowDialog() == DialogResult.OK)
            {
                string selectedDate = dayPrompt.SelectedDate; // "dd MM yyyy"
                LoadUserSpecificDayChart(selectedDate);
            }
        }

        private void UserEnergyChartForm_Load(object sender, EventArgs e)
        {
            // (Optional additional initialization)
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnViewEnergy_Click_1(object sender, EventArgs e)
        {
            string selectedDate = dtpSelectedDate.Value.ToString("dd MM yyyy"); // Get the date from DateTimePicker
            LoadUserSpecificDayChart(selectedDate);
        }
    }
}
