using System;
using System.Windows.Forms;

namespace HomeSphere
{
    public partial class DayEnergyPromptForm : Form
    {
        public string SelectedDate { get; private set; }
        public string SelectedFilter { get; private set; } // Options: "Whole View", "Highest View", "Lowest View"

        public DayEnergyPromptForm()
        {
            InitializeComponent();

            // Configure DateTimePicker for day selection with a custom format "dd MM yyyy"
            dtpDaySelector.Format = DateTimePickerFormat.Custom;
            dtpDaySelector.CustomFormat = "dd MM yyyy";

            // Configure ComboBox with filter options for the day
            cmbDayEnergyOptions.Items.AddRange(new string[] { "Whole View", "Highest View", "Lowest View" });
            cmbDayEnergyOptions.SelectedIndex = 0; // Default: Whole View
        }

        private void DayEnergyPromptForm_Load(object sender, EventArgs e)
        {
            // (Optional initialization)
        }

        private void btnConfirmDayEnergy_Click(object sender, EventArgs e)
        {
            // Set properties: Day in "dd MM yyyy" format and the selected filter
            SelectedDate = dtpDaySelector.Value.ToString("dd MM yyyy");
            SelectedFilter = cmbDayEnergyOptions.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelDayEnergy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
