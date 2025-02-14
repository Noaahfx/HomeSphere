using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace HomeSphere
{
    public partial class frmEditAlert : Form
    {
        private int alertId;

        public frmEditAlert(int alertId, string message, bool isActive)
        {
            InitializeComponent();
            this.alertId = alertId;
            txtMessage.Text = message;
            chkMakeActive.Checked = isActive;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newMessage = txtMessage.Text.Trim();

            if (string.IsNullOrWhiteSpace(newMessage))
            {
                MessageBox.Show("The message cannot be empty.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    conn.Open();

                    // Check for duplicate messages
                    string checkQuery = "SELECT COUNT(1) FROM Alerts WHERE Message = @Message AND ID != @ID";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Message", newMessage);
                        checkCmd.Parameters.AddWithValue("@ID", alertId);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("An alert with this message already exists. Please use a different message.");
                            return;
                        }
                    }

                    // Update the alert message and activation status
                    string updateQuery;

                    if (chkMakeActive.Checked)
                    {
                        // If "Make Active" is checked, activate this alert and deactivate all others
                        updateQuery = "UPDATE Alerts SET Message = @Message, IsActive = 1 WHERE ID = @ID; " +
                                      "UPDATE Alerts SET IsActive = 0 WHERE ID != @ID;";
                    }
                    else
                    {
                        // If "Make Active" is unchecked, deactivate this alert without affecting others
                        updateQuery = "UPDATE Alerts SET Message = @Message, IsActive = 0 WHERE ID = @ID;";
                    }

                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@Message", newMessage);
                        updateCmd.Parameters.AddWithValue("@ID", alertId);
                        updateCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Alert updated successfully!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating alert: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this alert?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                    {
                        conn.Open();
                        string deleteQuery = "DELETE FROM Alerts WHERE ID = @ID";
                        using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                        {
                            deleteCmd.Parameters.AddWithValue("@ID", alertId);
                            deleteCmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Alert deleted successfully!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting alert: {ex.Message}");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
