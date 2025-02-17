using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HomeSphere
{
    public partial class frmSoundGraph : Form
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public frmSoundGraph()
        {
            InitializeComponent();
            LoadSoundData();
        }

        private void LoadSoundData()
        {
            try
            {
                Debug.WriteLine("Attempting to connect to the database...");
                using (SqlConnection connection = new SqlConnection(strConnectionString))
                {
                    string query = "SELECT Timestamp, SoundLevel FROM SoundSensorData ORDER BY Timestamp ASC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable soundData = new DataTable();

                    connection.Open();
                    Debug.WriteLine("Database connection successful.");

                    adapter.Fill(soundData);
                    Debug.WriteLine($"Rows returned: {soundData.Rows.Count}");

                    if (soundData.Rows.Count > 0)
                    {
                        chartSound.Series.Clear();
                        chartSound.ChartAreas.Clear();
                        ChartArea chartArea = new ChartArea("Default");

                        // ✅ Improved X-Axis Labeling
                        chartArea.AxisX.Title = "Timestamp";
                        chartArea.AxisX.TitleFont = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
                        chartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
                        chartArea.AxisX.LabelStyle.Format = "dd/MM/yyyy HH:mm"; // ✅ Full Date & Time Format
                        chartArea.AxisX.IntervalType = DateTimeIntervalType.Hours; // ✅ Use Hour Intervals
                        chartArea.AxisX.Interval = soundData.Rows.Count / 10; // ✅ Adjust interval dynamically
                        chartArea.AxisX.LabelStyle.Angle = -60; // ✅ Slanted labels for readability
                        chartArea.AxisX.LabelStyle.IsStaggered = false; // ✅ Prevent overlap
                        chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
                        chartArea.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont | LabelAutoFitStyles.WordWrap;

                        chartArea.AxisY.Title = "Sound Level (dB)";
                        chartArea.AxisY.TitleFont = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
                        chartArea.AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
                        chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;

                        chartSound.ChartAreas.Add(chartArea);

                        Series series = new Series("Sound Level")
                        {
                            ChartType = SeriesChartType.Spline,
                            XValueType = ChartValueType.DateTime,
                            BorderWidth = 3,
                            Color = System.Drawing.Color.Blue
                        };

                        foreach (DataRow row in soundData.Rows)
                        {
                            DateTime timestamp;
                            if (DateTime.TryParse(Convert.ToString(row["Timestamp"]), out timestamp))
                            {
                                double soundLevel = Convert.ToDouble(row["SoundLevel"]);
                                series.Points.AddXY(timestamp.ToOADate(), soundLevel);
                            }
                            else
                            {
                                Debug.WriteLine($"Invalid Timestamp: {row["Timestamp"]}");
                            }
                        }

                        chartSound.Series.Add(series);
                        chartSound.ChartAreas[0].RecalculateAxesScale(); // ✅ Ensure the X-Axis adjusts correctly

                        Debug.WriteLine("Sound data plotted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No sound data found in the database.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sound data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
