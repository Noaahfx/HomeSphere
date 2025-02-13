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
using System.Windows.Forms.DataVisualization.Charting;


namespace Keith_admindashboard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadLightingChart();
            LoadEnergyChart();
        }

        private void LoadLightingChart()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Query to fetch the latest date from the table
                string latestDateQuery = "SELECT MAX(Date) FROM [Table]";
                SqlCommand latestDateCommand = new SqlCommand(latestDateQuery, connection);

                connection.Open();
                var latestDate = latestDateCommand.ExecuteScalar();
                connection.Close();

                if (latestDate != DBNull.Value)
                {
                    // Query to fetch data for the latest date
                    string query = "SELECT Time, LightUsage FROM [Table] WHERE Date = @LatestDate ORDER BY Time ASC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@LatestDate", latestDate);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    lighting.Series.Clear(); // Clear existing series

                    Series series = new Series("Light Usage")
                    {
                        ChartType = SeriesChartType.Column,
                        XValueType = ChartValueType.String // Time stored as a string
                    };

                    foreach (DataRow row in dataTable.Rows)
                    {
                        series.Points.AddXY(row["Time"].ToString(), Convert.ToDouble(row["LightUsage"]));
                    }

                    lighting.Series.Add(series);
                    lighting.ChartAreas[0].AxisX.Title = "Time (Hour)";
                    lighting.ChartAreas[0].AxisY.Title = "Light Usage (%)";
                    lighting.Titles.Clear();
                    lighting.Titles.Add("Light Usage Throughout the Latest Day");
                }
                else
                {
                    MessageBox.Show("No data available in the table.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void LoadEnergyChart()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Identify the latest month and year from the table
                    string latestMonthQuery = @"
                SELECT DATEPART(MONTH, MAX(Date)) AS LatestMonth, 
                       DATEPART(YEAR, MAX(Date)) AS LatestYear
                FROM [Table]";

                    SqlCommand latestMonthCommand = new SqlCommand(latestMonthQuery, connection);
                    connection.Open();
                    SqlDataReader reader = latestMonthCommand.ExecuteReader();

                    int latestMonth = 0;
                    int latestYear = 0;
                    if (reader.Read())
                    {
                        latestMonth = reader.GetInt32(0);
                        latestYear = reader.GetInt32(1);
                    }
                    reader.Close();

                    // Query to fetch average weekly energy usage for the latest month
                    string query = @"
                SELECT CONCAT('Week ', DATEPART(WEEK, Date)) AS WeekLabel, 
                       AVG(EnergyUsage) AS AvgEnergyUsage
                FROM [Table]
                WHERE DATEPART(MONTH, Date) = @LatestMonth AND DATEPART(YEAR, Date) = @LatestYear
                GROUP BY DATEPART(WEEK, Date)
                ORDER BY DATEPART(WEEK, Date)";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@LatestMonth", latestMonth);
                    adapter.SelectCommand.Parameters.AddWithValue("@LatestYear", latestYear);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No data available for the latest month.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Populate the energy chart
                    energy.Series.Clear();
                    Series series = new Series("Average Energy Usage by Week (Latest Month)")
                    {
                        ChartType = SeriesChartType.Line, // Display as a line chart
                        XValueType = ChartValueType.String
                    };

                    foreach (DataRow row in dataTable.Rows)
                    {
                        series.Points.AddXY(row["WeekLabel"].ToString(), Convert.ToDouble(row["AvgEnergyUsage"]));
                    }

                    energy.Series.Add(series);
                    energy.ChartAreas[0].AxisX.Title = "Week in Latest Month";
                    energy.ChartAreas[0].AxisY.Title = "Average Energy Usage (W)";
                    energy.Titles.Clear();
                    energy.Titles.Add($"Energy Usage Throughout {new DateTime(latestYear, latestMonth, 1).ToString("MMMM yyyy")} (Latest Data)");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the default energy chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lighting_Click(object sender, EventArgs e)
        {
            string latestDate = GetLatestDate(); // Call a helper function to fetch the latest date
            LightingChartForm lightingChartForm = new LightingChartForm(latestDate);
            lightingChartForm.Show();
            this.Hide();
        }

        // Helper function to get the latest date
        private string GetLatestDate()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 1 CONVERT(VARCHAR, Date, 101) AS LatestDate FROM [Table] ORDER BY Date DESC";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                return command.ExecuteScalar()?.ToString(); // Get the latest date as a string
            }
        }


        private void energy_Click(object sender, EventArgs e)
        {
            // Navigate to EnergyChartForm
            EnergyChartForm energyChartForm = new EnergyChartForm();
            energyChartForm.Show();
            this.Hide(); // Hide the current Form1
        }

        private void Home_Click(object sender, EventArgs e)
        {

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
            // Open the TableManagement form
            TableManagement tableManagement = new TableManagement();
            tableManagement.Show();
            this.Hide(); // Optional: Hides the main form while TableManagement is open
        }
    }
}
