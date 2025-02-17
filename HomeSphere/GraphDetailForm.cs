using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HomeSphere
{
    public partial class GraphDetailForm : Form
    {
        private string strConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Databases\IOTPRJ_Data.mdf;Integrated Security=True;";
        private string sensorType; // "Temperature" or "Ultrasonic"
        private bool isFilterApplied = false; // Track if user applied filters

        public GraphDetailForm(string sensorType)
        {
            InitializeComponent();
            this.sensorType = sensorType;
            lblTitle.Text = $"Detailed View - {sensorType} Sensor";

            // Set default values (Last 7 days)
            dtpStart.Value = DateTime.Now.AddDays(-7);
            dtpEnd.Value = DateTime.Now;

            // Set default min/max values
            if (sensorType == "Temperature")
            {
                numMinValue.Minimum = -50; // Min possible temperature
                numMinValue.Maximum = 100;
                numMinValue.Value = -50; // Default min
                numMaxValue.Minimum = -50;
                numMaxValue.Maximum = 100;
                numMaxValue.Value = 100; // Default max
            }
            else if (sensorType == "Ultrasonic")
            {
                numMinValue.Minimum = 0;
                numMinValue.Maximum = 500; // Max distance
                numMinValue.Value = 0;
                numMaxValue.Minimum = 0;
                numMaxValue.Maximum = 500;
                numMaxValue.Value = 500;
            }

            // Load Default Data (No Filtering Initially)
            LoadDefaultData();
        }

        /// <summary>
        /// Loads the default graph data (No filtering applied)
        /// </summary>
        private void LoadDefaultData()
        {
            isFilterApplied = false; // Ensure filters are not applied initially
            try
            {
                using (SqlConnection connection = new SqlConnection(strConnectionString))
                {
                    string query = "";

                    if (sensorType == "Temperature")
                    {
                        query = "SELECT TOP 100 Timestamp, Temperature FROM TemperatureSensorData ORDER BY Timestamp ASC";
                    }
                    else if (sensorType == "Ultrasonic")
                    {
                        query = "SELECT TOP 100 Timestamp, Distance FROM UltrasonicSensorData ORDER BY Timestamp ASC";
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable data = new DataTable();
                    connection.Open();
                    adapter.Fill(data);

                    PlotGraph(data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading default {sensorType} data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads data based on user-selected filters
        /// </summary>
        private void LoadFilteredData()
        {
            isFilterApplied = true; // Mark that filtering is applied
            try
            {
                using (SqlConnection connection = new SqlConnection(strConnectionString))
                {
                    string query = "";

                    if (sensorType == "Temperature")
                    {
                        query = "SELECT Timestamp, Temperature FROM TemperatureSensorData " +
                                "WHERE Timestamp BETWEEN @start AND @end " +
                                "AND Temperature BETWEEN @minValue AND @maxValue " +
                                "ORDER BY Timestamp ASC";
                    }
                    else if (sensorType == "Ultrasonic")
                    {
                        query = "SELECT Timestamp, Distance FROM UltrasonicSensorData " +
                                "WHERE Timestamp BETWEEN @start AND @end " +
                                "AND Distance BETWEEN @minValue AND @maxValue " +
                                "ORDER BY Timestamp ASC";
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@start", dtpStart.Value);
                    adapter.SelectCommand.Parameters.AddWithValue("@end", dtpEnd.Value);
                    adapter.SelectCommand.Parameters.AddWithValue("@minValue", numMinValue.Value);
                    adapter.SelectCommand.Parameters.AddWithValue("@maxValue", numMaxValue.Value);

                    DataTable data = new DataTable();
                    connection.Open();
                    adapter.Fill(data);

                    if (data.Rows.Count == 0)
                    {
                        MessageBox.Show("No data found in the selected range.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    PlotGraph(data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading filtered {sensorType} data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Plots the graph based on provided DataTable
        /// </summary>
        private void PlotGraph(DataTable data)
        {
            // Clear old data
            chartDetail.Series.Clear();
            chartDetail.ChartAreas.Clear();
            chartDetail.ChartAreas.Add(new ChartArea("Default"));

            Series series = new Series(sensorType);
            series.ChartType = SeriesChartType.Line;
            series.XValueType = ChartValueType.DateTime;

            DateTime minTime = DateTime.MaxValue;
            DateTime maxTime = DateTime.MinValue;

            foreach (DataRow row in data.Rows)
            {
                DateTime timestamp = Convert.ToDateTime(row["Timestamp"]);
                double value = Convert.ToDouble(sensorType == "Temperature" ? row["Temperature"] : row["Distance"]);
                series.Points.AddXY(timestamp, value);

                if (timestamp < minTime) minTime = timestamp;
                if (timestamp > maxTime) maxTime = timestamp;
            }

            chartDetail.Series.Add(series);

            // Set axis titles
            chartDetail.ChartAreas[0].AxisX.Title = "Timestamp";
            chartDetail.ChartAreas[0].AxisY.Title = sensorType == "Temperature" ? "Temperature (°C)" : "Distance (cm)";

            // Fix time display issue
            chartDetail.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yyyy HH:mm";
            chartDetail.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Hours;
            chartDetail.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;

            // Only set min/max if data exists
            if (minTime != DateTime.MaxValue && maxTime != DateTime.MinValue)
            {
                chartDetail.ChartAreas[0].AxisX.Minimum = minTime.ToOADate();
                chartDetail.ChartAreas[0].AxisX.Maximum = maxTime.ToOADate();
            }

            chartDetail.Invalidate();
        }

        /// <summary>
        /// Handles Apply Filter button click
        /// </summary>
        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"Filtering {sensorType} Data from {dtpStart.Value} to {dtpEnd.Value} " +
                            $"with values between {numMinValue.Value} and {numMaxValue.Value}");

            if (dtpStart.Value > dtpEnd.Value)
            {
                MessageBox.Show("Start date cannot be after the End date!", "Invalid Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numMinValue.Value > numMaxValue.Value)
            {
                MessageBox.Show("Min value cannot be greater than Max value!", "Invalid Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadFilteredData();
        }
    }
}
