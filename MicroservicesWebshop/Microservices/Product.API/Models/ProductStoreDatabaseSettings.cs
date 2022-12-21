namespace Product.API.Models
{
    public class ProductStoreDatabaseSettings : IProductStoreDatabaseSettings
    {
        public string CategoriesCollectionName { get; set; } = String.Empty;
        public string ProductsCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
