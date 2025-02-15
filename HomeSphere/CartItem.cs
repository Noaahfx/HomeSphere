namespace HomeSphere
{
    public class CartItem
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; } // ✅ Added Image Path

        public decimal Total => Price * Quantity;

        public CartItem(int productID, string name, decimal price, int quantity, string imagePath)
        {
            ProductID = productID;
            Name = name;
            Price = price;
            Quantity = quantity;
            ImagePath = imagePath;
        }
    }
}
