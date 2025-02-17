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
using System.Diagnostics;

namespace HomeSphere
{
    public partial class Form1 : Form
    {
        private string strConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Databases\IOTPRJ_Data.mdf;Integrated Security=True;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            LoadTemperatureData();
            LoadUltrasonicData();
            LoadEnergyChart();
            LoadSoundChartForLatestDay();
        }


        private void LoadSoundChartForLatestDay()
        {
            try
            {
                // Use the same connection string as before:
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // 1. Get the latest date in SoundSensorData (ignoring time).
                    string latestDateQuery = @"
                SELECT TOP 1 CONVERT(date, Timestamp) AS LatestDate
                FROM SoundSensorData
                ORDER BY CONVERT(date, Timestamp) DESC";

                    connection.Open();
                    SqlCommand cmdLatestDate = new SqlCommand(latestDateQuery, connection);
                    object latestDateObj = cmdLatestDate.ExecuteScalar();
                    if (latestDateObj == null || latestDateObj == DBNull.Value)
                    {
                        MessageBox.Show("No sound data found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    DateTime latestDate = (DateTime)latestDateObj;

                    // 2. Retrieve all sound readings for that latest date (sorted in ascending time):
                    string query = @"
                SELECT FORMAT(Timestamp, 'HH:mm:ss') AS TimeLabel,
                       SoundLevel
                FROM SoundSensorData
                WHERE CONVERT(date, Timestamp) = @LatestDate
                ORDER BY Timestamp ASC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@LatestDate", latestDate);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No sound data available for the latest date.",
                                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // 3. Plot the results on the 'sound' chart control.
                    sound.Series.Clear();
                    Series series = new Series("Sound Level (Latest Day)")
                    {
                        ChartType = SeriesChartType.Line,  // Shows a line over time
                        XValueType = ChartValueType.String
                    };

                    foreach (DataRow row in dt.Rows)
                    {
                        double level = Convert.ToDouble(row["SoundLevel"]);
                        string timeLabel = row["TimeLabel"].ToString();
                        series.Points.AddXY(timeLabel, level);
                    }

                    sound.Series.Add(series);
                    sound.ChartAreas[0].AxisX.Title = "Time (HH:mm:ss)";
                    sound.ChartAreas[0].AxisY.Title = "Sound Level (units)";  // Change units as needed
                    sound.Titles.Clear();
                    sound.Titles.Add($"Sound Levels for {latestDate:dd MMM yyyy} (Latest)");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the sound chart: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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


        private void LoadEnergyChart()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Identify the latest month and year from LEDSensorData (using Timestamp)
                    string latestMonthQuery = @"
                        SELECT DATEPART(MONTH, MAX(Timestamp)) AS LatestMonth, 
                               DATEPART(YEAR, MAX(Timestamp)) AS LatestYear
                        FROM LEDSensorData";

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
                    // Energy usage is calculated as Voltage * 0.5 (W)
                    string query = @"
                        SELECT CONCAT('Week ', DATEPART(WEEK, Timestamp)) AS WeekLabel, 
                               AVG(Voltage * 0.5) AS AvgEnergyUsage
                        FROM LEDSensorData
                        WHERE DATEPART(MONTH, Timestamp) = @LatestMonth 
                          AND DATEPART(YEAR, Timestamp) = @LatestYear
                        GROUP BY DATEPART(WEEK, Timestamp)
                        ORDER BY DATEPART(WEEK, Timestamp)";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@LatestMonth", latestMonth);
                    adapter.SelectCommand.Parameters.AddWithValue("@LatestYear", latestYear);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No energy data available for the latest month.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show($"An error occurred while loading the energy chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTemperatureData()
        {
            try
            {
                Debug.WriteLine("Attempting to connect to the database...");
                using (SqlConnection connection = new SqlConnection(strConnectionString))
                {
                    string query = "SELECT Timestamp, Temperature FROM TemperatureSensorData ORDER BY Timestamp ASC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable temperatureData = new DataTable();

                    connection.Open(); // Ensure the connection is opened explicitly
                    Debug.WriteLine("Database connection successful.");

                    adapter.Fill(temperatureData);
                    Debug.WriteLine($"Rows returned: {temperatureData.Rows.Count}");

                    foreach (DataRow row in temperatureData.Rows)
                    {
                        Debug.WriteLine($"Timestamp: {row["Timestamp"]}, Temperature: {row["Temperature"]}");
                    }

                    if (temperatureData.Rows.Count > 0)
                    {
                        chartTemperature.Series.Clear();
                        chartTemperature.ChartAreas.Clear();
                        chartTemperature.ChartAreas.Add(new ChartArea("Default"));

                        Series series = new Series("Temperature");
                        series.ChartType = SeriesChartType.Line;
                        series.XValueType = ChartValueType.DateTime;

                        foreach (DataRow row in temperatureData.Rows)
                        {
                            DateTime timestamp = Convert.ToDateTime(row["Timestamp"]);
                            double temperature = Convert.ToDouble(row["Temperature"]);
                            series.Points.AddXY(timestamp, temperature);
                        }

                        chartTemperature.Series.Add(series);

                        chartTemperature.ChartAreas[0].AxisX.Title = "Timestamp";
                        chartTemperature.ChartAreas[0].AxisY.Title = "Temperature (°C)";
                        chartTemperature.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yyyy HH:mm:ss";
                        chartTemperature.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;
                        chartTemperature.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;


                        chartTemperature.Invalidate();
                        Debug.WriteLine("Temperature data plotted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No temperature data found in the database.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading temperature data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }

        private void LoadUltrasonicData()
        {
            try
            {
                Debug.WriteLine("Attempting to connect to the database for ultrasonic data...");
                using (SqlConnection connection = new SqlConnection(strConnectionString))
                {
                    string query = "SELECT Timestamp, Distance FROM UltrasonicSensorData ORDER BY Timestamp ASC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable ultrasonicData = new DataTable();

                    connection.Open(); // Open database connection
                    Debug.WriteLine("Database connection successful for ultrasonic data.");

                    adapter.Fill(ultrasonicData);
                    Debug.WriteLine($"Rows returned for ultrasonic data: {ultrasonicData.Rows.Count}");

                    foreach (DataRow row in ultrasonicData.Rows)
                    {
                        Debug.WriteLine($"Timestamp: {row["Timestamp"]}, Distance: {row["Distance"]}");
                    }

                    if (ultrasonicData.Rows.Count > 0)
                    {
                        chartUltrasonic.Series.Clear();
                        chartUltrasonic.ChartAreas.Clear();
                        chartUltrasonic.ChartAreas.Add(new ChartArea("Default"));

                        Series series = new Series("Ultrasonic Distance");
                        series.ChartType = SeriesChartType.Line;
                        series.XValueType = ChartValueType.DateTime;

                        foreach (DataRow row in ultrasonicData.Rows)
                        {
                            DateTime timestamp = Convert.ToDateTime(row["Timestamp"]);
                            double distance = Convert.ToDouble(row["Distance"]);
                            series.Points.AddXY(timestamp, distance);
                        }

                        chartUltrasonic.Series.Add(series);

                        chartUltrasonic.ChartAreas[0].AxisX.Title = "Timestamp";
                        chartUltrasonic.ChartAreas[0].AxisY.Title = "Distance (cm)";
                        chartUltrasonic.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yyyy HH:mm:ss";
                        chartUltrasonic.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;
                        chartUltrasonic.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;

                        chartUltrasonic.Invalidate();
                        Debug.WriteLine("Ultrasonic sensor data plotted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No ultrasonic sensor data found in the database.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading ultrasonic sensor data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"Error: {ex.Message}");
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
            var result = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                frmAdminLogin adminLoginForm = new frmAdminLogin();
                adminLoginForm.Show();
            }
        }

        private void ManageRecords_Click(object sender, EventArgs e)
        {
            // Open the DataViewJames form instead of TableManagement
            DataViewJames dataView = new DataViewJames();
            dataView.Show();
            this.Hide(); // Optional: Hides the current form
        }


        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void EventManagement_Click(object sender, EventArgs e)
        {
            frmAlertManagement alertManagement = new frmAlertManagement();
            this.Hide();
            alertManagement.Show();
        }

        private void Products_Click(object sender, EventArgs e)
        {
            frmProductPage frmproductpage = new frmProductPage();
            this.Hide();
            frmproductpage.Show();
        }

        private void UserManagement_Click(object sender, EventArgs e)
        {
            frmUserManagement frmusermanagement = new frmUserManagement();
            this.Hide();
            frmusermanagement.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTemperatureData();
            LoadUltrasonicData();
        }

        

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void chartTemperature_Click(object sender, EventArgs e)
        {
            GraphDetailForm tempGraph = new GraphDetailForm("Temperature");
            tempGraph.Show();
        }

        private void chartUltrasonic_Click(object sender, EventArgs e)
        {
            GraphDetailForm ultrasonicGraph = new GraphDetailForm("Ultrasonic");
            ultrasonicGraph.Show();
        }

        

        private void sound_Click_1(object sender, EventArgs e)
        {
            SoundChartForm soundChartForm = new SoundChartForm(sound); // Pass the sound chart
            this.Hide();
            soundChartForm.Show();
        }
    }
}
