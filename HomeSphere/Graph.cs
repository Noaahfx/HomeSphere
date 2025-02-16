using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace HomeSphere
{
    public partial class Graph : Form

    {
        private string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private int _uniqueRFID;
        public Graph(int uniqueRFID)
        {
            _uniqueRFID = uniqueRFID;
            InitializeComponent();
        }

        private void chart4_Click(object sender, EventArgs e)
        {

        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadTemperatureChart();
            LoadEnergyChart();
            LoadNoiseChart();
            LoadAggregateChart();
        }

        private void chartTemperature_Click(object sender, EventArgs e)
        {

        }
       

            // If you want a stacked column chart instead, change:
            // sAggregate.ChartType = SeriesChartType.StackedColumn;
            // Then set XValue = RoomName, YValue = sum(EnergyUsage).
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void Graph_Load(object sender, EventArgs e)
        {
            LoadRooms();
            // Set default date range, e.g. last 7 days
          
            dtpStart.Value = new DateTime(2025, 1, 1);
            dtpEnd.Value = new DateTime(2025, 1, 30);
        }

        private void LoadRooms()
        {
            cmbRoom.Items.Clear();  // Clear existing
            string sql = "SELECT DISTINCT RoomName FROM SensorData ORDER BY RoomName";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cmbRoom.Items.Add(dr["RoomName"].ToString());
                        }
                    }
                }
            }
            // Optionally select the first item
            if (cmbRoom.Items.Count > 0)
                cmbRoom.SelectedIndex = 0;
        }

        // The main button to load data for ALL charts
       

        #region Chart 1: Temperature Over Time (Line Chart)
        private void LoadTemperatureChart()
        {
            // 1) Clear existing series or re-create them
            chartTemperature.Series.Clear();

            // 2) Create a new line series
            Series sTemp = new Series("TemperatureSeries")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                YValueType = ChartValueType.Double,
                Color = Color.Red // Set line color
            };
            chartTemperature.Series.Add(sTemp);

            // 3) Pull data from DB
            //   Filter by room, start date, end date
            string selectedRoom = (cmbRoom.SelectedItem != null) ? cmbRoom.SelectedItem.ToString() : "";
            DateTime start = dtpStart.Value;
            DateTime end = dtpEnd.Value;

            string sql = @"
                SELECT Timestamp, Temperature
                FROM SensorData
                WHERE (@room = '' OR RoomName = @room)
                  AND Timestamp BETWEEN @start AND @end
                ORDER BY Timestamp ASC;
            ";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@room", selectedRoom);
                    cmd.Parameters.AddWithValue("@start", dtpStart.Value);
                    cmd.Parameters.AddWithValue("@end", dtpEnd.Value.Date.AddDays(1).AddSeconds(-1)); // Include full day


                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            DateTime xVal = (DateTime)dr["Timestamp"];
                            double yVal = Convert.ToDouble(dr["Temperature"]);

                            sTemp.Points.AddXY(xVal, yVal);
                        }
                    }
                }
            }

            // 4) Optional: Axis formatting
            ChartArea ca = chartTemperature.ChartAreas[0];
            ca.AxisX.LabelStyle.Format = "dd-MMM"; // or "MM-dd HH:mm"
            ca.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            ca.AxisY.Title = "Temperature (°C)";
            ca.AxisX.Title = "Timestamp";
        }
        #endregion

        #region Chart 2: Energy Usage Over Time (Line or Area)
        private void LoadEnergyChart()
        {

            chartEnergy.Series.Clear();

            // Choose either .Line or .Area
            Series sEnergy = new Series("EnergySeries");
            sEnergy.ChartType = SeriesChartType.Area;
            sEnergy.XValueType = ChartValueType.DateTime;
            sEnergy.YValueType = ChartValueType.Double;
            chartEnergy.Series.Add(sEnergy);

            string selectedRoom = (cmbRoom.SelectedItem != null) ? cmbRoom.SelectedItem.ToString() : "";
            DateTime start = dtpStart.Value;
            DateTime end = dtpEnd.Value;

            string sql = @"
                SELECT Timestamp, EnergyUsage
                FROM SensorData
                WHERE (@room = '' OR RoomName = @room)
                  AND Timestamp BETWEEN @start AND @end
                ORDER BY Timestamp ASC;
            ";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@room", selectedRoom);
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@end", end);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            DateTime xVal = (DateTime)dr["Timestamp"];
                            double yVal = Convert.ToDouble(dr["EnergyUsage"]);
                            sEnergy.Points.AddXY(xVal, yVal);
                        }
                    }
                }
            }

            // Axis formatting
            ChartArea ca = chartEnergy.ChartAreas[0];
            ca.AxisX.LabelStyle.Format = "dd-MMM";
            ca.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            ca.AxisY.Title = "Energy (kWh)";
            ca.AxisX.Title = "Timestamp";
        }
            #endregion

            #region Chart 3: Noise Levels Over Time (Line or Bar)
        private void LoadNoiseChart()
        {
            chartNoise.Series.Clear();

            // Choose .Line or .Column (bar-like)
            Series sNoise = new Series("NoiseSeries")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                YValueType = ChartValueType.Double,
                Color = Color.Green // Set line color
            };
            chartNoise.Series.Add(sNoise);

            string selectedRoom = (cmbRoom.SelectedItem != null) ? cmbRoom.SelectedItem.ToString() : "";
            DateTime start = dtpStart.Value;
            DateTime end = dtpEnd.Value;

            string sql = @"
                SELECT Timestamp, NoiseLevel
                FROM SensorData
                WHERE (@room = '' OR RoomName = @room)
                  AND Timestamp BETWEEN @start AND @end
                ORDER BY Timestamp ASC;
            ";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@room", selectedRoom);
                    cmd.Parameters.AddWithValue("@start", dtpStart.Value);
                    cmd.Parameters.AddWithValue("@end", dtpEnd.Value.Date.AddDays(1).AddSeconds(-1)); // Include full day

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            DateTime xVal = (DateTime)dr["Timestamp"];
                            double yVal = Convert.ToDouble(dr["NoiseLevel"]);
                            sNoise.Points.AddXY(xVal, yVal);
                        }
                    }
                }
            }

            // Axis formatting
            ChartArea ca = chartNoise.ChartAreas[0];
            ca.AxisX.LabelStyle.Format = "dd-MMM";
            ca.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            ca.AxisY.Title = "Noise (dB)";
            ca.AxisX.Title = "Timestamp";
        }
        #endregion

        #region Chart 4: Aggregate Energy Usage (Pie or Stacked Column)
        private void LoadAggregateChart()
        {
            chartAggregate.Series.Clear();

            // Example: Pie chart of total energy usage per room over time
            Series sAggregate = new Series("AggregateSeries");
            sAggregate.ChartType = SeriesChartType.Pie;
            sAggregate.XValueType = ChartValueType.String;   // RoomName
            sAggregate.YValueType = ChartValueType.Double;   // Summed usage
            chartAggregate.Series.Add(sAggregate);

            // We gather sum of EnergyUsage per room
            DateTime start = dtpStart.Value;
            DateTime end = dtpEnd.Value;

            string sql = @"
                SELECT RoomName, SUM(EnergyUsage) as TotalEnergy
                FROM SensorData
                WHERE Timestamp BETWEEN @start AND @end
                GROUP BY RoomName
                ORDER BY RoomName;
            ";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@end", end);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string room = dr["RoomName"].ToString();
                            double total = Convert.ToDouble(dr["TotalEnergy"]);
                            sAggregate.Points.AddXY(room, total);
                        }
                    }
                }
            }

            // If you want a stacked column chart instead, change:
            // sAggregate.ChartType = SeriesChartType.StackedColumn;
            // Then set XValue = RoomName, YValue = sum(EnergyUsage).
        }

        #endregion

        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //frmSensorSettings sensorSettingsForm = new frmSensorSettings(_uniqueRFID);
            //sensorSettingsForm.ShowDialog();
        }
    }
}
