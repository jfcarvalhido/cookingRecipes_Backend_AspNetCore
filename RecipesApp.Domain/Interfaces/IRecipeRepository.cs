using RecipesApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipesApp.Domain.Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<IEnumerable<Recipe>> GetRecipeByName(string title);
        Task<IEnumerable<Recipe>> SearchRecipeByIngredient(string nameIngredient);
        Task<IEnumerable<Recipe>> GetRecipeByCategory(string name);
    }
}
