using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace HomeSphere
{
    public partial class frmEditAlert : Form
    {
        private int alertId;

        public frmEditAlert(int alertId, string message, bool isActive, DateTime startTime, DateTime endTime)
        {
            InitializeComponent();
            this.alertId = alertId;
            txtMessage.Text = message;
            chkMakeActive.Checked = isActive;
            dtpStartTime.Value = startTime;
            dtpEndTime.Value = endTime;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newMessage = txtMessage.Text.Trim();
            DateTime newStartTime = dtpStartTime.Value;
            DateTime newEndTime = dtpEndTime.Value;
            bool isActive = chkMakeActive.Checked; // ✅ Retrieve checkbox value

            if (string.IsNullOrWhiteSpace(newMessage))
            {
                MessageBox.Show("The message cannot be empty.");
                return;
            }

            if (newEndTime <= newStartTime)
            {
                MessageBox.Show("End time must be later than Start time.");
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

                    // ✅ **Update Query now includes `IsActive`**
                    string updateQuery = "UPDATE Alerts SET Message = @Message, StartTime = @StartTime, EndTime = @EndTime, IsActive = @IsActive WHERE ID = @ID;";
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@Message", newMessage);
                        updateCmd.Parameters.AddWithValue("@StartTime", newStartTime);
                        updateCmd.Parameters.AddWithValue("@EndTime", newEndTime);
                        updateCmd.Parameters.AddWithValue("@IsActive", isActive ? 1 : 0); // ✅ Convert `bool` to `int`
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
