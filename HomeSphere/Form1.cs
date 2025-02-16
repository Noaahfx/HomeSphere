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
        }

       

        private void lighting_Click(object sender, EventArgs e)
        {
            string latestDate = GetLatestDate(); // Call a helper function to fetch the latest date
            LightingChartForm lightingChartForm = new LightingChartForm(latestDate);
            lightingChartForm.Show();
            this.Hide();
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
        }
    }
}
