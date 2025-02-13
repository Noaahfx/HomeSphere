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

namespace HomeSphere
{
    public partial class LightingChartForm : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private readonly string latestDate; // Store the latest date passed from Form1

        // Constructor to accept the latest date
        public LightingChartForm(string latestDate)
        {
            InitializeComponent();
            this.latestDate = latestDate; // Assign the parameter to the class field
            LoadDayChart(); // Load the chart data for the day by default
        }

        private void LoadDayChart()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Time, LightUsage FROM [Table] WHERE CONVERT(VARCHAR, Date, 101) = @LatestDate ORDER BY Time ASC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@LatestDate", latestDate);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    lightingChart.Series.Clear(); // Clear existing series

                    Series series = new Series("Light Usage")
                    {
                        ChartType = SeriesChartType.Column,
                        XValueType = ChartValueType.String // Time stored as a string
                    };

                    foreach (DataRow row in dataTable.Rows)
                    {
                        series.Points.AddXY(row["Time"].ToString(), Convert.ToDouble(row["LightUsage"]));
                    }

                    lightingChart.Series.Add(series);
                    lightingChart.ChartAreas[0].AxisX.Title = "Time (Hour)";
                    lightingChart.ChartAreas[0].AxisY.Title = "Light Usage (%)";
                    lightingChart.Titles.Clear();
                    lightingChart.Titles.Add($"Light Usage Throughout the Day ({latestDate})");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadWeekChart()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT DATEPART(WEEK, Date) AS WeekNumber, FORMAT(MIN(Date), 'MMMM') AS MonthName, AVG(LightUsage) AS AvgLightUsage
                FROM [Table]
                GROUP BY DATEPART(WEEK, Date), FORMAT(Date, 'MMMM')
                ORDER BY MIN(Date)";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    lightingChart.Series.Clear(); // Clear existing series

                    Series series = new Series("Average Light Usage by Week")
                    {
                        ChartType = SeriesChartType.Column,
                        XValueType = ChartValueType.String // Week and month stored as a string
                    };

                    foreach (DataRow row in dataTable.Rows)
                    {
                        string weekLabel = $"Week {row["WeekNumber"]} ({row["MonthName"]})";
                        series.Points.AddXY(weekLabel, Convert.ToDouble(row["AvgLightUsage"]));
                    }

                    lightingChart.Series.Add(series);
                    lightingChart.ChartAreas[0].AxisX.Title = "Week (Month)";
                    lightingChart.ChartAreas[0].AxisY.Title = "Average Light Usage (%)";
                    lightingChart.Titles.Clear();
                    lightingChart.Titles.Add("Weekly Average Light Usage");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the weekly chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMonthChart()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT FORMAT(Date, 'MMMM') AS MonthName, AVG(LightUsage) AS AvgLightUsage
                FROM [Table]
                GROUP BY FORMAT(Date, 'MMMM'), MONTH(Date)
                ORDER BY MONTH(Date)";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    lightingChart.Series.Clear(); // Clear existing series

                    Series series = new Series("Average Light Usage by Month")
                    {
                        ChartType = SeriesChartType.Column,
                        XValueType = ChartValueType.String // Month name stored as string
                    };

                    foreach (DataRow row in dataTable.Rows)
                    {
                        string month = row["MonthName"].ToString();
                        double avgUsage = Convert.ToDouble(row["AvgLightUsage"]);
                        series.Points.AddXY(month, avgUsage);
                    }

                    lightingChart.Series.Add(series);
                    lightingChart.ChartAreas[0].AxisX.Title = "Month";
                    lightingChart.ChartAreas[0].AxisY.Title = "Average Light Usage (%)";
                    lightingChart.Titles.Clear();
                    lightingChart.Titles.Add("Monthly Average Light Usage");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the monthly chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBackToHome1_Click(object sender, EventArgs e)
        {
            // Navigate back to the main form
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Close();
        }

        private void ApplyLargestValuesFilter()
        {
            // Sort and display largest values
            string query = "SELECT TOP 10 Time, LightUsage FROM [Table] ORDER BY LightUsage DESC";
            LoadFilteredChartData(query);
        }

        private void ApplySmallestValuesFilter()
        {
            // Sort and display smallest values
            string query = "SELECT TOP 10 Time, LightUsage FROM [Table] ORDER BY LightUsage ASC";
            LoadFilteredChartData(query);
        }

        private void ApplyTimeRangeFilter()
        {
            // Filter by a time range (e.g., 08:00 - 12:00)
            string query = "SELECT Time, LightUsage FROM [Table] WHERE Time BETWEEN '08:00:00' AND '12:00:00'";
            LoadFilteredChartData(query);
        }

        private void LoadFilteredChartData(string query)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                lightingChart.Series.Clear();
                Series series = new Series("Filtered Light Usage")
                {
                    ChartType = SeriesChartType.Column,
                    XValueType = ChartValueType.String
                };

                foreach (DataRow row in dataTable.Rows)
                {
                    series.Points.AddXY(row["Time"].ToString(), Convert.ToDouble(row["LightUsage"]));
                }

                lightingChart.Series.Add(series);
            }
        }

        private void btnDay_Click(object sender, EventArgs e)
        {
            using (DayFilterForm dayFilterForm = new DayFilterForm())
            {
                if (dayFilterForm.ShowDialog() == DialogResult.OK)
                {
                    // Retrieve user selections
                    DateTime selectedDate = dayFilterForm.SelectedDate;
                    string selectedFilter = dayFilterForm.SelectedFilter;

                    // Load chart based on user input
                    LoadSpecificDayChart(selectedDate, selectedFilter);
                }
            }
        }

        private void LoadSpecificDayChart(DateTime date, string filter)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = string.Empty;

                    switch (filter)
                    {
                        case "Highest Percentage":
                            // Query to fetch all rows with the maximum LightUsage on the selected date
                            query = @"
                        SELECT Time, LightUsage
                        FROM [Table]
                        WHERE Date = @SelectedDate AND LightUsage = (
                            SELECT MAX(LightUsage)
                            FROM [Table]
                            WHERE Date = @SelectedDate
                        )
                        ORDER BY Time ASC";
                            break;

                        case "Lowest Percentage":
                            // Query to fetch all rows with the minimum LightUsage on the selected date
                            query = @"
                        SELECT Time, LightUsage
                        FROM [Table]
                        WHERE Date = @SelectedDate AND LightUsage = (
                            SELECT MIN(LightUsage)
                            FROM [Table]
                            WHERE Date = @SelectedDate
                        )
                        ORDER BY Time ASC";
                            break;

                        default: // "Whole View"
                                 // Query to fetch all rows for the selected date
                            query = @"
                        SELECT Time, LightUsage
                        FROM [Table]
                        WHERE Date = @SelectedDate
                        ORDER BY Time ASC";
                            break;
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@SelectedDate", date);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    lightingChart.Series.Clear(); // Clear existing series

                    Series series = new Series("Light Usage")
                    {
                        ChartType = SeriesChartType.Column,
                        XValueType = ChartValueType.String
                    };

                    foreach (DataRow row in dataTable.Rows)
                    {
                        series.Points.AddXY(row["Time"].ToString(), Convert.ToDouble(row["LightUsage"]));
                    }

                    lightingChart.Series.Add(series);
                    lightingChart.ChartAreas[0].AxisX.Title = "Time (Hour)";
                    lightingChart.ChartAreas[0].AxisY.Title = "Light Usage (%)";
                    lightingChart.Titles.Clear();
                    lightingChart.Titles.Add($"Light Usage on {date.ToString("MMMM dd, yyyy")} ({filter})");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnWeek_Click(object sender, EventArgs e)
        {
            LoadWeekChart();
        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            LoadMonthChart();
        }

        private void LightingChartForm_Load(object sender, EventArgs e)
        {

        }
    }
}
