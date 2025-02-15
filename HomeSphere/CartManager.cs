using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace HomeSphere
{
    public static class CartManager
    {
        public static string CurrentUser { get; set; } = "DefaultUser";

        public static void SetCurrentUser(string userId)
        {
            CurrentUser = userId;
        }

        private static string connectionString =
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static List<CartItem> CartItems
        {
            get { return GetCartItemsForUser(CurrentUser); }
        }

        public static List<CartItem> GetCartItemsForUser(string userID)
        {
            var cartItems = new List<CartItem>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT ProductID, Name, Price, Quantity, ImagePath
                    FROM CartItems
                    WHERE UserID = @UserID
                ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cartItems.Add(new CartItem(
                                productID: (int)reader["ProductID"],
                                name: (string)reader["Name"],
                                price: (decimal)reader["Price"],
                                quantity: (int)reader["Quantity"],
                                imagePath: reader["ImagePath"].ToString()
                            ));
                        }
                    }
                }
            }

            return cartItems;
        }

        public static void AddToCart(int productId, string name, decimal price, int quantity)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // ✅ Fetch the ImagePath from Products table
                string getImageQuery = "SELECT ImagePath FROM Products WHERE ProductID = @ProductID";
                string imagePath = "default.jpg";

                using (SqlCommand cmdImage = new SqlCommand(getImageQuery, conn))
                {
                    cmdImage.Parameters.AddWithValue("@ProductID", productId);
                    object result = cmdImage.ExecuteScalar();
                    if (result != null)
                    {
                        imagePath = result.ToString();
                    }
                }

                string checkQuery = "SELECT Quantity FROM CartItems WHERE UserID = @UserID AND ProductID = @ProductID";
                int existingQty = 0;
                bool itemExists = false;

                using (SqlCommand cmdCheck = new SqlCommand(checkQuery, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@UserID", CurrentUser);
                    cmdCheck.Parameters.AddWithValue("@ProductID", productId);
                    object result = cmdCheck.ExecuteScalar();
                    if (result != null)
                    {
                        existingQty = Convert.ToInt32(result);
                        itemExists = true;
                    }
                }

                if (!itemExists)
                {
                    string insertQuery = @"
                        INSERT INTO CartItems (UserID, ProductID, Name, Price, Quantity, ImagePath)
                        VALUES (@UserID, @ProductID, @Name, @Price, @Quantity, @ImagePath)";

                    using (SqlCommand cmdInsert = new SqlCommand(insertQuery, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@UserID", CurrentUser);
                        cmdInsert.Parameters.AddWithValue("@ProductID", productId);
                        cmdInsert.Parameters.AddWithValue("@Name", name);
                        cmdInsert.Parameters.AddWithValue("@Price", price);
                        cmdInsert.Parameters.AddWithValue("@Quantity", quantity);
                        cmdInsert.Parameters.AddWithValue("@ImagePath", imagePath);
                        cmdInsert.ExecuteNonQuery();
                    }
                }
                else
                {
                    int newQty = existingQty + quantity;
                    string updateQuery = @"
                        UPDATE CartItems
                        SET Quantity = @Quantity
                        WHERE UserID = @UserID AND ProductID = @ProductID";

                    using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@Quantity", newQty);
                        cmdUpdate.Parameters.AddWithValue("@UserID", CurrentUser);
                        cmdUpdate.Parameters.AddWithValue("@ProductID", productId);
                        cmdUpdate.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void ClearCart()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string deleteQuery = @"
                    DELETE FROM CartItems
                    WHERE UserID = @UserID
                ";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", CurrentUser);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
