using System;
using System.Windows.Forms;

namespace HomeSphere
{
    public partial class UserDashboard : Form
    {
        private int userId;

        // Modified constructor to accept a userId
        public UserDashboard(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            InitializeNavBar();
        }

        // Optional: Retain a parameterless constructor for designer support,
        // but it can call the parameterized one with a default or invalid userId.
        public UserDashboard() : this(-1)
        {
        }

        private void InitializeNavBar()
        {
            MenuStrip menuStrip = new MenuStrip();

            ToolStripMenuItem temperatureGraphTab = new ToolStripMenuItem("Temperature Graph");
            temperatureGraphTab.Click += TemperatureGraphTab_Click;

            ToolStripMenuItem soundGraphTab = new ToolStripMenuItem("Sound Graph");
            soundGraphTab.Click += SoundGraphTab_Click;

            ToolStripMenuItem energyGraphTab = new ToolStripMenuItem("Energy Graph");
            energyGraphTab.Click += EnergyGraphTab_Click;

            menuStrip.Items.Add(temperatureGraphTab);
            menuStrip.Items.Add(soundGraphTab);
            menuStrip.Items.Add(energyGraphTab);

            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        private void TemperatureGraphTab_Click(object sender, EventArgs e)
        {
            // If your graph form now accepts a userId, pass it along
            frmTemperatureGraph tempGraphForm = new frmTemperatureGraph();
            tempGraphForm.Show();
        }

        private void SoundGraphTab_Click(object sender, EventArgs e)
        {
            // If your graph form now accepts a userId, pass it along
            frmSoundGraph soundGraphForm = new frmSoundGraph();
            soundGraphForm.Show();
        }

        private void EnergyGraphTab_Click(object sender, EventArgs e)
        {
            // If your graph form now accepts a userId, pass it along
            UserEnergyGraph energyGraphForm = new UserEnergyGraph();
            energyGraphForm.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmUserHomePage homePage = new frmUserHomePage(userId);
            this.Hide();
            homePage.Show();
        }
    }
}
