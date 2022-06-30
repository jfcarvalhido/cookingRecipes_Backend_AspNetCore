using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipesApp.Domain.Entities;
using RecipesApp.Domain.Models.Recipes;
using RecipesApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipesApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : Controller
    {
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;

        public RecipesController(IRecipeService recipeService, IMapper mapper)
        {
            _recipeService = recipeService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("ListAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var recipes = await _recipeService.GetAll();

            return Ok(recipes);
        }

        [HttpGet]
        [Route("SearchById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var recipe = await _recipeService.GetById(id);

            if (recipe == null) return NotFound();

            return Ok(recipe);
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(RecipeAddDto recipeDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var recipe = _mapper.Map<Recipe>(recipeDto);
            var recipeResult = await _recipeService.Add(recipe);

            if (recipeResult == null) return BadRequest();

            return Ok(recipeDto);
        }

        [HttpPut]
        [Route("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Recipe recipeDto)
        {
            if (id != recipeDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            await _recipeService.Update(recipeDto);

            return Ok(recipeDto);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove(int id)
        {
            var recipe = await _recipeService.GetById(id);
            if (recipe == null) return NotFound();

            await _recipeService.Remove(recipe);

            return Ok();
        }        

        [HttpGet]
        [Route("SearchByName/{title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Recipe>>> SearchByName(string title)
        {
            var recipes = _mapper.Map<List<Recipe>>(await _recipeService.GetRecipesByName(title));

            if (recipes == null || recipes.Count == 0) return NotFound("None Recipe found");

            return Ok(recipes);
        }

        [HttpGet]
        [Route("SearchByIngredient/{nameIngredient}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Recipe>>> SearchByIngredient(string nameIngredient)
        {
            var recipes = _mapper.Map<List<Recipe>>(await _recipeService.SearchRecipeByIngredient(nameIngredient));

            if (recipes == null || recipes.Count == 0) return NotFound("None Recipe found");

            return Ok(recipes);
        }

        [HttpGet]
        [Route("SearchByCategory/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Recipe>>> SearchByCategory(string name)
        {
            var recipes = _mapper.Map<List<Recipe>>(await _recipeService.SearchRecipeByCategory(name));

            if (recipes == null || recipes.Count == 0) return NotFound("None Recipe found");

            return Ok(recipes);
        }
    }
}
