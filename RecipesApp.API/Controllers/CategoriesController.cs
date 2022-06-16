using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipesApp.Services.Interfaces;
using System.Threading.Tasks;

namespace RecipesApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            
        }

        [HttpGet]
        [Route("ListAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var category = await _categoryService.GetAll();

            if (category == null)
            {
                return BadRequest("No category found");
            }
            return Ok(category);
        }
    }
}
