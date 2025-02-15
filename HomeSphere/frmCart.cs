using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing; // ✅ Fix: Added for `Point`
using System.Configuration;
using System.Data.SqlClient;

namespace HomeSphere
{
    public partial class frmCart : Form
    {
        public frmCart()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmCart_Load);

        }

        private void frmCart_Load(object sender, EventArgs e)
        {
            RefreshCartView();
        }

        private void RefreshCartView()
        {
            List<CartItem> cartItems = CartManager.GetCartItemsForUser(CartManager.CurrentUser);
            flpCart.Controls.Clear();

            if (cartItems.Count == 0)
            {
                // ❌ Remove MessageBox
                Label lblEmptyCart = new Label
                {
                    Text = "No products in the cart",
                    AutoSize = true,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    ForeColor = Color.Gray,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Top
                };
                flpCart.Controls.Add(lblEmptyCart);
                return;
            }

            foreach (var item in cartItems)
            {
                Panel card = new Panel
                {
                    Width = 250,
                    Height = 350,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(5)
                };

                // ✅ Load Product Image
                PictureBox pb = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Width = 180,
                    Height = 120,
                    Top = 5,
                    Left = 35
                };

                string binPath = System.IO.Path.Combine(Application.StartupPath, "ProductImages", item.ImagePath);
                if (System.IO.File.Exists(binPath))
                {
                    pb.Image = Image.FromFile(binPath);
                }
                else
                {
                    string projectDir = AppDomain.CurrentDomain.BaseDirectory;
                    string fallbackFolder = System.IO.Path.Combine(projectDir, "..", "..", "ProductImages");
                    string fallbackPath = System.IO.Path.Combine(fallbackFolder, "default.jpg");

                    if (System.IO.File.Exists(fallbackPath))
                    {
                        pb.Image = Image.FromFile(fallbackPath);
                    }
                    else
                    {
                        pb.Image = null; // Set to null if image is missing
                    }
                }

                // ✅ Product Name
                Label lblProductName = new Label
                {
                    Text = item.Name,
                    AutoSize = true,
                    Top = pb.Bottom + 5,
                    Left = 5
                };

                // ✅ Show Total Price Directly
                Label lblTotalPrice = new Label
                {
                    Text = $"Total: ${item.Total:F2}", // Calculates price * quantity
                    AutoSize = true,
                    Top = lblProductName.Bottom + 2,
                    Left = 5
                };

                // ✅ Show Quantity Separately
                Label lblQuantity = new Label
                {
                    Text = $"Quantity: {item.Quantity}",
                    AutoSize = true,
                    Top = lblTotalPrice.Bottom + 2,
                    Left = 5
                };

                // ✅ Checkout Item Button
                Button btnCheckoutItem = new Button
                {
                    Text = "Checkout Item",
                    AutoSize = true,
                    Top = lblQuantity.Bottom + 5,
                    Left = 5
                };
                btnCheckoutItem.Click += (s, e) => CheckoutSingleItem(item);

                // ✅ Remove Item Button
                Button btnRemoveItem = new Button
                {
                    Text = "Remove Item",
                    AutoSize = true,
                    Top = btnCheckoutItem.Bottom + 5,
                    Left = 5
                };
                btnRemoveItem.Click += (s, e) => RemoveItem(item.ProductID);

                // ✅ Add Controls to Card
                card.Controls.Add(pb);
                card.Controls.Add(lblProductName);
                card.Controls.Add(lblTotalPrice);
                card.Controls.Add(lblQuantity);
                card.Controls.Add(btnCheckoutItem);
                card.Controls.Add(btnRemoveItem);

                flpCart.Controls.Add(card);
            }

            // ✅ Add "Checkout All" & "Clear Cart" Buttons
            Button btnCheckoutAll = new Button
            {
                Text = "Checkout All",
                AutoSize = true,
                Top = 10,
                Left = 10
            };
            btnCheckoutAll.Click += new EventHandler(CheckoutAllItems);

            Button btnClearCart = new Button
            {
                Text = "Clear Cart",
                AutoSize = true,
                Top = 10,
                Left = 120
            };
            btnClearCart.Click += new EventHandler(ClearCart);

            flpCart.Controls.Add(btnCheckoutAll);
            flpCart.Controls.Add(btnClearCart);
        }


        private void CheckoutSingleItem(CartItem item)
        {
            // ✅ Open Payment Form Before Proceeding
            frmPayment paymentForm = new frmPayment();
            paymentForm.ShowDialog();

            if (!paymentForm.PaymentSuccessful)
            {
                MessageBox.Show("Payment failed or cancelled.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();

                // ✅ Check Available Stock Before Checkout
                string stockCheckQuery = "SELECT Quantity FROM Products WHERE ProductID = @ProductID";
                int availableStock = 0;

                using (SqlCommand stockCheckCmd = new SqlCommand(stockCheckQuery, conn))
                {
                    stockCheckCmd.Parameters.AddWithValue("@ProductID", item.ProductID);
                    object result = stockCheckCmd.ExecuteScalar();
                    if (result != null)
                    {
                        availableStock = Convert.ToInt32(result);
                    }
                }

                // ❌ If not enough stock, stop checkout
                if (item.Quantity > availableStock)
                {
                    MessageBox.Show($"Not enough stock for {item.Name}. Available: {availableStock}, In Cart: {item.Quantity}.\n" +
                                    "Please update your cart and try again.",
                                    "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Proceed with Checkout
                string insertOrderQuery = @"
            INSERT INTO Orders (UserID, ProductName, Price, Quantity, OrderDate)
            VALUES (@UserID, @ProductName, @Price, @Quantity, GETDATE())";

                using (SqlCommand cmdOrder = new SqlCommand(insertOrderQuery, conn))
                {
                    cmdOrder.Parameters.AddWithValue("@UserID", CartManager.CurrentUser);
                    cmdOrder.Parameters.AddWithValue("@ProductName", item.Name);
                    cmdOrder.Parameters.AddWithValue("@Price", item.Price);
                    cmdOrder.Parameters.AddWithValue("@Quantity", item.Quantity);
                    cmdOrder.ExecuteNonQuery();
                }

                // ✅ Update Stock in `Products` Table
                string updateStockQuery = @"
            UPDATE Products 
            SET Quantity = Quantity - @Quantity 
            WHERE ProductID = @ProductID";

                using (SqlCommand cmdUpdate = new SqlCommand(updateStockQuery, conn))
                {
                    cmdUpdate.Parameters.AddWithValue("@Quantity", item.Quantity);
                    cmdUpdate.Parameters.AddWithValue("@ProductID", item.ProductID);
                    cmdUpdate.ExecuteNonQuery();
                }
            }

            RemoveItem(item.ProductID);
            RefreshCartView();
            MessageBox.Show("Item purchased successfully! Stock updated.", "Checkout Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void RemoveItem(int productId)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();
                string query = @"
            DELETE FROM CartItems
            WHERE UserID = @UserID AND ProductID = @ProductID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", CartManager.CurrentUser);
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    cmd.ExecuteNonQuery();
                }
            }

            RefreshCartView();
            MessageBox.Show("Item removed from cart!", "Cart Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CheckoutAllItems(object sender, EventArgs e)
        {
            List<CartItem> cartItems = CartManager.GetCartItemsForUser(CartManager.CurrentUser);

            if (cartItems.Count == 0)
            {
                MessageBox.Show("Your cart is empty!", "Checkout Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Open Payment Form Before Proceeding
            frmPayment paymentForm = new frmPayment();
            paymentForm.ShowDialog();

            if (!paymentForm.PaymentSuccessful)
            {
                MessageBox.Show("Payment failed or cancelled.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();

                string stockCheckQuery = "SELECT Quantity FROM Products WHERE ProductID = @ProductID";
                bool hasStockIssue = false;

                foreach (var item in cartItems)
                {
                    using (SqlCommand stockCheckCmd = new SqlCommand(stockCheckQuery, conn))
                    {
                        stockCheckCmd.Parameters.AddWithValue("@ProductID", item.ProductID);
                        object result = stockCheckCmd.ExecuteScalar();
                        int availableStock = result != null ? Convert.ToInt32(result) : 0;

                        // ❌ If cart quantity > available stock, stop checkout
                        if (item.Quantity > availableStock)
                        {
                            MessageBox.Show($"Not enough stock for {item.Name}. Available: {availableStock}, In Cart: {item.Quantity}.\n" +
                                            "Please update your cart and try again.",
                                            "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            hasStockIssue = true;
                        }
                    }
                }

                // ❌ If any item had a stock issue, stop the checkout process
                if (hasStockIssue) return;

                string orderQuery = @"
            INSERT INTO Orders (UserID, ProductName, Price, Quantity, OrderDate)
            VALUES (@UserID, @ProductName, @Price, @Quantity, GETDATE())";

                string updateQuery = @"
            UPDATE Products 
            SET Quantity = Quantity - @Quantity 
            WHERE ProductID = @ProductID";

                foreach (var item in cartItems)
                {
                    using (SqlCommand cmdOrder = new SqlCommand(orderQuery, conn))
                    {
                        cmdOrder.Parameters.AddWithValue("@UserID", CartManager.CurrentUser);
                        cmdOrder.Parameters.AddWithValue("@ProductName", item.Name);
                        cmdOrder.Parameters.AddWithValue("@Price", item.Price);
                        cmdOrder.Parameters.AddWithValue("@Quantity", item.Quantity);
                        cmdOrder.ExecuteNonQuery();
                    }

                    using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@Quantity", item.Quantity);
                        cmdUpdate.Parameters.AddWithValue("@ProductID", item.ProductID);
                        cmdUpdate.ExecuteNonQuery();
                    }
                }
            }

            CartManager.ClearCart();
            RefreshCartView();
            MessageBox.Show("All items purchased successfully! Stock updated.", "Checkout Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void ClearCart(object sender, EventArgs e)
        {
            CartManager.ClearCart();
            RefreshCartView();
            MessageBox.Show("Cart has been cleared!", "Cart Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void Home_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Overview_Click(object sender, EventArgs e)
        {
            OverviewForm overviewForm = new OverviewForm();
            overviewForm.Show();
            this.Hide();
        }

        private void ManageRecords_Click(object sender, EventArgs e)
        {
            TableManagement tableManagement = new TableManagement();
            tableManagement.Show();
            this.Hide();
        }

        private void EventManagement_Click(object sender, EventArgs e)
        {
            frmAlertManagement alertManagement = new frmAlertManagement();
            this.Hide();
            alertManagement.Show();
        }

        private void Products_Click(object sender, EventArgs e)
        {
            frmProductPage frmproductpage = new frmProductPage();
            frmproductpage.Show();
            this.Hide();
        }

        private void tsddbUserMenu_Click(object sender, EventArgs e)
        {
        }

        private void tsmiLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Logout Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                this.Close();
                frmAdminLogin adminLoginForm = new frmAdminLogin();
                adminLoginForm.Show();
            }
        }

        private void tsmiViewCart_Click(object sender, EventArgs e)
        {
            frmCart frmcart = new frmCart();
            frmcart.Show();
            this.Hide();
        }

        private void tsmiOrderHistory_Click(object sender, EventArgs e)
        {
            frmOrderHistory orderHistoryForm = new frmOrderHistory();
            orderHistoryForm.Show();
            this.Hide();
        }
    }
}
