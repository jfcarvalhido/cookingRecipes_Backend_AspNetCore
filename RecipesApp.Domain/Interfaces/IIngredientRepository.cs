using RecipesApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipesApp.Domain.Interfaces
{
    public interface IIngredientRepository : IRepository<Ingredient>
    {
        Task<IEnumerable<Ingredient>> GetByName(string nameIngredient);
    }
}
