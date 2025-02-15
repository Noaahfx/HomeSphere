using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace HomeSphere
{
    public partial class frmPayment : Form
    {
        public bool PaymentSuccessful { get; private set; } = false; // Flag for success

        public frmPayment()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string cardNumber = txtCardNumber.Text.Trim();
            string cardName = txtCardName.Text.Trim();
            string expiryDate = txtExpiryDate.Text.Trim();
            string cvv = txtCVV.Text.Trim();

            // Basic Validation
            if (string.IsNullOrEmpty(cardName))
            {
                MessageBox.Show("Please enter the name on the card.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(cardNumber, @"^\d{16}$"))
            {
                MessageBox.Show("Invalid card number. Must be 16 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(expiryDate, @"^(0[1-9]|1[0-2])\/\d{2}$"))
            {
                MessageBox.Show("Invalid expiry date format. Use MM/YY.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(cvv, @"^\d{3}$"))
            {
                MessageBox.Show("Invalid CVV. Must be 3 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simulate Payment Success
            MessageBox.Show("Payment processed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            PaymentSuccessful = true;
            this.Close(); // Close form after success
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Cancel payment
        }
    }
}
