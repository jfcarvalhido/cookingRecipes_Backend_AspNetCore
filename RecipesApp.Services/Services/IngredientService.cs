using RecipesApp.Domain.Entities;
using RecipesApp.Domain.Interfaces;
using RecipesApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesApp.Services.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IRecipeService _recipeService;

        public IngredientService(IIngredientRepository ingredientRepository, IRecipeService recipeService)
        {
            _ingredientRepository = ingredientRepository;
            _recipeService = recipeService;
        }

        public async Task<Ingredient> Add(Ingredient ingredient)
        {
            if (_ingredientRepository.Search(i => i.NameIngredient == ingredient.NameIngredient).Result.Any())
            {
                return null;
            }
            await _ingredientRepository.Add(ingredient);
            return ingredient;
        }

        public void Dispose()
        {
            _ingredientRepository?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<Ingredient>> GetAll()
        {
            return await _ingredientRepository.GetAll();
        }

        public async Task<Ingredient> GetById(int id)
        {
            return await _ingredientRepository.GetById(id);
        }

        public async Task<bool> Remove(Ingredient ingredient)
        {
            var recipe = await _recipeService.SearchRecipeByIngredient(ingredient.NameIngredient);
            if (recipe.Any())
            {
                return false;
            }
            await _ingredientRepository.Remove(ingredient);
            return true;
        }

        public async Task<IEnumerable<Ingredient>> Search(string ingredientName)
        {
            return await _ingredientRepository.Search(i => i.NameIngredient.Contains(ingredientName));
        }

        public async Task<Ingredient> Update(Ingredient ingredient)
        {
            if (_ingredientRepository.Search(i => i.NameIngredient == ingredient.NameIngredient && i.Id != ingredient.Id).Result.Any())
            {
                return null;
            }
            await _ingredientRepository.Update(ingredient);
            return ingredient;
        }
    }
}
