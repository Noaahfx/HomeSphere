using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Stripe;

namespace HomeSphere
{
    public partial class frmPayment : Form
    {
        public bool PaymentSuccessful { get; private set; } = false;
        private int expectedAmountInCents;  // Expected amount in cents

        // Constructor requires the expected amount (in cents)
        public frmPayment(int expectedAmountInCents)
        {
            InitializeComponent();
            this.expectedAmountInCents = expectedAmountInCents;

            // Set your Stripe secret key (test mode)
            StripeConfiguration.ApiKey = "sk_test_51Qsep2D7SN32WlRgBf3EYtnh2uZLY6tAKX7Wl94FMcTTVK5pfmgwoZ8uIMfcY8uq45Ag8iMeu7bc9twq2sPDG5rf00poneGMdk";
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
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

            // Parse expiry date (MM/YY)
            string[] parts = expiryDate.Split('/');
            if (parts.Length != 2)
            {
                MessageBox.Show("Expiry date is invalid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int expMonth = int.Parse(parts[0]);
            int expYear = 2000 + int.Parse(parts[1]);

            try
            {
                var tokenOptions = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = cardNumber,
                        ExpMonth = expMonth.ToString(),  // Convert int to string
                        ExpYear = expYear.ToString(),    // Convert int to string
                        Cvc = cvv,
                        Name = cardName
                    }
                };

                Token stripeToken;
                // If the card number is the known test card, use the official test token.
                if (cardNumber == "4242424242424242")
                {
                    stripeToken = new Token() { Id = "tok_visa" };
                }
                else
                {
                    var tokenService = new TokenService();
                    stripeToken = await tokenService.CreateAsync(tokenOptions);
                }

                // Create a charge using the token
                var chargeOptions = new ChargeCreateOptions
                {
                    Amount = expectedAmountInCents,   // in cents
                    Currency = "usd",
                    Description = "Charge for order",
                    Source = stripeToken.Id,  // use token from above
                };

                var chargeService = new ChargeService();
                Charge charge = await chargeService.CreateAsync(chargeOptions);

                // Verify that the charge succeeded and the amount is correct
                if (charge.Status == "succeeded")
                {
                    if (charge.Amount != expectedAmountInCents)
                    {
                        MessageBox.Show("The charged amount does not match the expected total.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PaymentSuccessful = false;
                    }
                    else
                    {
                        MessageBox.Show("Payment processed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PaymentSuccessful = true;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Payment failed. Please try again.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (StripeException ex)
            {
                MessageBox.Show($"Stripe error: {ex.Message}", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing payment: {ex.Message}", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
