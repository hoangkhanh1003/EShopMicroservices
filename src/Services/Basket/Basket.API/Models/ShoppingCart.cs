namespace Basket.API.Models
{
    public class ShoppingCart
    {
        public string UserName { get; set; } = default!;
        public List<ShoppingCardItem> Items { get; set; } = new List<ShoppingCardItem>();
        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        // Required for Mapping
        public ShoppingCart()
        {
        }
    }
}
