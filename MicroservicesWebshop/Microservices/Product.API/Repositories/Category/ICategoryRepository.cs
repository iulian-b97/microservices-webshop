using Product.API.Entities;

namespace Product.API.Repositories.Category
{
    public interface ICategoryRepository
    {
        List<CategoryEntity> Get();
        CategoryEntity GetById(string id);
        CategoryEntity GetByName(string name);
        CategoryEntity Create(CategoryEntity category);
        void Update(string id, CategoryEntity category);
        void Remove(string id);
    }
}
