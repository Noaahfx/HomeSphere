using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace HomeSphere
{
    public partial class frmProductPage : Form
    {
        private string connectionString = ConfigurationManager
            .ConnectionStrings["DefaultConnection"].ConnectionString;

        public frmProductPage()
        {
            InitializeComponent();

            // ✅ Only set the user if it's not already assigned from login
            if (string.IsNullOrEmpty(CartManager.CurrentUser)
                || CartManager.CurrentUser == "DefaultUser")
            {
                CartManager.CurrentUser = "Admin"; // Or fetch from session/login
            }

            LoadProducts();  // Fill the FlowLayoutPanel with "cards"
        }

        private void LoadProducts()
        {
            flpProducts.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // ✅ Remove "WHERE Quantity > 0" so we show out-of-stock products too.
                string query = @"
            SELECT ProductID, Name, Price, ImagePath, Quantity
            FROM Products";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    Panel card = CreateProductCard(row);
                    flpProducts.Controls.Add(card);
                }
            }
        }


        private Panel CreateProductCard(DataRow row)
        {
            int productId = Convert.ToInt32(row["ProductID"]);
            string productName = row["Name"].ToString();
            decimal price = Convert.ToDecimal(row["Price"]);
            int quantity = Convert.ToInt32(row["Quantity"]);
            string imageFileName = row["ImagePath"].ToString();

            // Panel
            Panel panel = new Panel();
            panel.Width = 200;
            panel.Height = 280;
            panel.BorderStyle = BorderStyle.FixedSingle;

            // PictureBox
            PictureBox pb = new PictureBox();
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Width = 180;
            pb.Height = 120;
            pb.Top = 5;
            pb.Left = 5;

            // Try to load the image from your bin\ProductImages
            string binPath = System.IO.Path.Combine(
                Application.StartupPath, "ProductImages", imageFileName);

            if (System.IO.File.Exists(binPath))
            {
                pb.Image = Image.FromFile(binPath);
            }
            else
            {
                // fallback: use project’s ProductImages or default.jpg
                string projectDir = AppDomain.CurrentDomain.BaseDirectory;
                string fallbackFolder = System.IO.Path.Combine(
                    projectDir, "..", "..", "ProductImages");
                string fallbackPath = System.IO.Path.Combine(
                    fallbackFolder, imageFileName);

                if (System.IO.File.Exists(fallbackPath))
                {
                    pb.Image = Image.FromFile(fallbackPath);
                }
                else
                {
                    pb.Image = Image.FromFile(System.IO.Path.Combine(
                        fallbackFolder, "default.jpg"));
                }
            }

            panel.Controls.Add(pb);

            // Labels
            Label lblName = new Label();
            lblName.Text = productName;
            lblName.AutoSize = true;
            lblName.Top = pb.Bottom + 5;
            lblName.Left = 5;
            panel.Controls.Add(lblName);

            Label lblPrice = new Label();
            lblPrice.Text = "$" + price.ToString("F2");
            lblPrice.AutoSize = true;
            lblPrice.Top = lblName.Bottom + 2;
            lblPrice.Left = 5;
            panel.Controls.Add(lblPrice);

            Label lblStock = new Label();
            lblStock.Text = quantity > 0 ? "Stock: " + quantity : "Out of Stock";
            lblStock.AutoSize = true;
            lblStock.Top = lblPrice.Bottom + 2;
            lblStock.Left = 5;
            lblStock.ForeColor = quantity > 0 ? Color.Black : Color.Red; // Red if out of stock
            panel.Controls.Add(lblStock);

            // NumericUpDown
            NumericUpDown nudQuantity = new NumericUpDown();
            nudQuantity.Minimum = 1;
            nudQuantity.Maximum = quantity > 0 ? quantity : 1; // Prevents selecting more than available stock
            nudQuantity.Value = 1;
            nudQuantity.Top = lblStock.Bottom + 5;
            nudQuantity.Left = 5;
            nudQuantity.Width = 60;
            nudQuantity.Enabled = quantity > 0; // Disable if out of stock
            panel.Controls.Add(nudQuantity);

            // Add to Cart button
            Button btnAdd = new Button();
            btnAdd.Text = "Add to Cart";
            btnAdd.Top = nudQuantity.Bottom + 5;
            btnAdd.Left = 5;
            btnAdd.AutoSize = true;
            btnAdd.Enabled = quantity > 0; // Disable if out of stock

            btnAdd.Click += (s, e) =>
            {
                int qtyToAdd = (int)nudQuantity.Value;
                if (quantity > 0 && qtyToAdd > 0)
                {
                    CartManager.AddToCart(productId, productName, price, qtyToAdd);
                    MessageBox.Show($"{qtyToAdd} x {productName} added to cart!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Immediately open the frmCart
                    frmCart cartForm = new frmCart();
                    cartForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("This product is out of stock!",
                        "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            panel.Controls.Add(btnAdd);
            return panel;
        }


        /// <summary>
        /// Optional: If you keep a Checkout button here as well.
        /// </summary>
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            // Now CartManager.CartItems works because we added the property below
            if (CartManager.CartItems.Count == 0)
            {
                MessageBox.Show("Your cart is empty!",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in CartManager.CartItems)
                {
                    // Subtract the entire quantity
                    UpdateProductQuantity(item.ProductID, item.Quantity);

                    // Insert an Orders row with unit Price and Quantity
                    string query = @"
                        INSERT INTO Orders (ProductName, Price, Quantity, OrderDate)
                        VALUES (@ProductName, @Price, @Quantity, GETDATE())
                    ";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductName", item.Name);
                        cmd.Parameters.AddWithValue("@Price", item.Price);
                        cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            MessageBox.Show("Purchase successful!",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear the CartItems table for this user:
            CartManager.ClearCart();

            // Refresh the product list (updates stock)
            LoadProducts();
        }

        private void UpdateProductQuantity(int productId, int quantity)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    UPDATE Products
                    SET Quantity = Quantity - @Quantity
                    WHERE ProductID = @ProductID
                ";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // -------------------------
        // NAVBAR events, etc.
        // -------------------------

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
    }
}
