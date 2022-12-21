using Product.API.Entities;

namespace Product.API.Repositories.Product
{
    public interface IProductRepository
    {
        List<ProductEntity> Get();
        List<ProductEntity> GetPerCategory(string categoryId);
        ProductEntity GetById(string id);
        ProductEntity GetByName(string name);
        ProductEntity Create(ProductEntity product);
        void Update(string id, ProductEntity product);
        void Remove(string id);
    }
}
