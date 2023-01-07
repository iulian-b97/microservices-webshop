namespace Inventory.API.Entities
{
    public class Summary
    {
        public int TotalPrice { get; set; }
        public int ShippingPrice { get; set; }
        public string? DiscountCode { get; set; }
    }
}
