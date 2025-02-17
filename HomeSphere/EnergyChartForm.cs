using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HomeSphere
{
    public partial class EnergyChartForm : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public EnergyChartForm()
        {
            InitializeComponent();
            // Default load: display the weekly chart (same as on the home page)
            LoadWeekChart();
        }

        /// <summary>
        /// Returns the expression used to compute the week-of-month.
        /// </summary>
        private string WeekOfMonthExpression
        {
            get
            {
                // DATEADD(MONTH, DATEDIFF(MONTH, 0, Timestamp), 0) => first day of that month
                // Subtract the two WEEK values to get the "week index" within the month
                // Then add 1 so that it starts at 1.
                return "(DATEPART(WEEK, Timestamp) - DATEPART(WEEK, DATEADD(MONTH, DATEDIFF(MONTH, 0, Timestamp), 0)) + 1)";
            }
        }

        /// <summary>
        /// Loads data for a specific month ("yyyy-MM") grouped by week-of-month. 
        /// Shows either all weeks (Whole View) or the highest/lowest average.
        /// </summary>
        private void LoadSpecificMonthChart(string selectedMonth, string filter)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Base grouping query
                    string baseQuery = $@"
                        SELECT {WeekOfMonthExpression} AS WeekOfMonth,
                               CONCAT('Week ', {WeekOfMonthExpression}) AS WeekLabel,
                               AVG(Voltage * 0.5) AS AvgEnergyUsage
                        FROM LEDSensorData
                        WHERE FORMAT(Timestamp, 'yyyy-MM') = @SelectedMonth
                        GROUP BY {WeekOfMonthExpression}";

                    string query;

                    if (filter == "Whole View")
                    {
                        query = baseQuery + $@"
                            ORDER BY {WeekOfMonthExpression}";
                    }
                    else if (filter == "Highest View")
                    {
                        query = $@"
                            SELECT TOP 1 WeekLabel, AvgEnergyUsage FROM (
                                {baseQuery}
                            ) AS t
                            ORDER BY AvgEnergyUsage DESC";
                    }
                    else if (filter == "Lowest View")
                    {
                        query = $@"
                            SELECT TOP 1 WeekLabel, AvgEnergyUsage FROM (
                                {baseQuery}
                            ) AS t
                            ORDER BY AvgEnergyUsage ASC";
                    }
                    else
                    {
                        MessageBox.Show("Invalid filter option for month view.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
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

                    // Clear old chart series and add the new data
                    energyChart.Series.Clear();
                    Series series = new Series("Energy Usage by Week")
                    {
                        XValueType = ChartValueType.String,
                        ChartType = (dataTable.Rows.Count == 1) ? SeriesChartType.Column : SeriesChartType.Line
                    };

                    foreach (DataRow row in dataTable.Rows)
                    {
                        series.Points.AddXY(row["WeekLabel"].ToString(), Convert.ToDouble(row["AvgEnergyUsage"]));
                    }

                    energyChart.Series.Add(series);
                    energyChart.ChartAreas[0].AxisX.Title = "Week in Month";
                    energyChart.ChartAreas[0].AxisY.Title = "Average Energy Usage (W)";

                    // Set the chart title to the month name
                    DateTime monthDate = DateTime.ParseExact(selectedMonth, "yyyy-MM", null);
                    energyChart.Titles.Clear();
                    energyChart.Titles.Add($"Energy Usage for {monthDate:MMMM yyyy}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the month chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads weekly data (by week-of-month) for the latest month in the table.
        /// </summary>
        private void LoadWeekChart()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Identify the latest month and year in "yyyy-MM"
                    string latestMonthQuery = @"
                SELECT TOP 1 FORMAT(MAX(Timestamp), 'yyyy-MM') AS LatestMonth,
                               DATENAME(MONTH, MAX(Timestamp)) AS MonthName,
                               DATEPART(YEAR, MAX(Timestamp)) AS LatestYear
                FROM LEDSensorData";

                    SqlCommand latestMonthCommand = new SqlCommand(latestMonthQuery, connection);
                    connection.Open();
                    SqlDataReader reader = latestMonthCommand.ExecuteReader();

                    string latestMonth = "";
                    string latestMonthName = "";
                    int latestYear = 0;

                    if (reader.Read())
                    {
                        latestMonth = reader.GetString(0);  // "yyyy-MM"
                        latestMonthName = reader.GetString(1); // "February"
                        latestYear = reader.GetInt32(2);  // 2025
                    }
                    reader.Close();

                    if (string.IsNullOrEmpty(latestMonth))
                    {
                        MessageBox.Show("No sensor data available.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Group data by dynamically calculated week-of-month
                    string query = $@"
                SELECT DATEPART(WEEK, Timestamp) AS WeekNumber,
                       CONCAT('Week ', DATEPART(WEEK, Timestamp), ' of {latestMonthName}') AS WeekLabel,
                       AVG(Voltage * 0.5) AS AvgEnergyUsage
                FROM LEDSensorData
                WHERE FORMAT(Timestamp, 'yyyy-MM') = @LatestMonth
                GROUP BY DATEPART(WEEK, Timestamp)
                ORDER BY DATEPART(WEEK, Timestamp)";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@LatestMonth", latestMonth);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No data available for the latest month's weeks.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Build the series for the chart
                    energyChart.Series.Clear();
                    Series series = new Series("Weekly Average Energy Usage")
                    {
                        XValueType = ChartValueType.String,
                        ChartType = (dataTable.Rows.Count == 1) ? SeriesChartType.Column : SeriesChartType.Line
                    };

                    foreach (DataRow row in dataTable.Rows)
                    {
                        series.Points.AddXY(row["WeekLabel"].ToString(), Convert.ToDouble(row["AvgEnergyUsage"]));
                    }

                    energyChart.Series.Add(series);
                    energyChart.ChartAreas[0].AxisX.Title = "Week in Latest Month";
                    energyChart.ChartAreas[0].AxisY.Title = "Average Energy Usage (W)";
                    energyChart.Titles.Clear();

                    // Display the dynamic month name in the chart title
                    energyChart.Titles.Add($"Weekly Energy Usage for {latestMonthName} {latestYear}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the weekly chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads data for a specific day ("dd MM yyyy").
        /// - Whole View => line chart
        /// - Highest View => single bar
        /// - Lowest View => single bar
        /// </summary>
        private void LoadSpecificDayChart(string selectedDate, string viewOption)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query;

                    if (viewOption == "Whole View")
                    {
                        // Show entire day's trend (Line chart)
                        query = @"
                            SELECT FORMAT(Timestamp, 'HH:mm:ss') AS Time, (Voltage * 0.5) AS EnergyUsage
                            FROM LEDSensorData
                            WHERE FORMAT(Timestamp, 'dd MM yyyy') = @SelectedDate
                            ORDER BY Timestamp ASC";
                    }
                    else if (viewOption == "Highest View")
                    {
                        // Show only the record(s) with the maximum usage (Bar chart)
                        query = @"
                            SELECT FORMAT(Timestamp, 'HH:mm:ss') AS Time, (Voltage * 0.5) AS EnergyUsage 
                            FROM LEDSensorData
                            WHERE FORMAT(Timestamp, 'dd MM yyyy') = @SelectedDate
                              AND (Voltage * 0.5) = (
                                  SELECT MAX(Voltage * 0.5)
                                  FROM LEDSensorData
                                  WHERE FORMAT(Timestamp, 'dd MM yyyy') = @SelectedDate
                              )";
                    }
                    else if (viewOption == "Lowest View")
                    {
                        // Show only the record(s) with the minimum usage (Bar chart)
                        query = @"
                            SELECT FORMAT(Timestamp, 'HH:mm:ss') AS Time, (Voltage * 0.5) AS EnergyUsage 
                            FROM LEDSensorData
                            WHERE FORMAT(Timestamp, 'dd MM yyyy') = @SelectedDate
                              AND (Voltage * 0.5) = (
                                  SELECT MIN(Voltage * 0.5)
                                  FROM LEDSensorData
                                  WHERE FORMAT(Timestamp, 'dd MM yyyy') = @SelectedDate
                              )";
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

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No data available for the selected day.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Clear old chart data and create new series
                    energyChart.Series.Clear();
                    Series series = new Series("Daily Energy Usage")
                    {
                        XValueType = ChartValueType.String
                    };

                    // For day views:
                    // - "Whole View" => line chart
                    // - "Highest" / "Lowest" => single or possibly multiple columns (bars)
                    if (viewOption == "Whole View")
                    {
                        series.ChartType = SeriesChartType.Line;
                    }
                    else
                    {
                        // Use Column chart type for "Highest" or "Lowest"
                        series.ChartType = SeriesChartType.Column;
                    }

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
                    energyChart.Titles.Add($"Energy Usage for {selectedDate} ({viewOption})");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the daily chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Button Click Handlers ---

        private void btnMonthEnergy_Click(object sender, EventArgs e)
        {
            MonthEnergyPromptForm monthPrompt = new MonthEnergyPromptForm();
            if (monthPrompt.ShowDialog() == DialogResult.OK)
            {
                string selectedMonth = monthPrompt.SelectedMonth; // "yyyy-MM"
                string filter = monthPrompt.SelectedFilter;       // "Whole View", "Highest View", "Lowest View"
                LoadSpecificMonthChart(selectedMonth, filter);
            }
        }

        private void btnWeekEnergy_Click(object sender, EventArgs e)
        {
            LoadWeekChart();
        }

        private void btnDayEnergy_Click(object sender, EventArgs e)
        {
            DayEnergyPromptForm dayPrompt = new DayEnergyPromptForm();
            if (dayPrompt.ShowDialog() == DialogResult.OK)
            {
                string selectedDate = dayPrompt.SelectedDate; // "dd MM yyyy"
                string viewOption = dayPrompt.SelectedFilter; // "Whole View", "Highest View", "Lowest View"
                LoadSpecificDayChart(selectedDate, viewOption);
            }
        }

        private void btnBackToHome2_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Close();
        }

        private void EnergyChartForm_Load(object sender, EventArgs e)
        {
            // (Optional additional initialization)
        }
    }
}
