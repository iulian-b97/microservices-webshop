using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Product.API.Entities;
using Product.API.Models;
using Product.API.Repositories.Category;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(CategoryEntity model)
        {
            //Check if the model is valid
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                                    new Response { Status = "BadRequest", Message = "Model is not valid!" });
            }

            //Check if we already have an existing category
            var userExists = _repository.GetByName(model.Name);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    new Response { Status = "Error", Message = "Category already exists!" });
            }

            //Creating and checking if the category was successfully created
            CategoryEntity newCategory = new CategoryEntity
            {
                Name = model.Name,
                isActive = model.isActive,
            };
            var result = _repository.Create(newCategory);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  new Response
                                  {
                                      Status = "Error",
                                      Message = "Category creation failed! Please check category details and try again."
                                  });
            }

            return Ok(new Response { Status = "Success", Message = "Category created successfully!" });
        }

        [HttpGet]
        [Route("GetCategories")]
        public IActionResult GetCategories()
        {
            //Check if categories list is null
            var categories = _repository.Get();
            if (categories == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    new Response { Status = "Error", Message = "Categories list is null!" });
            }

            return Ok(categories);
        }

        [HttpGet]
        [Route("GetCategory")]
        public IActionResult GetCategory(string id)
        {
            //Check if category is null
            var category = _repository.GetById(id);
            if (category == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    new Response { Status = "Error", Message = "Category does not exist!" });
            }

            return Ok(category);
        }

        [HttpPut]
        [Route("EditCategory")]
        public IActionResult EditCategory(string id, CategoryEntity category)
        {
            //Check if category id is null
            if (id == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    new Response { Status = "Error", Message = "Category id does not exist!" });
            }

            //Check if category is null
            if (category == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                                    new Response { Status = "BadRequest", Message = "Category is null!" });
            }

            _repository.Update(id, category);
            return Ok(new Response { Status = "Success", Message = "Category updated successfully!" });
        }

        [HttpDelete]
        [Route("DeleteCategory")]
        public IActionResult DeleteCategory(string id)
        {
            //Check if category id is null
            if (id == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    new Response { Status = "Error", Message = "Category id does not exist!" });
            }

            _repository.Remove(id);
            return Ok(new Response { Status = "Success", Message = "Category deleted successfully!" });
        }
    }
}
