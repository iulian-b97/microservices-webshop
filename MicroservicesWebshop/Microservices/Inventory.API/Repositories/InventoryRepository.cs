using Inventory.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Inventory.API.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private IDistributedCache _distributedCache;

        public InventoryRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public void CreateBasketShop(BasketShop basketShop)
        {   
            // Set valid data for 24h in RedisCache
            var tomorrow = DateTime.Now.Date.AddDays(1);
            var totalSeconds = tomorrow.Subtract(DateTime.Now).TotalSeconds; 
            var distributedCacheEntryOptions = new DistributedCacheEntryOptions();
            distributedCacheEntryOptions.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(totalSeconds);
            distributedCacheEntryOptions.SlidingExpiration = null;

            // Convert to JSON
            var jsonData = JsonConvert.SerializeObject(basketShop);

            // Save data
            _distributedCache.SetString("InventoryData", jsonData, distributedCacheEntryOptions);
        }

        public void UpdateBasketShop(string userId, SelectedProduct selectedProduct)
        {
            var jsonData = _distributedCache.GetString("InventoryData");
            var basketShop = JsonConvert.DeserializeObject<BasketShop>(jsonData);

            if(basketShop != null && basketShop.UserId == userId)
            {
                basketShop.SelectedProducts.Add(selectedProduct);
                CreateBasketShop(basketShop);
            }       
        }

        public void UpdateSelectedProduct(string productCode, SelectedProduct selectedProduct)
        {
            throw new NotImplementedException();
        }

        public void RemoveSelectedProduct(string productCode)
        {
            throw new NotImplementedException();
        } 
    }
}
