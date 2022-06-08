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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRecipeService _recipeService;

        public CategoryService(ICategoryRepository categoryRepository, IRecipeService recipeService)
        {
            _categoryRepository = categoryRepository;
            _recipeService = recipeService;
        }
        public async Task<Category> Add(Category category)
        {
            if (_categoryRepository.Search(c => c.Name == category.Name).Result.Any())
            {
                return null;
            }
            await _categoryRepository.Add(category);
            return category;
        }

        public void Dispose()
        {
            _categoryRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }
        public async Task<Category> GetById(int id)
        {
            return await _categoryRepository.GetById(id);
        }

        public async Task<bool> Remove(Category category)
        {
            var recipe = await _recipeService.SearchRecipeByCategory(category.Name);
            if (recipe.Any())
            {
                return false;
            }
            await _categoryRepository.Remove(category);
            return true;
        }

        public async Task<IEnumerable<Category>> Search(string name)
        {
            return await _categoryRepository.Search(c => c.Name.Contains(name));
        }

        public async Task<Category> Update(Category category)
        {
            if (_categoryRepository.Search(c => c.Name == category.Name && c.Id != category.Id).Result.Any())
            {
                return null;
            }
            await _categoryRepository.Update(category);
            return category;
        }
    }
}
