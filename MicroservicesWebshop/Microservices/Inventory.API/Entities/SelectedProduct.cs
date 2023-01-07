namespace Inventory.API.Entities
{
    public class SelectedProduct
    {
        public string? ProductCode { get; set; }
        public string? Name { get; set; }
        public float Price { get; set; }
        public string? Mark { get; set; }
        public int Length { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public float Weight { get; set; }
    }
}
