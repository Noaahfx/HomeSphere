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

        private void LoadMonthlyInsights(SqlConnection connection)
        {
            try
            {
                double latestMonthAvg = 0, previousMonthAvg = 0;
                string latestMonthName = "", previousMonthName = "", spikeWeekLabel = "";

                // Query for latest month
                string latestMonthQuery = @"
            SELECT AVG(EnergyUsage) AS AvgEnergy, DATENAME(MONTH, MAX(Date)) AS MonthName
            FROM [Table]
            WHERE FORMAT(Date, 'yyyy-MM') = FORMAT(GETDATE(), 'yyyy-MM')";
                using (SqlCommand cmd = new SqlCommand(latestMonthQuery, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        latestMonthAvg = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                        latestMonthName = reader.IsDBNull(1) ? "N/A" : reader.GetString(1);
                    }
                }

                // Query for previous month
                string previousMonthQuery = @"
            SELECT AVG(EnergyUsage) AS AvgEnergy, DATENAME(MONTH, MAX(Date)) AS MonthName
            FROM [Table]
            WHERE FORMAT(Date, 'yyyy-MM') = FORMAT(DATEADD(MONTH, -1, GETDATE()), 'yyyy-MM')";
                using (SqlCommand cmd = new SqlCommand(previousMonthQuery, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        previousMonthAvg = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                        previousMonthName = reader.IsDBNull(1) ? "N/A" : reader.GetString(1);
                    }
                }

                // Query for spike week
                string spikeQuery = @"
            SELECT TOP 1 CONCAT('Week ', DATEPART(WEEK, Date)) AS SpikeWeekLabel
            FROM [Table]
            WHERE FORMAT(Date, 'yyyy-MM') = FORMAT(GETDATE(), 'yyyy-MM')
            GROUP BY DATEPART(WEEK, Date)
            ORDER BY SUM(EnergyUsage) DESC";
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

                // Query for the latest week's data
                string latestWeekQuery = @"
            SELECT AVG(EnergyUsage) AS AvgEnergy,
                   CONCAT('Week ', DATEPART(WEEK, MAX(Date))) AS WeekLabel,
                   DATENAME(MONTH, MAX(Date)) AS MonthName
            FROM [Table]
            WHERE DATEPART(WEEK, Date) = (SELECT MAX(DATEPART(WEEK, Date))
                                          FROM [Table]
                                          WHERE FORMAT(Date, 'yyyy-MM') = FORMAT(GETDATE(), 'yyyy-MM'))
              AND FORMAT(Date, 'yyyy-MM') = FORMAT(GETDATE(), 'yyyy-MM')";
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

                // Query for the previous weeks' data
                string previousWeeksQuery = @"
            SELECT AVG(EnergyUsage) AS AvgEnergy
            FROM [Table]
            WHERE DATEPART(WEEK, Date) < (SELECT MAX(DATEPART(WEEK, Date))
                                          FROM [Table]
                                          WHERE FORMAT(Date, 'yyyy-MM') = FORMAT(GETDATE(), 'yyyy-MM'))
              AND FORMAT(Date, 'yyyy-MM') = FORMAT(GETDATE(), 'yyyy-MM')";
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
            SELECT TOP 1 CONVERT(VARCHAR, MAX(Date), 101) AS SpikeDate
            FROM [Table]
            WHERE DATEPART(WEEK, Date) = (SELECT MAX(DATEPART(WEEK, Date))
                                          FROM [Table]
                                          WHERE FORMAT(Date, 'yyyy-MM') = FORMAT(GETDATE(), 'yyyy-MM'))
              AND FORMAT(Date, 'yyyy-MM') = FORMAT(GETDATE(), 'yyyy-MM')
            GROUP BY CONVERT(VARCHAR, Date, 101)
            ORDER BY SUM(EnergyUsage) DESC";
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
            TableManagement tableManagement = new TableManagement();
            tableManagement.Show();
            this.Hide();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Close();
        }
    }
}
