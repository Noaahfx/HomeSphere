using System;
using System.Windows.Forms;

namespace HomeSphere
{
    public partial class UserDashboard : Form
    {
        public UserDashboard()
        {
            InitializeComponent();
            InitializeNavBar();
        }

        private void InitializeNavBar()
        {
            MenuStrip menuStrip = new MenuStrip();

            ToolStripMenuItem temperatureGraphTab = new ToolStripMenuItem("Temperature Graph");
            temperatureGraphTab.Click += TemperatureGraphTab_Click;

            ToolStripMenuItem soundGraphTab = new ToolStripMenuItem("Sound Graph");
            soundGraphTab.Click += SoundGraphTab_Click;

            ToolStripMenuItem energyGraphTab = new ToolStripMenuItem("Energy Graph");
            //energyGraphTab.Click += EnergyGraphTab_Click;

            menuStrip.Items.Add(temperatureGraphTab);
            menuStrip.Items.Add(soundGraphTab);
            menuStrip.Items.Add(energyGraphTab);

            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        private void TemperatureGraphTab_Click(object sender, EventArgs e)
        {
            frmTemperatureGraph tempGraphForm = new frmTemperatureGraph();
            tempGraphForm.Show();
        }

        private void SoundGraphTab_Click(object sender, EventArgs e)
        {
            frmSoundGraph soundGraphForm = new frmSoundGraph();
            soundGraphForm.Show();
        }

        //private void EnergyGraphTab_Click(object sender, EventArgs e)
        //{
        //    frmEnergyGraph energyGraphForm = new frmEnergyGraph();
         //   energyGraphForm.Show();
        //}
    }
}
