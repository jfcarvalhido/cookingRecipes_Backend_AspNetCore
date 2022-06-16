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
    public class RecipeRepository : IRecipeRepository
    {
        private readonly AppDbContext Db;

        private readonly DbSet<Recipe> recipes;
        
        public RecipeRepository(AppDbContext db)
        {
            Db = db;
            recipes = Db.Set<Recipe>();
            
        }
        public async Task Add(Recipe recipe)
        {            
            recipes.Add(recipe);
            await SaveChanges();
        }
        public void Dispose()
        {
            Db?.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task<List<Recipe>> GetAll()
        {
            return await Db.Recipes.AsNoTracking()
                .Include(i => i.Ingredients)
                .Include(c => c.Categories)
                .OrderBy(r => r.Title)
                .ToListAsync();
        }
        public async Task<Recipe> GetById(int id)
        {
            return await Db.Recipes.AsNoTracking()
               .Include(r => r.Ingredients)
               .Include(r => r.Categories)
               .Where(r => r.Id == id)
               .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Recipe>> GetRecipeByCategory(string name)
        {
            return await Db.Recipes.AsNoTracking()
                .Include(r => r.Ingredients)
                .Include(r => r.Categories)                            
                .Where(r => r.Categories.Any(c => c.Name == name))
                .ToListAsync();
        }
        public async Task<IEnumerable<Recipe>> GetRecipeByName(string title)
        {
            return await Db.Recipes.AsNoTracking()
                .Include(r => r.Ingredients)
                .Include(r => r.Categories)
                .Where(r => r.Title.Contains(title))
                .ToListAsync();
        }
        public async Task Remove(Recipe recipe)
        {
            recipes.Remove(recipe);
            await SaveChanges();
        }
        public async Task SaveChanges()
        {
            await Db.SaveChangesAsync();
        }
        public async Task<IEnumerable<Recipe>> Search(Expression<Func<Recipe, bool>> predicate)
        {
            return await recipes.AsNoTracking().Where(predicate).ToListAsync();
        }
        public async Task<IEnumerable<Recipe>> SearchRecipeByIngredient(string nameIngredient)
        {
            return await Db.Recipes.AsNoTracking()                
                .Include(r => r.Categories)
                .Include(r => r.Ingredients)
                .Where(r => r.Ingredients.Any(i => i.NameIngredient == nameIngredient)) 
                .ToListAsync();
        }
        public async Task Update(Recipe recipe)
        {
            Recipe exist = recipes
                .Include(r => r.Categories)
                .Include(r => r.Ingredients)
                .Single(r => r.Id == recipe.Id);

            Db.Entry(exist).CurrentValues.SetValues(recipe);

            exist.Ingredients.Clear();
            foreach (var i in recipe.Ingredients) exist.Ingredients.Add(i);

            exist.Categories.Clear();
            foreach (var c in recipe.Categories) exist.Categories.Add(c);

            recipes.Update(exist);
            await SaveChanges();
        }
    }
}
