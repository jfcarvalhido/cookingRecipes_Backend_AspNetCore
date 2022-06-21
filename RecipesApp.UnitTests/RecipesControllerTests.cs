using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecipesApp.API.Controllers;
using RecipesApp.Domain.Entities;
using RecipesApp.Services.Interfaces;
using System.Collections.Generic;
using Xunit;

namespace RecipesApp.UnitTests
{
    public class RecipesControllerTests
    {
        private readonly Mock<IRecipeService> _mockRepo;
        private readonly RecipesController _controller;
        private readonly IMapper _mapper;

        public RecipesControllerTests()
        {
            _mockRepo = new Mock<IRecipeService>();
            _controller = new RecipesController(_mockRepo.Object, _mapper);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnExactNumberofRecipes()
        {
            IList<Recipe> listRecipes = new List<Recipe>() 
            { new Recipe(), new Recipe(), new Recipe(), new Recipe(), new Recipe(), new Recipe() }; 

            _mockRepo.Setup(repo => repo.GetAll()).ReturnsAsync(listRecipes);

            var result = _controller.GetAll().Result;
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var recipes = Assert.IsType<List<Recipe>>(viewResult.Value);

            Assert.Equal(6, recipes.Count);            
        }    

        [Fact]
        public void Create_ActionExecutes_ReturnRecipeOk()
        {

        }

        [Fact]
        public void Create_InValidModel_CreateRecipeNeverExecute()
        {

        }
    }
}
