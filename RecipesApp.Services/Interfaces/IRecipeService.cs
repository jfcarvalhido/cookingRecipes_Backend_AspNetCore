using RecipesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesApp.Services.Interfaces
{
    public interface IRecipeService : IDisposable
    {
        Task<IEnumerable<Recipe>> GetAll();
        Task<Recipe> GetById(int id);
        Task<Recipe> Add(Recipe recipe);
        Task<Recipe> Update(Recipe recipe);
        Task<bool> Remove(Recipe recipe);
        Task<IEnumerable<Recipe>> GetRecipesByName(string title);
        Task<IEnumerable<Recipe>> SearchRecipeByIngredient(string nameIngredient);
        Task<IEnumerable<Recipe>> SearchRecipeByCategory(string name);
    }
}
