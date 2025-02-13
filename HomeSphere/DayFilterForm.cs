using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keith_admindashboard
{
    public partial class DayFilterForm : Form
    {
        public DateTime SelectedDate { get; private set; }
        public string SelectedFilter { get; private set; }

        public DayFilterForm()
        {
            InitializeComponent();

            // Set default filter options
            cmbFilters.Items.AddRange(new string[] { "Whole View", "Highest Percentage", "Lowest Percentage" });
            cmbFilters.SelectedIndex = 0; // Default to "Whole View"
        }
        private void DayFilterForm_Load(object sender, EventArgs e)
        {

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            SelectedDate = dtpDate.Value.Date;
            SelectedFilter = cmbFilters.SelectedItem.ToString();

            this.DialogResult = DialogResult.OK; // Confirm selection
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Cancel selection
            this.Close();
        }
    }
}
