using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.API.Entities;
using Product.API.Models;
using Product.API.Repositories.Category;
using Product.API.Repositories.Product;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(ProductEntity model)
        {
            //Check if the model is valid
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                                    new Response { Status = "BadRequest", Message = "Model is not valid!" });
            }

            //Check if we already have an existing category
            var userExists = _productRepository.GetByName(model.Name);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    new Response { Status = "Error", Message = "Product already exists!" });
            }

            //Creating and checking if the product was successfully created
            ProductEntity newProduct = new ProductEntity
            {
                ProductCode = model.ProductCode,
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock,
                CategoryId = model.CategoryId,
                Category = _categoryRepository.GetById(model.CategoryId),
                Description = model.Description,
                TechnicalSpecifications = model.TechnicalSpecifications,
                Reviews = model.Reviews
            };
            var result = _productRepository.Create(newProduct);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  new Response
                                  {
                                      Status = "Error",
                                      Message = "Product creation failed! Please check product details and try again."
                                  });
            }

            return Ok(new Response { Status = "Success", Message = "Product created successfully!" });
        }

        [HttpGet]
        [Route("GetProductsAllCategories")]
        public IActionResult GetProductsAllCategories()
        {
            //Check if products list is null
            var products = _productRepository.Get();
            if (products == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    new Response { Status = "Error", Message = "Products list is null!" });
            }

            return Ok(products);
        }

        [HttpGet]
        [Route("GetProductsPerCategory")]
        public IActionResult GetProductsPerCategory(string categoryId)
        {
            //Check if category id is null
            if(categoryId == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                                    new Response { Status = "BadRequest", Message = "Category name is null!" });
            }

            //Check if products list per category is null
            var productsPerCategory = _productRepository.GetPerCategory(categoryId);
            if(productsPerCategory == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    new Response { Status = "Error", Message = "Products list is null!" });
            }

            return Ok(productsPerCategory);
        }

        [HttpGet]
        [Route("GetProduct")]
        public IActionResult GetProduct(string id)
        {
            //Check if product is null
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    new Response { Status = "Error", Message = "Product does not exist!" });
            }

            return Ok(product);
        }

        [HttpPut]
        [Route("EditProduct")]
        public IActionResult EditProduct(string id, ProductEntity product)
        {
            //Check if product id is null
            if (id == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    new Response { Status = "Error", Message = "Product id does not exist!" });
            }

            //Check if product is null
            if (product == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                                    new Response { Status = "BadRequest", Message = "Product is null!" });
            }

            _productRepository.Update(id, product);
            return Ok(new Response { Status = "Success", Message = "Product updated successfully!" });
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(string id)
        {
            //Check if product id is null
            if (id == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    new Response { Status = "Error", Message = "Product id does not exist!" });
            }

            _productRepository.Remove(id);
            return Ok(new Response { Status = "Success", Message = "Product deleted successfully!" });
        }
    }
}
