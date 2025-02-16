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
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace HomeSphere
{
    public partial class GraphJames : Form
    {
        private string strConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Databases\IOTPRJ_Data.mdf;Integrated Security=True;";
        public GraphJames()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("Form2 loaded.");
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

        private void chartTemperature_Click(object sender, EventArgs e)
        {

        }

        private void btnRefreshGraph_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Refresh button clicked. Reloading temperature data...");
            LoadTemperatureData();

        }

        private void temptab_Click(object sender, EventArgs e)
        {

        }
    }
}
