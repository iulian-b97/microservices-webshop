using Inventory.API.Entities;
using Inventory.API.Models;
using Inventory.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private IInventoryRepository _repository;

        public InventoryController(IInventoryRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("CreateBasketShop")]
        public ActionResult CreateBasketShop(BasketShop basketShop)
        {
            //Check if basketshop is null
            if(basketShop == null) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    new Response { Status = "Error", Message = "Basketshop is null!" });
            }

            //Create basketshop
            _repository.CreateBasketShop(basketShop);
            return Ok(new Response { Status = "Success", Message = "Basketshop created successfully!" });
        }

        [HttpPost]
        [Route("UpdateBasketShop")]
        public ActionResult UpdateBasketShop(string userId, SelectedProduct selectedProduct)
        {
            //Check if user id or product is null
            if (userId == null || selectedProduct == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    new Response { Status = "Error", Message = "User id or product is null!" });
            }

            //Update basketshop
            _repository.UpdateBasketShop(userId, selectedProduct);
            return Ok(new Response { Status = "Success", Message = "Basketshop updated successfully!" });
        }

        [HttpGet]
        [Route("GetBasketShop")]
        public ActionResult GetBasketShop(string userId)
        {
            //Check if user id is null
            if (userId == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    new Response { Status = "Error", Message = "User id is null!" });
            }

            //Return basketshop
            var basketShop = _repository.GetBasketShopByUser(userId);
            return Ok(basketShop);
        }
    }
}
