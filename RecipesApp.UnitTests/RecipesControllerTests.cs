using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecipesApp.API.Controllers;
using RecipesApp.Domain.Entities;
using RecipesApp.Domain.Models.Recipes;
using RecipesApp.Services.Interfaces;
using System.Collections.Generic;
using Xunit;

namespace RecipesApp.UnitTests
{
    public class RecipesControllerTests
    {
        private readonly Mock<IRecipeService> _mockService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly RecipesController _controller;

        public RecipesControllerTests()
        {
            _mockService = new Mock<IRecipeService>();
            _mockMapper = new Mock<IMapper>();
            _controller = new RecipesController(_mockService.Object, _mockMapper.Object);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnExactNumberofRecipes()
        {
            IList<Recipe> listRecipes = new List<Recipe>() 
            { new Recipe(), new Recipe(), new Recipe(), new Recipe(), new Recipe(), new Recipe() }; 

            _mockService.Setup(repo => repo.GetAll()).ReturnsAsync(listRecipes);

            var result = _controller.GetAll().Result;
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var recipes = Assert.IsType<List<Recipe>>(viewResult.Value);

            Assert.Equal(6, recipes.Count);            
        }

        [Fact]
        public void Create_ActionExecutes_ReturnBadObjectResult()
        {
            var recipeDto = new RecipeAddDto()
            {
                Title = "Test 1",
                Serving = 4,
                Difficulty = Difficulty.easy,
                CookingTime = 40,
                Preparation = "Preheat oven to 400 degrees F (200 degrees C)..."
            };

            var result = _controller.Add(recipeDto).Result;

            Assert.IsType<BadRequestResult>(result);
        }
    }
}
