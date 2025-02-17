using System;
using System.Windows.Forms;

namespace HomeSphere
{
    public partial class MonthEnergyPromptForm : Form
    {
        public string SelectedMonth { get; private set; }
        public string SelectedFilter { get; private set; } // Options: "Whole View", "Highest View", "Lowest View"

        public MonthEnergyPromptForm()
        {
            InitializeComponent();

            // Configure DateTimePicker for month selection: displays "MMMM yyyy"
            dtpMonthSelector.CustomFormat = "MMMM yyyy";
            dtpMonthSelector.Format = DateTimePickerFormat.Custom;
            dtpMonthSelector.ShowUpDown = true;

            // Configure ComboBox with filter options for the month
            cmbMonthEnergyOptions.Items.AddRange(new string[] { "Whole View", "Highest View", "Lowest View" });
            cmbMonthEnergyOptions.SelectedIndex = 0; // Default: Whole View
        }

        private void MonthEnergyPromptForm_Load(object sender, EventArgs e)
        {
            // (Optional initialization)
        }

        private void dtpMonthSelector_ValueChanged(object sender, EventArgs e)
        {
            // (Optional event handling)
        }

        private void cmbMonthEnergyOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            // (Optional event handling)
        }

        private void btnConfirmMonthEnergy_Click(object sender, EventArgs e)
        {
            // For querying, we use "yyyy-MM" format. The picker displays "MMMM yyyy" but we convert here.
            SelectedMonth = dtpMonthSelector.Value.ToString("yyyy-MM");
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
