using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HomeSphere
{
    public partial class OverviewForm : Form
    {
        private string strConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Databases\IOTPRJ_Data.mdf;Integrated Security=True;";

        public OverviewForm()
        {
            InitializeComponent();

            // Load the default “Month” overview for LED usage:
            LoadOverviewInsights();

            // Load the default temperature overview (“Overall Trend”):
            LoadTemperatureOverview();
        }

        //-----------------------------------------------------------
        //  1) ENERGY/LED OVERVIEW
        //-----------------------------------------------------------
        private void LoadOverviewInsights()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(strConnectionString))
                {
                    connection.Open();

                    // Determine which time scale the user wants: "Month" or "Week"
                    string selectedSortOption = cmbOverviewSort.SelectedItem?.ToString() ?? "Month";

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
                MessageBox.Show($"Error while loading the LED overview: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// LoadMonthlyInsights: 
        ///  - Find the LATEST row by highest ID in LEDSensorData; extract its month/year.
        ///  - Find the PREVIOUS month (if any).
        ///  - Compare (percentage difference).
        ///  - Also find which week in the latest month had the biggest spike.
        /// </summary>
        private void LoadMonthlyInsights(SqlConnection connection)
        {
            try
            {
                //----------------------------------------------------------------------
                //  A) Find the latest entry (highest ID) in LEDSensorData, 
                //     then extract the Year/Month of that row.
                //----------------------------------------------------------------------
                string latestRowQuery = @"
                    SELECT TOP 1 Timestamp
                    FROM LEDSensorData
                    ORDER BY ID DESC
                ";

                DateTime? latestTimestamp = null;
                using (SqlCommand cmd = new SqlCommand(latestRowQuery, connection))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        latestTimestamp = (DateTime)result;
                    }
                }

                if (!latestTimestamp.HasValue)
                {
                    // No data at all
                    lblOverviewText.Text = "No data in LEDSensorData.";
                    return;
                }

                int latestYear = latestTimestamp.Value.Year;
                int latestMonth = latestTimestamp.Value.Month;

                //----------------------------------------------------------------------
                //  B) Find the "previous" month in LEDSensorData, if any,
                //     i.e. the largest month-year that is strictly less than (latestYear, latestMonth).
                //----------------------------------------------------------------------
                int prevYear = 0, prevMonth = 0;

                string previousMonthQuery = @"
                    SELECT TOP 1 
                           YEAR(Timestamp) AS [Yr], 
                           MONTH(Timestamp) AS [Mo]
                    FROM LEDSensorData
                    WHERE 
                          (YEAR(Timestamp) < @latestYear)
                       OR (YEAR(Timestamp) = @latestYear AND MONTH(Timestamp) < @latestMonth)
                    GROUP BY YEAR(Timestamp), MONTH(Timestamp)
                    ORDER BY YEAR(Timestamp) DESC, MONTH(Timestamp) DESC
                ";

                using (SqlCommand cmd = new SqlCommand(previousMonthQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@latestYear", latestYear);
                    cmd.Parameters.AddWithValue("@latestMonth", latestMonth);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            prevYear = reader.GetInt32(0);
                            prevMonth = reader.GetInt32(1);
                        }
                    }
                }

                bool hasPrevious = (prevYear != 0 && prevMonth != 0);

                //----------------------------------------------------------------------
                //  C) Calculate average usage for LATEST month, 
                //     and also get that month's name (e.g., "January").
                //----------------------------------------------------------------------
                double latestMonthAvg = 0;
                string latestMonthName = "";

                string latestMonthAvgQuery = @"
                    SELECT 
                        AVG(Voltage * 0.5) AS AvgEnergy, 
                        DATENAME(MONTH, MAX(Timestamp)) AS MonthName
                    FROM LEDSensorData
                    WHERE YEAR(Timestamp) = @yr
                      AND MONTH(Timestamp) = @mo
                ";

                using (SqlCommand cmd = new SqlCommand(latestMonthAvgQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@yr", latestYear);
                    cmd.Parameters.AddWithValue("@mo", latestMonth);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            latestMonthAvg = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                            latestMonthName = reader.IsDBNull(1) ? "N/A" : reader.GetString(1);
                        }
                    }
                }

                //----------------------------------------------------------------------
                //  D) Calculate average usage for the PREVIOUS month (if it exists),
                //     and also get that month's name.
                //----------------------------------------------------------------------
                double previousMonthAvg = 0;
                string previousMonthName = "";

                if (hasPrevious)
                {
                    string prevMonthAvgQuery = @"
                        SELECT 
                            AVG(Voltage * 0.5) AS AvgEnergy, 
                            DATENAME(MONTH, MAX(Timestamp)) AS MonthName
                        FROM LEDSensorData
                        WHERE YEAR(Timestamp) = @prevYear
                          AND MONTH(Timestamp) = @prevMonth
                    ";

                    using (SqlCommand cmd = new SqlCommand(prevMonthAvgQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@prevYear", prevYear);
                        cmd.Parameters.AddWithValue("@prevMonth", prevMonth);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                previousMonthAvg = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                                previousMonthName = reader.IsDBNull(1) ? "N/A" : reader.GetString(1);
                            }
                        }
                    }
                }

                //----------------------------------------------------------------------
                //  E) Find which WEEK in the LATEST month had the biggest spike.
                //----------------------------------------------------------------------
                string spikeWeekLabel = "";
                string spikeWeekQuery = @"
                    SELECT TOP 1 
                        CONCAT('Week ', DATEPART(WEEK, Timestamp)) AS SpikeWeekLabel
                    FROM LEDSensorData
                    WHERE YEAR(Timestamp) = @yr
                      AND MONTH(Timestamp) = @mo
                    GROUP BY DATEPART(WEEK, Timestamp)
                    ORDER BY SUM(Voltage * 0.5) DESC
                ";

                using (SqlCommand cmd = new SqlCommand(spikeWeekQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@yr", latestYear);
                    cmd.Parameters.AddWithValue("@mo", latestMonth);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            spikeWeekLabel = reader.IsDBNull(0) ? "N/A" : reader.GetString(0);
                        }
                    }
                }

                //----------------------------------------------------------------------
                //  F) Calculate percentage change if we have a previous month average.
                //----------------------------------------------------------------------
                double percentageChange = 0;
                bool canCompare = (hasPrevious && previousMonthAvg != 0);
                if (canCompare)
                {
                    percentageChange = ((latestMonthAvg - previousMonthAvg) / previousMonthAvg) * 100.0;
                }

                //----------------------------------------------------------------------
                //  G) Build the final text.
                //----------------------------------------------------------------------
                string overviewText = $"In {latestMonthName}, energy usage ";

                if (canCompare)
                {
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
                    overviewText += $"compared to {previousMonthName},";
                }
                else
                {
                    overviewText += "(no previous month data to compare),";
                }

                overviewText += $" with the largest spike in {spikeWeekLabel}.";
                lblOverviewText.Text = overviewText;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading the monthly insights: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// LoadWeeklyInsights:
        ///  - Find the LATEST entry (highest ID) => determine that month.
        ///  - Find the LATEST week number in that month.
        ///  - Compare that week's usage to earlier weeks in the same month.
        /// </summary>
        private void LoadWeeklyInsights(SqlConnection connection)
        {
            try
            {
                //----------------------------------------------------------------------
                //  A) Find the latest row (highest ID) in LEDSensorData => get year/month
                //----------------------------------------------------------------------
                string latestRowQuery = @"
                    SELECT TOP 1 Timestamp
                    FROM LEDSensorData
                    ORDER BY ID DESC
                ";

                DateTime? latestTimestamp = null;
                using (SqlCommand cmd = new SqlCommand(latestRowQuery, connection))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        latestTimestamp = (DateTime)result;
                    }
                }

                if (!latestTimestamp.HasValue)
                {
                    lblOverviewText.Text = "No energy data available.";
                    return;
                }

                int latestYear = latestTimestamp.Value.Year;
                int latestMonth = latestTimestamp.Value.Month;

                //----------------------------------------------------------------------
                //  B) Find the maximum WEEK in that month
                //----------------------------------------------------------------------
                string getMaxWeekQuery = @"
                    SELECT MAX(DATEPART(WEEK, Timestamp))
                    FROM LEDSensorData
                    WHERE YEAR(Timestamp) = @yr
                      AND MONTH(Timestamp) = @mo
                ";

                int latestWeekNumber = 0;
                using (SqlCommand cmd = new SqlCommand(getMaxWeekQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@yr", latestYear);
                    cmd.Parameters.AddWithValue("@mo", latestMonth);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        latestWeekNumber = Convert.ToInt32(result);
                }

                if (latestWeekNumber == 0)
                {
                    lblOverviewText.Text = "No weekly data found for this latest month.";
                    return;
                }

                //----------------------------------------------------------------------
                //  C) Average usage for that latest week
                //----------------------------------------------------------------------
                double latestWeekAvg = 0;
                string latestWeekLabel = "", latestWeekMonth = "";

                string latestWeekQuery = @"
                    SELECT 
                        AVG(Voltage * 0.5) AS AvgEnergy,
                        CONCAT('Week ', DATEPART(WEEK, MAX(Timestamp))) AS WeekLabel,
                        DATENAME(MONTH, MAX(Timestamp)) AS MonthName
                    FROM LEDSensorData
                    WHERE YEAR(Timestamp)       = @yr
                      AND MONTH(Timestamp)      = @mo
                      AND DATEPART(WEEK, Timestamp) = @wk
                ";

                using (SqlCommand cmd = new SqlCommand(latestWeekQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@yr", latestYear);
                    cmd.Parameters.AddWithValue("@mo", latestMonth);
                    cmd.Parameters.AddWithValue("@wk", latestWeekNumber);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            latestWeekAvg = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                            latestWeekLabel = reader.IsDBNull(1) ? "N/A" : reader.GetString(1);
                            latestWeekMonth = reader.IsDBNull(2) ? "N/A" : reader.GetString(2);
                        }
                    }
                }

                //----------------------------------------------------------------------
                //  D) Average usage for all previous weeks in that same month
                //----------------------------------------------------------------------
                double previousWeeksAvg = 0;

                string previousWeeksQuery = @"
                    SELECT AVG(Voltage * 0.5) AS AvgEnergy
                    FROM LEDSensorData
                    WHERE YEAR(Timestamp)       = @yr
                      AND MONTH(Timestamp)      = @mo
                      AND DATEPART(WEEK, Timestamp) < @wk
                ";

                using (SqlCommand cmd = new SqlCommand(previousWeeksQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@yr", latestYear);
                    cmd.Parameters.AddWithValue("@mo", latestMonth);
                    cmd.Parameters.AddWithValue("@wk", latestWeekNumber);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            previousWeeksAvg = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                        }
                    }
                }

                //----------------------------------------------------------------------
                //  E) Find the day with the biggest spike in that latest week
                //----------------------------------------------------------------------
                string spikeDate = "";

                string spikeDayQuery = @"
                    SELECT TOP 1 
                        CONVERT(VARCHAR, MAX(Timestamp), 101) AS SpikeDate
                    FROM LEDSensorData
                    WHERE YEAR(Timestamp)       = @yr
                      AND MONTH(Timestamp)      = @mo
                      AND DATEPART(WEEK, Timestamp) = @wk
                    GROUP BY CONVERT(VARCHAR, Timestamp, 101)
                    ORDER BY SUM(Voltage * 0.5) DESC
                ";

                using (SqlCommand cmd = new SqlCommand(spikeDayQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@yr", latestYear);
                    cmd.Parameters.AddWithValue("@mo", latestMonth);
                    cmd.Parameters.AddWithValue("@wk", latestWeekNumber);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            spikeDate = reader.IsDBNull(0) ? "N/A" : reader.GetString(0);
                        }
                    }
                }

                //----------------------------------------------------------------------
                //  F) Calculate the % change vs previous weeks
                //----------------------------------------------------------------------
                double percentageChange = 0.0;
                if (previousWeeksAvg != 0)
                {
                    percentageChange = ((latestWeekAvg - previousWeeksAvg) / previousWeeksAvg) * 100.0;
                }

                //----------------------------------------------------------------------
                //  G) Build final text
                //----------------------------------------------------------------------
                string overviewText =
                    $"In {latestWeekLabel} of {latestWeekMonth}, energy usage ";

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
                MessageBox.Show($"Error loading the weekly insights: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //-----------------------------------------------------------
        //  2) TEMPERATURE OVERVIEW
        //-----------------------------------------------------------
        //  We similarly use the HIGHEST ID => get that row's Timestamp => that month,
        //  then find the previous month if any, and do the logic for:
        //   - Overall Trend => Compare the 2 months
        //   - Highest Point => From the latest month
        //   - Lowest Point  => From the latest month
        //-----------------------------------------------------------
        private void LoadTemperatureOverview()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(strConnectionString))
                {
                    connection.Open();

                    // Which filter user selected?
                    // (Overall Trend, Highest Point in the Day, Lowest Point in the Day)
                    string selectedOption =
                        cmbTemperatureFilter.SelectedItem?.ToString() ?? "Overall Trend";

                    //-------------------------------------------------------
                    //  A) Find the LATEST row by ID => get that Timestamp => month/year
                    //-------------------------------------------------------
                    string latestTempRowQuery = @"
                        SELECT TOP 1 Timestamp
                        FROM TemperatureSensorData
                        ORDER BY ID DESC
                    ";

                    DateTime? latestTimestamp = null;
                    using (SqlCommand cmd = new SqlCommand(latestTempRowQuery, connection))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            latestTimestamp = (DateTime)result;
                        }
                    }

                    if (!latestTimestamp.HasValue)
                    {
                        lblTemperatureOverviewText.Text = "No Temperature data in the database.";
                        return;
                    }

                    int latestYear = latestTimestamp.Value.Year;
                    int latestMonth = latestTimestamp.Value.Month;

                    //-------------------------------------------------------
                    //  B) Find the PREVIOUS month (if any)
                    //-------------------------------------------------------
                    int prevYear = 0, prevMonth = 0;

                    string previousTempMonthQuery = @"
                        SELECT TOP 1
                               YEAR(Timestamp) AS [Yr],
                               MONTH(Timestamp) AS [Mo]
                        FROM TemperatureSensorData
                        WHERE 
                              (YEAR(Timestamp) < @latestYear)
                           OR (YEAR(Timestamp) = @latestYear AND MONTH(Timestamp) < @latestMonth)
                        GROUP BY YEAR(Timestamp), MONTH(Timestamp)
                        ORDER BY YEAR(Timestamp) DESC, MONTH(Timestamp) DESC
                    ";

                    using (SqlCommand cmd = new SqlCommand(previousTempMonthQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@latestYear", latestYear);
                        cmd.Parameters.AddWithValue("@latestMonth", latestMonth);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                prevYear = reader.GetInt32(0);
                                prevMonth = reader.GetInt32(1);
                            }
                        }
                    }

                    bool hasPrevious = (prevYear != 0 && prevMonth != 0);

                    //-------------------------------------------------------
                    //  C) LATEST month average temperature, month name
                    //-------------------------------------------------------
                    double latestMonthAvg = 0;
                    string latestMonthName = "";

                    string latestTempAvgQuery = @"
                        SELECT 
                            AVG(Temperature) AS AvgTemp,
                            DATENAME(MONTH, MAX(Timestamp)) AS MonthName
                        FROM TemperatureSensorData
                        WHERE YEAR(Timestamp)  = @yr
                          AND MONTH(Timestamp) = @mo
                    ";

                    using (SqlCommand cmd = new SqlCommand(latestTempAvgQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@yr", latestYear);
                        cmd.Parameters.AddWithValue("@mo", latestMonth);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                latestMonthAvg = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                                latestMonthName = reader.IsDBNull(1) ? "N/A" : reader.GetString(1);
                            }
                        }
                    }

                    //-------------------------------------------------------
                    //  D) PREVIOUS month average temperature, if any
                    //-------------------------------------------------------
                    double previousMonthAvg = 0;
                    string previousMonthName = "";

                    if (hasPrevious)
                    {
                        string prevTempAvgQuery = @"
                            SELECT
                                AVG(Temperature) AS AvgTemp,
                                DATENAME(MONTH, MAX(Timestamp)) AS MonthName
                            FROM TemperatureSensorData
                            WHERE YEAR(Timestamp)  = @yr
                              AND MONTH(Timestamp) = @mo
                        ";
                        using (SqlCommand cmd = new SqlCommand(prevTempAvgQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@yr", prevYear);
                            cmd.Parameters.AddWithValue("@mo", prevMonth);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    previousMonthAvg = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                                    previousMonthName = reader.IsDBNull(1) ? "N/A" : reader.GetString(1);
                                }
                            }
                        }
                    }

                    //-------------------------------------------------------
                    //  E) Highest & Lowest from the latest month
                    //-------------------------------------------------------
                    double highestTemp = 0, lowestTemp = 0;
                    string highestTime = "", lowestTime = "";
                    string highestDate = "", lowestDate = "";

                    // Highest
                    {
                        string sql = @"
                            SELECT TOP 1
                                   Temperature,
                                   FORMAT(Timestamp, 'hh:mm tt')  AS TheTime,
                                   FORMAT(Timestamp, 'yyyy-MM-dd') AS TheDate
                            FROM TemperatureSensorData
                            WHERE YEAR(Timestamp)  = @yr
                              AND MONTH(Timestamp) = @mo
                            ORDER BY Temperature DESC
                        ";
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@yr", latestYear);
                            cmd.Parameters.AddWithValue("@mo", latestMonth);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    highestTemp = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                                    highestTime = reader.IsDBNull(1) ? "" : reader.GetString(1);
                                    highestDate = reader.IsDBNull(2) ? "" : reader.GetString(2);
                                }
                            }
                        }
                    }

                    // Lowest
                    {
                        string sql = @"
                            SELECT TOP 1
                                   Temperature,
                                   FORMAT(Timestamp, 'hh:mm tt')  AS TheTime,
                                   FORMAT(Timestamp, 'yyyy-MM-dd') AS TheDate
                            FROM TemperatureSensorData
                            WHERE YEAR(Timestamp)  = @yr
                              AND MONTH(Timestamp) = @mo
                            ORDER BY Temperature ASC
                        ";
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@yr", latestYear);
                            cmd.Parameters.AddWithValue("@mo", latestMonth);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    lowestTemp = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                                    lowestTime = reader.IsDBNull(1) ? "" : reader.GetString(1);
                                    lowestDate = reader.IsDBNull(2) ? "" : reader.GetString(2);
                                }
                            }
                        }
                    }

                    //-------------------------------------------------------
                    //  F) Based on user's selection, build final text
                    //-------------------------------------------------------
                    string overviewText = "";

                    if (selectedOption == "Overall Trend")
                    {
                        // Compare latestMonthAvg to previousMonthAvg
                        bool canCompare = (hasPrevious && previousMonthAvg != 0);
                        if (!canCompare)
                        {
                            overviewText =
                                $"In {latestMonthName}, the average temperature is {latestMonthAvg:F2}°C " +
                                "(no previous month data to compare).";
                        }
                        else
                        {
                            double pctChange =
                                ((latestMonthAvg - previousMonthAvg) / previousMonthAvg) * 100.0;
                            if (pctChange > 0)
                            {
                                overviewText =
                                    $"In {latestMonthName}, the average temperature increased " +
                                    $"by {pctChange:F2}% compared to {previousMonthName}.";
                            }
                            else if (pctChange < 0)
                            {
                                overviewText =
                                    $"In {latestMonthName}, the average temperature decreased " +
                                    $"by {Math.Abs(pctChange):F2}% compared to {previousMonthName}.";
                            }
                            else
                            {
                                overviewText =
                                    $"In {latestMonthName}, the average temperature remained the same " +
                                    $"as {previousMonthName}.";
                            }
                        }
                    }
                    else if (selectedOption == "Highest Point in the Day")
                    {
                        overviewText =
                            $"The highest temperature in {latestMonthName} was {highestTemp}°C " +
                            $"at {highestTime} on {highestDate}.";
                    }
                    else if (selectedOption == "Lowest Point in the Day")
                    {
                        overviewText =
                            $"The lowest temperature in {latestMonthName} was {lowestTemp}°C " +
                            $"at {lowestTime} on {lowestDate}.";
                    }

                    lblTemperatureOverviewText.Text = overviewText;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while loading temperature insights: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //-----------------------------------------------------------
        //  3) EVENT HANDLERS
        //-----------------------------------------------------------
        private void cmbOverviewSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOverviewInsights();
        }

        private void cmbTemperatureFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTemperatureOverview();
        }

        private void OverviewForm_Load(object sender, EventArgs e)
        {
            // (Optional) Could set default selected items in comboboxes here
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
    }
}
