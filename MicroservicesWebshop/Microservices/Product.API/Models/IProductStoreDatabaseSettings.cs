namespace Product.API.Models
{
    public interface IProductStoreDatabaseSettings
    {
        string CategoriesCollectionName { get; set; }
        string ProductsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
