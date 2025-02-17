using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace HomeSphere
{
    public partial class frmMFASettings : Form
    {
        private int userId;

        public frmMFASettings(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadMFASetting();
        }

        // Ensure this method exists to fix the error
        private void frmMFASettings_Load(object sender, EventArgs e)
        {
            LoadMFASetting(); // Ensure settings are loaded when the form opens
        }

        private void LoadMFASetting()
        {
            try
            {
                cmbMFAType.Items.Clear(); // Ensure dropdown is reset before adding items
                cmbMFAType.Items.Add("None");
                cmbMFAType.Items.Add("Email 2FA");

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT MFAType FROM Users WHERE ID = @UserID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            cmbMFAType.SelectedItem = result.ToString();
                        }
                        else
                        {
                            cmbMFAType.SelectedItem = "None"; // Default to "None" if NULL
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading MFA settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveMFASetting()
        {
            string selectedMFA = cmbMFAType.SelectedItem?.ToString();
            if (selectedMFA == "None")
            {
                selectedMFA = null; // Store NULL in the database
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE Users SET MFAType = @MFAType WHERE ID = @UserID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@MFAType", (object)selectedMFA ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("MFA setting updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMFASetting(); // Refresh UI after saving
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating MFA settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveMFASetting();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide the current form

            // ✅ Check if frmUserHomePage is already open
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is frmUserHomePage)
                {
                    openForm.Show();  // Bring existing home page to the front
                    openForm.BringToFront();
                    return; // ✅ Stop here to prevent duplicate windows
                }
            }

            // ✅ If no existing frmUserHomePage, create a new one
            frmUserHomePage newHomePage = new frmUserHomePage(userId);
            newHomePage.Show();
        }

    }
}
