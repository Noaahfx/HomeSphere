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
    public partial class OverviewForm : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public OverviewForm()
        {
            InitializeComponent();
            LoadOverviewInsights(); // Load default overview insights on form load
            LoadTemperatureOverview();
        }

        private void LoadOverviewInsights()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Ensure the connection is open

                    string selectedSortOption = "Month";

                    // Check the current sorting option
                    if (cmbOverviewSort.SelectedItem != null)
                    {
                        selectedSortOption = cmbOverviewSort.SelectedItem.ToString();
                    }

                    if (selectedSortOption == "Month")
                    {
                        LoadMonthlyInsights(connection);
                    }
                    else if (selectedSortOption == "Week")
                    {
                        LoadWeeklyInsights(connection);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the overview: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadTemperatureOverview()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectedOption = "Overall Trend"; // Default selection
                    if (cmbTemperatureFilter.SelectedItem != null)
                    {
                        selectedOption = cmbTemperatureFilter.SelectedItem.ToString();
                    }

                    double latestWeekAvg = 0, previousWeeksAvg = 0, highestTemp = 0, lowestTemp = 0;
                    string latestWeekLabel = "", latestWeekMonth = "", highestTempTime = "", lowestTempTime = "", highestTempDate = "", lowestTempDate = "";

                    // Query for the latest week's average temperature
                    string latestWeekQuery = @"
            SELECT AVG(Temperature) AS AvgTemp,
                   CONCAT('Week ', DATEPART(WEEK, MAX(Timestamp))) AS WeekLabel,
                   DATENAME(MONTH, MAX(Timestamp)) AS MonthName
            FROM TemperatureSensorData
            WHERE DATEPART(WEEK, Timestamp) = (SELECT MAX(DATEPART(WEEK, Timestamp))
                                               FROM TemperatureSensorData
                                               WHERE FORMAT(Timestamp, 'yyyy-MM') = FORMAT(GETDATE(), 'yyyy-MM'))
              AND FORMAT(Timestamp, 'yyyy-MM') = FORMAT(GETDATE(), 'yyyy-MM')";

                    using (SqlCommand cmd = new SqlCommand(latestWeekQuery, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            latestWeekAvg = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                            latestWeekLabel = reader.IsDBNull(1) ? "N/A" : reader.GetString(1);
                            latestWeekMonth = reader.IsDBNull(2) ? "N/A" : reader.GetString(2);
                        }
                    }

                    // Query for the previous weeks' average temperature
                    string previousWeeksQuery = @"
            SELECT AVG(Temperature) AS AvgTemp
            FROM TemperatureSensorData
            WHERE DATEPART(WEEK, Timestamp) < (SELECT MAX(DATEPART(WEEK, Timestamp))
                                               FROM TemperatureSensorData
                                               WHERE FORMAT(Timestamp, 'yyyy-MM') = FORMAT(GETDATE(), 'yyyy-MM'))
              AND FORMAT(Timestamp, 'yyyy-MM') = FORMAT(GETDATE(), 'yyyy-MM')";

                    using (SqlCommand cmd = new SqlCommand(previousWeeksQuery, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            previousWeeksAvg = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                        }
                    }

                    // Query for the highest temperature in the latest week
                    string highestTempQuery = @"
            SELECT TOP 1 Temperature, FORMAT(Timestamp, 'hh:mm tt') AS HighTime, FORMAT(Timestamp, 'yyyy-MM-dd') AS HighDate
            FROM TemperatureSensorData
            WHERE DATEPART(WEEK, Timestamp) = (SELECT MAX(DATEPART(WEEK, Timestamp))
                                               FROM TemperatureSensorData
                                               WHERE FORMAT(Timestamp, 'yyyy-MM') = FORMAT(GETDATE(), 'yyyy-MM'))
            ORDER BY Temperature DESC";

                    using (SqlCommand cmd = new SqlCommand(highestTempQuery, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            highestTemp = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                            highestTempTime = reader.IsDBNull(1) ? "N/A" : reader.GetString(1);
                            highestTempDate = reader.IsDBNull(2) ? "N/A" : reader.GetString(2);
                        }
                    }

                    // Query for the lowest temperature in the latest week
                    string lowestTempQuery = @"
            SELECT TOP 1 Temperature, FORMAT(Timestamp, 'hh:mm tt') AS LowTime, FORMAT(Timestamp, 'yyyy-MM-dd') AS LowDate
            FROM TemperatureSensorData
            WHERE DATEPART(WEEK, Timestamp) = (SELECT MAX(DATEPART(WEEK, Timestamp))
                                               FROM TemperatureSensorData
                                               WHERE FORMAT(Timestamp, 'yyyy-MM') = FORMAT(GETDATE(), 'yyyy-MM'))
            ORDER BY Temperature ASC";

                    using (SqlCommand cmd = new SqlCommand(lowestTempQuery, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lowestTemp = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                            lowestTempTime = reader.IsDBNull(1) ? "N/A" : reader.GetString(1);
                            lowestTempDate = reader.IsDBNull(2) ? "N/A" : reader.GetString(2);
                        }
                    }

                    string overviewText = "";

                    if (selectedOption == "Overall Trend")
                    {
                        // Calculate percentage change
                        double percentageChange = previousWeeksAvg != 0
                            ? ((latestWeekAvg - previousWeeksAvg) / previousWeeksAvg) * 100
                            : 0;

                        // Format the output
                        overviewText = $"In {latestWeekLabel} of {latestWeekMonth}, the average temperature ";
                        if (percentageChange > 0)
                        {
                            overviewText += $"increased by {Math.Round(percentageChange, 2)}% ";
                        }
                        else if (percentageChange < 0)
                        {
                            overviewText += $"decreased by {Math.Abs(Math.Round(percentageChange, 2))}% ";
                        }
                        else
                        {
                            overviewText += "remained constant ";
                        }
                        overviewText += $"compared to the previous weeks.";
                    }
                    else if (selectedOption == "Highest Point in the Day")
                    {
                        overviewText = $"The highest temperature recorded in **{latestWeekLabel} of {latestWeekMonth}** was **{highestTemp}°C** at **{highestTempTime}** on **{highestTempDate}**.";
                    }
                    else if (selectedOption == "Lowest Point in the Day")
                    {
                        overviewText = $"The lowest temperature recorded in **{latestWeekLabel} of {latestWeekMonth}** was **{lowestTemp}°C** at **{lowestTempTime}** on **{lowestTempDate}**.";
                    }

                    lblTemperatureOverviewText.Text = overviewText;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the temperature insights: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void LoadMonthlyInsights(SqlConnection connection)
        {
            try
            {
                double latestMonthAvg = 0, previousMonthAvg = 0;
                string latestMonthName = "", previousMonthName = "", spikeWeekLabel = "";

                // Query for latest month energy usage
                string latestMonthQuery = @"
        SELECT AVG(Voltage * 0.5) AS AvgEnergy, DATENAME(MONTH, MAX(Timestamp)) AS MonthName
        FROM LEDSensorData
        WHERE FORMAT(Timestamp, 'yyyy-MM') = FORMAT(GETDATE(), 'yyyy-MM')";

                using (SqlCommand cmd = new SqlCommand(latestMonthQuery, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        latestMonthAvg = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                        latestMonthName = reader.IsDBNull(1) ? "N/A" : reader.GetString(1);
                    }
                }

                // Query for previous month energy usage
                string previousMonthQuery = @"
        SELECT AVG(Voltage * 0.5) AS AvgEnergy, DATENAME(MONTH, MAX(Timestamp)) AS MonthName
        FROM LEDSensorData
        WHERE FORMAT(Timestamp, 'yyyy-MM') = FORMAT(DATEADD(MONTH, -1, GETDATE()), 'yyyy-MM')";

                using (SqlCommand cmd = new SqlCommand(previousMonthQuery, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        previousMonthAvg = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                        previousMonthName = reader.IsDBNull(1) ? "N/A" : reader.GetString(1);
                    }
                }

                // Query for the week with the highest energy spike in the latest month
                string spikeQuery = @"
        SELECT TOP 1 CONCAT('Week ', DATEPART(WEEK, Timestamp)) AS SpikeWeekLabel
        FROM LEDSensorData
        WHERE FORMAT(Timestamp, 'yyyy-MM') = FORMAT(GETDATE(), 'yyyy-MM')
        GROUP BY DATEPART(WEEK, Timestamp)
        ORDER BY SUM(Voltage * 0.5) DESC";

                using (SqlCommand cmd = new SqlCommand(spikeQuery, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        spikeWeekLabel = reader.IsDBNull(0) ? "N/A" : reader.GetString(0);
                    }
                }

                // Calculate percentage change
                double percentageChange = previousMonthAvg != 0
                    ? ((latestMonthAvg - previousMonthAvg) / previousMonthAvg) * 100
                    : 0;

                // Format the output
                string overviewText = $"In {latestMonthName}, energy usage ";
                if (percentageChange > 0)
                {
                    overviewText += $"increased by {Math.Round(percentageChange, 2)}% ";
                }
                else if (percentageChange < 0)
                {
                    overviewText += $"decreased by {Math.Abs(Math.Round(percentageChange, 2))}% ";
                }
                else
                {
                    overviewText += "remained constant ";
                }
                overviewText += $"compared to {previousMonthName}, with the largest spike in {spikeWeekLabel}.";

                lblOverviewText.Text = overviewText;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the monthly insights: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadWeeklyInsights(SqlConnection connection)
        {
            try
            {
                double latestWeekAvg = 0, previousWeeksAvg = 0;
                string latestWeekLabel = "", spikeDate = "", latestWeekMonth = "";

                // Query for the latest week's energy usage
                string latestWeekQuery = @"
        SELECT AVG(Voltage * 0.5) AS AvgEnergy,
               CONCAT('Week ', DATEPART(WEEK, MAX(Timestamp))) AS WeekLabel,
               DATENAME(MONTH, MAX(Timestamp)) AS MonthName
        FROM LEDSensorData
        WHERE DATEPART(WEEK, Timestamp) = (SELECT MAX(DATEPART(WEEK, Timestamp))
                                           FROM LEDSensorData
                                           WHERE FORMAT(Timestamp, 'yyyy-MM') = FORMAT(GETDATE(), 'yyyy-MM'))
          AND FORMAT(Timestamp, 'yyyy-MM') = FORMAT(GETDATE(), 'yyyy-MM')";

                using (SqlCommand cmd = new SqlCommand(latestWeekQuery, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        latestWeekAvg = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                        latestWeekLabel = reader.IsDBNull(1) ? "N/A" : reader.GetString(1);
                        latestWeekMonth = reader.IsDBNull(2) ? "N/A" : reader.GetString(2);
                    }
                }

                // Query for the previous weeks' energy usage
                string previousWeeksQuery = @"
        SELECT AVG(Voltage * 0.5) AS AvgEnergy
        FROM LEDSensorData
        WHERE DATEPART(WEEK, Timestamp) < (SELECT MAX(DATEPART(WEEK, Timestamp))
                                           FROM LEDSensorData
                                           WHERE FORMAT(Timestamp, 'yyyy-MM') = FORMAT(GETDATE(), 'yyyy-MM'))
          AND FORMAT(Timestamp, 'yyyy-MM') = FORMAT(GETDATE(), 'yyyy-MM')";

                using (SqlCommand cmd = new SqlCommand(previousWeeksQuery, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        previousWeeksAvg = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                    }
                }

                // Query for the spike day within the latest week
                string spikeQuery = @"
        SELECT TOP 1 CONVERT(VARCHAR, MAX(Timestamp), 101) AS SpikeDate
        FROM LEDSensorData
        WHERE DATEPART(WEEK, Timestamp) = (SELECT MAX(DATEPART(WEEK, Timestamp))
                                           FROM LEDSensorData
                                           WHERE FORMAT(Timestamp, 'yyyy-MM') = FORMAT(GETDATE(), 'yyyy-MM'))
          AND FORMAT(Timestamp, 'yyyy-MM') = FORMAT(GETDATE(), 'yyyy-MM')
        GROUP BY CONVERT(VARCHAR, Timestamp, 101)
        ORDER BY SUM(Voltage * 0.5) DESC";

                using (SqlCommand cmd = new SqlCommand(spikeQuery, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        spikeDate = reader.IsDBNull(0) ? "N/A" : reader.GetString(0);
                    }
                }

                // Calculate percentage change
                double percentageChange = previousWeeksAvg != 0
                    ? ((latestWeekAvg - previousWeeksAvg) / previousWeeksAvg) * 100
                    : 0;

                // Format the output
                string overviewText = $"In {latestWeekLabel} of {latestWeekMonth}, energy usage ";
                if (percentageChange > 0)
                {
                    overviewText += $"increased by {Math.Round(percentageChange, 2)}% ";
                }
                else if (percentageChange < 0)
                {
                    overviewText += $"decreased by {Math.Abs(Math.Round(percentageChange, 2))}% ";
                }
                else
                {
                    overviewText += "remained constant ";
                }
                overviewText += $"compared to the previous weeks, with the largest spike on {spikeDate}.";

                lblOverviewText.Text = overviewText;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the weekly insights: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void cmbOverviewSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOverviewInsights();
        }

        private void OverviewForm_Load(object sender, EventArgs e)
        {
        }

        private void Overview_Click(object sender, EventArgs e)
        {
        }

        private void ManageRecords_Click(object sender, EventArgs e)
        {
            DataViewJames tableManagement = new DataViewJames();
            tableManagement.Show();
            this.Hide();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Close();
        }

        private void cmbTemperatureFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTemperatureOverview();
        }
    }
}
