using RecipesApp.Domain.Entities;
using RecipesApp.Domain.Interfaces;
using RecipesApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesApp.Services.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _repository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly ICategoryRepository _categoryRepository;

        public RecipeService(IRecipeRepository repository, IIngredientRepository ingredientRepository, ICategoryRepository categoryRepository)
        {
            _repository = repository;
            _ingredientRepository = ingredientRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Recipe> Add(Recipe recipe)
        {
            //Não repetir receitas
            if (_repository.Search(r => r.Title == recipe.Title).Result.Any())
            {
                return null;
            }

            //Não repetir ingredientes
            var fixed_ingredients = new List<Ingredient>();

            foreach (var ingredient in recipe.Ingredients)
            {
                var existing = (await _ingredientRepository.GetByName(ingredient.NameIngredient)).FirstOrDefault();
                if (existing != null)
                {
                    fixed_ingredients.Add(existing);
                }
                else fixed_ingredients.Add(ingredient);
            }
            recipe.Ingredients = fixed_ingredients;

            //Não repetir categorias
            var fixed_categories = new List<Category>();

            foreach (var category in recipe.Categories)
            {
                var existing = (await _categoryRepository.GetByName(category.Name)).FirstOrDefault();
                if (existing != null)
                {
                    fixed_categories.Add(existing);
                }
                else fixed_categories.Add(category);
            }
            recipe.Categories = fixed_categories;


            await _repository.Add(recipe);
            return recipe;
        }
        public void Dispose()
        {
            _repository?.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task<IEnumerable<Recipe>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<Recipe> GetById(int id)
        {
            return await _repository.GetById(id);
        }
        public async Task<IEnumerable<Recipe>> GetRecipesByName(string title)
        {
            return await _repository.GetRecipeByName(title);
        }
        public async Task<bool> Remove(Recipe recipe)
        {
            await _repository.Remove(recipe);
            return true;
        }
        public async Task<IEnumerable<Recipe>> SearchRecipeByCategory(string name)
        {
            return await _repository.GetRecipeByCategory(name);
        }
        public async Task<IEnumerable<Recipe>> SearchRecipeByIngredient(string nameIngredient)
        {
            return await _repository.SearchRecipeByIngredient(nameIngredient);
        }
        public async Task<Recipe> Update(Recipe recipe)
        {
            if (_repository.Search(r => r.Title == recipe.Title && r.Id != recipe.Id).Result.Any())
            {
                return null;
            }

            //Não repetir ingredientes
            var fixed_ingredients = new List<Ingredient>();

            foreach (var ingredient in recipe.Ingredients)
            {
                var existing = (await _ingredientRepository.GetByName(ingredient.NameIngredient)).FirstOrDefault();
                if (existing != null)
                {
                    fixed_ingredients.Add(existing);
                }
                else fixed_ingredients.Add(ingredient);
            }
            recipe.Ingredients = fixed_ingredients;

            //Não repetir categorias
            var fixed_categories = new List<Category>();

            foreach (var category in recipe.Categories)
            {
                var existing = (await _categoryRepository.GetByName(category.Name)).FirstOrDefault();
                if (existing != null)
                {
                    fixed_categories.Add(existing);
                }
                else fixed_categories.Add(category);
            }
            recipe.Categories = fixed_categories;

            await _repository.Update(recipe);
            return recipe;
        }
    }
}
