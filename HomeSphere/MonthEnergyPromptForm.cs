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
    public partial class MonthEnergyPromptForm : Form
    {
        public string SelectedMonth { get; private set; }
        public string SelectedFilter { get; private set; }

        public MonthEnergyPromptForm()
        {
            InitializeComponent();

            // Configure DateTimePicker for month selection
            dtpMonthSelector.CustomFormat = "MMMM yyyy";
            dtpMonthSelector.Format = DateTimePickerFormat.Custom;
            dtpMonthSelector.ShowUpDown = true;

            // Configure ComboBox
            cmbMonthEnergyOptions.Items.AddRange(new string[] { "Whole View", "Highest Week", "Lowest Week" });
            cmbMonthEnergyOptions.SelectedIndex = 0; // Default: Whole View
        }

        private void MonthEnergyPromptForm_Load(object sender, EventArgs e)
        {

        }

        private void dtpMonthSelector_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbMonthEnergyOptions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirmMonthEnergy_Click(object sender, EventArgs e)
        {
            // Set properties
            SelectedMonth = dtpMonthSelector.Value.ToString("yyyy-MM"); // Format: YYYY-MM
            SelectedFilter = cmbMonthEnergyOptions.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelMonthEnergy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
