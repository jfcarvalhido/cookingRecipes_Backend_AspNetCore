using Microsoft.EntityFrameworkCore;
using RecipesApp.DAL.Context;
using RecipesApp.Domain.Entities;
using RecipesApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RecipesApp.DAL.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly AppDbContext Db;

        private readonly DbSet<Ingredient> ingredients;

        public IngredientRepository(AppDbContext db)
        {
            Db = db;
            ingredients = Db.Set<Ingredient>();
        }
        public async Task Add(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
            await SaveChanges();
        }
        public void Dispose()
        {
            Db?.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task<List<Ingredient>> GetAll()
        {
            return await ingredients.ToListAsync();
        }
        public async Task<Ingredient> GetById(int id)
        {
            return await ingredients.SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Ingredient>> GetByName(string nameIngredient)
        {
            return await Db.Ingredients
                .Where(i => i.NameIngredient.Equals(nameIngredient))
                .ToListAsync();
        }

        public async Task Remove(Ingredient ingredient)
        {
            ingredients.Remove(ingredient);
            await SaveChanges();
        }
        public async Task SaveChanges()
        {
            await Db.SaveChangesAsync();
        }
        public async Task<IEnumerable<Ingredient>> Search(Expression<Func<Ingredient, bool>> predicate)
        {
            return await ingredients.AsNoTracking().Where(predicate).ToListAsync();
        }
        public async Task Update(Ingredient ingredient)
        {
            ingredients.Update(ingredient);
            await SaveChanges();
        }
    }
}
