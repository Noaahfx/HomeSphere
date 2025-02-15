using System;
using System.Windows.Forms;

namespace HomeSphere
{
    public partial class frmAdminHomePage : Form
    {
        public frmAdminHomePage()
        {
            InitializeComponent();
        }

        private void lnkAlertManagement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAlertManagement adminDashboard = new frmAlertManagement();
            this.Hide();
            adminDashboard.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                frmAdminLogin adminLoginForm = new frmAdminLogin();
                adminLoginForm.Show();
            }
        }
    }
}
