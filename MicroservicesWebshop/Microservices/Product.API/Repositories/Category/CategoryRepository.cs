using Product.API.Entities;
using Product.API.Models;
using MongoDB.Driver;

namespace Product.API.Repositories.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<CategoryEntity> _categories;

        public CategoryRepository(IProductStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
           var database = mongoClient.GetDatabase(settings.DatabaseName);
           _categories =  database.GetCollection<CategoryEntity>(settings.CategoriesCollectionName);
        }

        public CategoryEntity Create(CategoryEntity category)
        {
            _categories.InsertOne(category);
            return category;
        }

        public List<CategoryEntity> Get()
        {
            return _categories.Find(category => true).ToList();
        }

        public CategoryEntity GetById(string id)
        {
            return _categories.Find(category => category.Id == id).FirstOrDefault();
        }

        public string GetFirstCategoryId()
        {
            var res = _categories.Find(category => category.Id != null).FirstOrDefault();
            return res.Id;
        }

        public CategoryEntity GetByName(string name)
        {
            return _categories.Find(category => category.Name == name).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _categories.DeleteOne(category => category.Id == id);
        }

        public void Update(string id, CategoryEntity category)
        {
            _categories.ReplaceOne(category => category.Id == id, category);
        }
    }
}
