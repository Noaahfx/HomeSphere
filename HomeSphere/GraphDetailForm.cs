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
                        query = "SELECT Timestamp, Temperature FROM TemperatureSensorData WHERE Timestamp BETWEEN @start AND @end ORDER BY Timestamp ASC";
                    }
                    else if (sensorType == "Ultrasonic")
                    {
                        query = "SELECT Timestamp, Distance FROM UltrasonicSensorData WHERE Timestamp BETWEEN @start AND @end ORDER BY Timestamp ASC";
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@start", dtpStart.Value);
                    adapter.SelectCommand.Parameters.AddWithValue("@end", dtpEnd.Value);

                    DataTable data = new DataTable();
                    connection.Open();
                    adapter.Fill(data);

                    chartDetail.Series.Clear();
                    chartDetail.ChartAreas.Clear();
                    chartDetail.ChartAreas.Add(new ChartArea("Default"));

                    Series series = new Series(sensorType);
                    series.ChartType = SeriesChartType.Line;
                    series.XValueType = ChartValueType.DateTime;

                    foreach (DataRow row in data.Rows)
                    {
                        DateTime timestamp = Convert.ToDateTime(row["Timestamp"]);
                        double value = Convert.ToDouble(sensorType == "Temperature" ? row["Temperature"] : row["Distance"]);
                        series.Points.AddXY(timestamp, value);
                    }

                    chartDetail.Series.Add(series);

                    chartDetail.ChartAreas[0].AxisX.Title = "Timestamp";
                    chartDetail.ChartAreas[0].AxisY.Title = sensorType == "Temperature" ? "Temperature (°C)" : "Distance (cm)";
                    chartDetail.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yyyy HH:mm:ss";

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
            LoadFilteredData();
        }
    }
}
