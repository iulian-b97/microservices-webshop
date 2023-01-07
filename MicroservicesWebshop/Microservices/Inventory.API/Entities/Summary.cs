namespace Inventory.API.Entities
{
    public class Summary
    {
        public int ProductsPrice { get; set; }
        public int ShippingPrice { get; set; }
        public int TotalPrice { get; set; }
        public string? DiscountCode { get; set; }
    }
}
