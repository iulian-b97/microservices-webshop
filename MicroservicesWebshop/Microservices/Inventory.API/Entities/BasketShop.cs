namespace Inventory.API.Entities
{
    public class BasketShop
    {
        public string? UserId { get; set; }
        public ICollection<SelectedProduct>? SelectedProducts { get; set; }
        public Summary? Summary { get; set; } 
    }
}
