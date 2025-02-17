using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace HomeSphere
{
    public partial class frmManageDevices : Form
    {
        private int userId;
        private string strConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public frmManageDevices(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadUserDevices();
        }

        private void LoadUserDevices()
        {
            using (SqlConnection conn = new SqlConnection(strConnectionString))
            {
                conn.Open();
                string query = "SELECT DeviceID, DeviceIdentifier, DeviceName FROM Devices WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvDevices.DataSource = dt;

                    // ✅ Hide the DeviceID column
                    dgvDevices.Columns["DeviceID"].Visible = false;
                }
            }
        }

        private void btnRenameDevice_Click(object sender, EventArgs e)
        {
            if (dgvDevices.SelectedRows.Count > 0)
            {
                int deviceId = Convert.ToInt32(dgvDevices.SelectedRows[0].Cells["DeviceID"].Value);
                string newDeviceName = txtDeviceName.Text.Trim();

                if (string.IsNullOrWhiteSpace(newDeviceName))
                {
                    MessageBox.Show("Device name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(strConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE Devices SET DeviceName = @DeviceName WHERE DeviceID = @DeviceID AND UserID = @UserID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DeviceName", newDeviceName);
                        cmd.Parameters.AddWithValue("@DeviceID", deviceId);
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Device renamed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUserDevices(); // Refresh the list
            }
            else
            {
                MessageBox.Show("Please select a device to rename.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide the current form

            // Check if frmUserHomePage is already open
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmUserHomePage)
                {
                    form.Show(); // Show existing home page
                    return; // Exit to prevent duplicates
                }
            }

            // If no existing frmUserHomePage, create a new one
            frmUserHomePage homePage = new frmUserHomePage(userId);
            homePage.Show();
        }


        private void txtDeviceName_GotFocus(object sender, EventArgs e)
        {
            if (txtDeviceName.Text == "Enter new device name...")
            {
                txtDeviceName.Text = "";
                txtDeviceName.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtDeviceName_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDeviceName.Text))
            {
                txtDeviceName.Text = "Enter new device name...";
                txtDeviceName.ForeColor = System.Drawing.Color.Gray;
            }
        }



        private void btnDeleteDevice_Click(object sender, EventArgs e)
        {
            if (dgvDevices.SelectedRows.Count > 0)
            {
                int deviceId = Convert.ToInt32(dgvDevices.SelectedRows[0].Cells["DeviceID"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this device?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(strConnectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Devices WHERE DeviceID = @DeviceID AND UserID = @UserID";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@DeviceID", deviceId);
                            cmd.Parameters.AddWithValue("@UserID", userId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Device deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUserDevices(); // Refresh the list
                }
            }
            else
            {
                MessageBox.Show("Please select a device to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
