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
    public partial class EnergyChartForm : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public EnergyChartForm()
        {
            InitializeComponent();
            LoadMonthChart(); // Default view is monthly
        }

        private void LoadMonthChart()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Query to fetch the average energy usage for each month
                    string query = @"
                        SELECT DATENAME(MONTH, Date) AS MonthName, 
                               DATEPART(MONTH, Date) AS MonthNumber, 
                               AVG(EnergyUsage) AS AvgEnergyUsage
                        FROM [Table]
                        GROUP BY DATENAME(MONTH, Date), DATEPART(MONTH, Date), DATEPART(YEAR, Date)
                        ORDER BY DATEPART(YEAR, Date), MonthNumber";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Clear existing data and set up the chart
                    energyChart.Series.Clear();
                    Series series = new Series("Average Energy Usage by Month")
                    {
                        ChartType = SeriesChartType.Line, // Line chart for monthly view
                        XValueType = ChartValueType.String
                    };

                    foreach (DataRow row in dataTable.Rows)
                    {
                        series.Points.AddXY(row["MonthName"].ToString(), Convert.ToDouble(row["AvgEnergyUsage"]));
                    }

                    energyChart.Series.Add(series);
                    energyChart.ChartAreas[0].AxisX.Title = "Month";
                    energyChart.ChartAreas[0].AxisY.Title = "Average Energy Usage (W)";
                    energyChart.Titles.Clear();
                    energyChart.Titles.Add("Comparison of Average Energy Usage by Month");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the monthly chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadWeekChart()
        {
            try
            {
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

                    // Query to fetch weekly data for the latest month
                    string query = @"
                SELECT CONCAT('Week ', DATEPART(WEEK, Date), ' (', DATENAME(MONTH, Date), ')') AS WeekLabel, 
                       AVG(EnergyUsage) AS AvgEnergyUsage
                FROM [Table]
                WHERE DATEPART(MONTH, Date) = @LatestMonth AND DATEPART(YEAR, Date) = @LatestYear
                GROUP BY DATEPART(WEEK, Date), DATENAME(MONTH, Date)
                ORDER BY DATEPART(WEEK, Date)";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@LatestMonth", latestMonth);
                    adapter.SelectCommand.Parameters.AddWithValue("@LatestYear", latestYear);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No data available for the latest month's weeks.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Populate the chart with weekly data
                    energyChart.Series.Clear();
                    Series series = new Series("Average Energy Usage by Week")
                    {
                        ChartType = SeriesChartType.Line, // Line chart for weekly data
                        XValueType = ChartValueType.String
                    };

                    foreach (DataRow row in dataTable.Rows)
                    {
                        series.Points.AddXY(row["WeekLabel"].ToString(), Convert.ToDouble(row["AvgEnergyUsage"]));
                    }

                    energyChart.Series.Add(series);
                    energyChart.ChartAreas[0].AxisX.Title = "Week in Latest Month";
                    energyChart.ChartAreas[0].AxisY.Title = "Average Energy Usage (W)";
                    energyChart.Titles.Clear();
                    energyChart.Titles.Add("Energy Usage Throughout the Latest Month by Week");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the weekly chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDayChart(string selectedDate, string viewOption)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query;

                    if (viewOption == "Whole Day")
                    {
                        query = "SELECT Time, EnergyUsage FROM [Table] WHERE CONVERT(VARCHAR, Date, 101) = @SelectedDate ORDER BY Time ASC";
                    }
                    else if (viewOption == "Highest Percentage")
                    {
                        query = @"
                            SELECT Time, EnergyUsage 
                            FROM [Table] 
                            WHERE CONVERT(VARCHAR, Date, 101) = @SelectedDate 
                              AND EnergyUsage = (SELECT MAX(EnergyUsage) 
                                                 FROM [Table] 
                                                 WHERE CONVERT(VARCHAR, Date, 101) = @SelectedDate)";
                    }
                    else if (viewOption == "Lowest Percentage")
                    {
                        query = @"
                            SELECT Time, EnergyUsage 
                            FROM [Table] 
                            WHERE CONVERT(VARCHAR, Date, 101) = @SelectedDate 
                              AND EnergyUsage = (SELECT MIN(EnergyUsage) 
                                                 FROM [Table] 
                                                 WHERE CONVERT(VARCHAR, Date, 101) = @SelectedDate)";
                    }
                    else
                    {
                        MessageBox.Show("Invalid view option selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@SelectedDate", selectedDate);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    energyChart.Series.Clear();
                    Series series = new Series("Daily Energy Usage")
                    {
                        ChartType = SeriesChartType.Column,
                        XValueType = ChartValueType.String
                    };

                    foreach (DataRow row in dataTable.Rows)
                    {
                        series.Points.AddXY(row["Time"].ToString(), Convert.ToDouble(row["EnergyUsage"]));
                    }

                    energyChart.Series.Add(series);
                    energyChart.ChartAreas[0].AxisX.Title = "Time (Hour)";
                    energyChart.ChartAreas[0].AxisY.Title = "Energy Usage (W)";
                    energyChart.Titles.Clear();
                    energyChart.Titles.Add($"Energy Usage for {selectedDate} ({viewOption})");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the daily chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBackToHome2_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Close();
        }

        private void cmbDaySelectorEnergy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadMonthAnalysisChart(string selectedMonth, string filterOption)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query;

                    // Select the appropriate query based on the filter option
                    if (filterOption == "Highest Week")
                    {
                        query = @"
                    SELECT TOP 1 CONCAT('Week ', DATEPART(WEEK, Date)) AS WeekLabel, SUM(EnergyUsage) AS TotalEnergyUsage
                    FROM [Table]
                    WHERE FORMAT(Date, 'yyyy-MM') = @SelectedMonth
                    GROUP BY DATEPART(WEEK, Date)
                    ORDER BY TotalEnergyUsage DESC";
                    }
                    else if (filterOption == "Lowest Week")
                    {
                        query = @"
                    SELECT TOP 1 CONCAT('Week ', DATEPART(WEEK, Date)) AS WeekLabel, SUM(EnergyUsage) AS TotalEnergyUsage
                    FROM [Table]
                    WHERE FORMAT(Date, 'yyyy-MM') = @SelectedMonth
                    GROUP BY DATEPART(WEEK, Date)
                    ORDER BY TotalEnergyUsage ASC";
                    }
                    else // Whole View
                    {
                        query = @"
                    SELECT CONCAT('Week ', DATEPART(WEEK, Date)) AS WeekLabel, SUM(EnergyUsage) AS TotalEnergyUsage
                    FROM [Table]
                    WHERE FORMAT(Date, 'yyyy-MM') = @SelectedMonth
                    GROUP BY DATEPART(WEEK, Date)
                    ORDER BY DATEPART(WEEK, Date)";
                    }

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SelectedMonth", selectedMonth);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No data available for the selected month.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Configure chart to use bar chart
                    energyChart.Series.Clear();
                    Series series = new Series("Energy Usage")
                    {
                        ChartType = SeriesChartType.Column, // Set to bar chart
                        XValueType = ChartValueType.String
                    };

                    foreach (DataRow row in dataTable.Rows)
                    {
                        series.Points.AddXY(row["WeekLabel"].ToString(), Convert.ToDouble(row["TotalEnergyUsage"]));
                    }

                    energyChart.Series.Add(series);
                    energyChart.ChartAreas[0].AxisX.Title = "Week";
                    energyChart.ChartAreas[0].AxisY.Title = "Total Energy Usage (W)";
                    energyChart.Titles.Clear();
                    energyChart.Titles.Add($"Energy Usage for {selectedMonth} ({filterOption})");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnDayEnergy_Click(object sender, EventArgs e)
        {
            MonthEnergyPromptForm monthPrompt = new MonthEnergyPromptForm();
            if (monthPrompt.ShowDialog() == DialogResult.OK)
            {
                string selectedMonth = monthPrompt.SelectedMonth;
                string filterOption = monthPrompt.SelectedFilter;
                LoadMonthAnalysisChart(selectedMonth, filterOption);
            }
        }

        private void btnWeekEnergy_Click(object sender, EventArgs e)
        {
            LoadWeekChart();
        }

        private void btnMonthEnergy_Click(object sender, EventArgs e)
        {
            LoadMonthChart();
        }

        private void EnergyChartForm_Load(object sender, EventArgs e)
        {

        }
    }
}
