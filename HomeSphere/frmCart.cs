using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing; // ✅ Fix: Added for `Point`

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
                MessageBox.Show("Your cart is empty!", "Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var item in cartItems)
            {
                Panel card = new Panel
                {
                    Width = 220,
                    Height = 300,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(5)
                };

                // ✅ Load Product Image (Same as `frmProductPage.cs`)
                PictureBox pb = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Width = 180,
                    Height = 120,
                    Top = 5,
                    Left = 5
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
                        MessageBox.Show($"Error: Default image not found at {fallbackPath}", "Missing Image", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                Label lblProductName = new Label
                {
                    Text = item.Name,
                    AutoSize = true,
                    Top = pb.Bottom + 5,
                    Left = 5
                };

                Label lblPrice = new Label
                {
                    Text = $"${item.Price} x {item.Quantity}",
                    AutoSize = true,
                    Top = lblProductName.Bottom + 2,
                    Left = 5
                };

                card.Controls.Add(pb);
                card.Controls.Add(lblProductName);
                card.Controls.Add(lblPrice);
                flpCart.Controls.Add(card);
            }
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
    }
}
