using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HomeSphere
{
    public partial class frmTemperatureGraph : Form
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public frmTemperatureGraph()
        {
            InitializeComponent();
            LoadTemperatureData();
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

                    connection.Open();
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
                        ChartArea chartArea = new ChartArea("Default");

                        chartArea.AxisX.Title = "Timestamp";
                        chartArea.AxisX.TitleFont = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
                        chartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
                        chartArea.AxisX.LabelStyle.Format = "dd/MM"; // ✅ Simplify timestamp format
                        chartArea.AxisX.IntervalType = DateTimeIntervalType.Days; // Use daily intervals for clarity
                        chartArea.AxisX.Interval = 5; // Set interval to 1 day for better spacing
                        chartArea.AxisX.LabelStyle.Angle = -60; // Maintain angle for readability
                        chartArea.AxisX.LabelStyle.IsStaggered = true; // Stagger labels to prevent overlap
                        chartArea.AxisX.IsLabelAutoFit = false; // Disable auto-fit for manual spacing control
                        chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;

                        chartArea.AxisY.Title = "Temperature (°C)";
                        chartArea.AxisY.TitleFont = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
                        chartArea.AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
                        chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;

                        chartTemperature.ChartAreas.Add(chartArea);

                        Series series = new Series("Temperature")
                        {
                            ChartType = SeriesChartType.Column,
                            XValueType = ChartValueType.DateTime,
                            BorderWidth = 3,
                            Color = System.Drawing.Color.OrangeRed
                        };
                        series["PixelPointWidth"] = "50";
                        foreach (DataRow row in temperatureData.Rows)
                        {
                            DateTime timestamp;
                            if (DateTime.TryParse(Convert.ToString(row["Timestamp"]), out timestamp))
                            {
                                double temperature = Convert.ToDouble(row["Temperature"]);
                                series.Points.AddXY(timestamp, temperature);
                            }
                            else
                            {
                                Debug.WriteLine($"Invalid Timestamp: {row["Timestamp"]}");
                            }
                        }

                        chartTemperature.Series.Add(series);
                        chartTemperature.ChartAreas[0].RecalculateAxesScale();

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
    }
}
