using RecipesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesApp.Services.Interfaces
{
    public interface IIngredientService : IDisposable
    {
        Task<IEnumerable<Ingredient>> GetAll();
        Task<Ingredient> GetById(int id);
        Task<Ingredient> Add(Ingredient ingredient);
        Task<Ingredient> Update(Ingredient ingredient);
        Task<bool> Remove(Ingredient ingredient);
        Task<IEnumerable<Ingredient>> Search(string ingredientName);
    }
}
