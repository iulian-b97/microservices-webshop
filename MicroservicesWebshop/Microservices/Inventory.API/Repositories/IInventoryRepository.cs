using Inventory.API.Entities;

namespace Inventory.API.Repositories
{
    public interface IInventoryRepository
    {
        void CreateBasketShop(BasketShop basketShop);
        void UpdateBasketShop(string userId, SelectedProduct selectedProduct);
        BasketShop GetBasketShopByUser(string userId);
        void UpdateSelectedProduct(string productCode, SelectedProduct selectedProduct);
        void RemoveSelectedProduct(string productCode);
    }
}
