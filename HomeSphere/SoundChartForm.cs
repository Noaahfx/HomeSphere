using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HomeSphere
{
    public partial class SoundChartForm : Form
    {
        private Chart originalChart; // Stores the original chart data

        public SoundChartForm(Chart sourceChart)
        {
            InitializeComponent();
            this.originalChart = sourceChart; // Store the original chart
            InitializeFilterDropdown();
            LoadEnlargedChart(sourceChart, "All Data"); // Default to "All Data"
        }

        private void InitializeFilterDropdown()
        {
            // Add filter options to ComboBox
            comboFilter.Items.Add("All Data");
            comboFilter.Items.Add("Highest Value");
            comboFilter.Items.Add("Lowest Value");
            comboFilter.SelectedIndex = 0; // Default to "All Data"
            comboFilter.SelectedIndexChanged += comboFilter_SelectedIndexChanged;
        }

        private void LoadEnlargedChart(Chart sourceChart, string filterOption)
        {
            // Ensure the form clears previous charts
            this.Controls.RemoveByKey("soundChart");

            // Create a new Chart control
            Chart enlargedChart = new Chart
            {
                Name = "soundChart",
                Dock = DockStyle.Left, // Dock to the left
                Width = this.Width - 250, // Leave space for filters
                BorderlineColor = System.Drawing.Color.Black,
                BorderlineDashStyle = ChartDashStyle.Solid
            };

            enlargedChart.ChartAreas.Add(new ChartArea("ChartArea1"));

            // Copy series from the original chart
            if (sourceChart.Series.Count > 0)
            {
                Series sourceSeries = sourceChart.Series[0]; // Assuming one series

                // **Determine Chart Type**
                SeriesChartType chartType = (filterOption == "Highest Value" || filterOption == "Lowest Value")
                    ? SeriesChartType.Column // Use Bar Chart for filtering
                    : SeriesChartType.Line; // Default view uses Line Chart

                Series newSeries = new Series(sourceSeries.Name)
                {
                    ChartType = chartType,
                    XValueType = sourceSeries.XValueType,
                    IsValueShownAsLabel = true
                };

                // **Filtering Logic**
                var points = sourceSeries.Points.ToList();
                if (filterOption == "Highest Value")
                {
                    double maxVal = points.Max(p => p.YValues[0]);
                    points = points.Where(p => p.YValues[0] == maxVal).ToList();
                }
                else if (filterOption == "Lowest Value")
                {
                    double minVal = points.Min(p => p.YValues[0]);
                    points = points.Where(p => p.YValues[0] == minVal).ToList();
                }

                // **Ensure Duplicate Values are Displayed**
                foreach (var point in points)
                {
                    newSeries.Points.AddXY(point.AxisLabel, point.YValues[0]);
                }

                enlargedChart.Series.Add(newSeries);
            }

            // Copy titles
            foreach (Title title in sourceChart.Titles)
            {
                enlargedChart.Titles.Add(new Title(title.Text, Docking.Top, title.Font, title.ForeColor));
            }

            // Copy axis titles
            enlargedChart.ChartAreas[0].AxisX.Title = sourceChart.ChartAreas[0].AxisX.Title;
            enlargedChart.ChartAreas[0].AxisY.Title = sourceChart.ChartAreas[0].AxisY.Title;

            // Ensure labels are visible and properly spaced
            enlargedChart.ChartAreas[0].AxisX.Interval = 1;
            enlargedChart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            enlargedChart.ChartAreas[0].AxisX.IsMarginVisible = true;

            // Add chart to the form
            this.Controls.Add(enlargedChart);
        }

        // Event handler for dropdown selection change
        private void comboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = comboFilter.SelectedItem.ToString();
            LoadEnlargedChart(originalChart, selectedFilter);
        }

        private void btnBackToHome2_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Close();
        }
    }
}
