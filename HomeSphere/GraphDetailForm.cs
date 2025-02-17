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

        public GraphDetailForm(string sensorType)
        {
            InitializeComponent();
            this.sensorType = sensorType;
            lblTitle.Text = $"Detailed View - {sensorType} Sensor";

            dtpStart.Value = DateTime.Now.AddDays(-7); // Default: Last 7 days
            dtpEnd.Value = DateTime.Now;

            LoadFilteredData();
        }

        private void LoadFilteredData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(strConnectionString))
                {
                    string query = "";

                    if (sensorType == "Temperature")
                    {
                        query = "SELECT Timestamp, Temperature FROM TemperatureSensorData WHERE Timestamp >= @start AND Timestamp <= @end ORDER BY Timestamp ASC";
                    }
                    else if (sensorType == "Ultrasonic")
                    {
                        query = "SELECT Timestamp, Distance FROM UltrasonicSensorData WHERE Timestamp >= @start AND Timestamp <= @end ORDER BY Timestamp ASC";
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@start", dtpStart.Value);
                    adapter.SelectCommand.Parameters.AddWithValue("@end", dtpEnd.Value);

                    DataTable data = new DataTable();
                    connection.Open();
                    adapter.Fill(data);

                    // Clear old chart data
                    chartDetail.Series.Clear();
                    chartDetail.ChartAreas.Clear();
                    chartDetail.ChartAreas.Add(new ChartArea("Default"));

                    // Check if data exists
                    if (data.Rows.Count == 0)
                    {
                        MessageBox.Show("No data found in the selected range.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

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
                    chartDetail.ChartAreas[0].AxisX.Minimum = minTime.ToOADate();
                    chartDetail.ChartAreas[0].AxisX.Maximum = maxTime.ToOADate();

                    chartDetail.Invalidate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading detailed {sensorType} data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"Filtering Data from {dtpStart.Value} to {dtpEnd.Value}");
            LoadFilteredData();
        }
    }
}
