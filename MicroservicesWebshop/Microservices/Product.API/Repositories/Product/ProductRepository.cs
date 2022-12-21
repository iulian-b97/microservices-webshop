using MongoDB.Driver;
using Product.API.Entities;
using Product.API.Models;

namespace Product.API.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<ProductEntity> _products;

        public ProductRepository(IProductStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _products = database.GetCollection<ProductEntity>(settings.ProductsCollectionName);
        }

        public ProductEntity Create(ProductEntity product)
        {
            _products.InsertOne(product);
            return product;
        }

        public List<ProductEntity> Get()
        {
            return _products.Find(product => true).ToList();
        }

        public List<ProductEntity> GetPerCategory(string categoryId)
        {
            return _products.Find(product => product.CategoryId == categoryId).ToList();
        }

        public ProductEntity GetById(string id)
        {
            return _products.Find(product => product.Id == id).FirstOrDefault();
        }

        public ProductEntity GetByName(string name)
        {
            return _products.Find(product => product.Name == name).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _products.DeleteOne(product => product.Id == id);
        }

        public void Update(string id, ProductEntity product)
        {
            _products.ReplaceOne(product => product.Id == id, product);
        }
    }
}
