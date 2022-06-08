using Microsoft.EntityFrameworkCore;
using RecipesApp.DAL.Context;
using RecipesApp.Domain.Entities;
using RecipesApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecipesApp.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext Db;

        private readonly DbSet<Category> categories;

        public CategoryRepository(AppDbContext db)
        {
            Db = db;
            categories = Db.Set<Category>();
        }
        public async Task Add(Category category)
        {
            categories.Add(category);
            await SaveChanges();
        }
        public void Dispose()
        {
            Db?.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task<List<Category>> GetAll()
        {
            return await categories.ToListAsync();
        }
        public async Task<Category> GetById(int id)
        {
            return await categories.SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Category>> GetByName(string name)
        {
            return await Db.Categories
                .Where(c => c.Name.Equals(name))
                .ToListAsync();
        }

        public async Task Remove(Category category)
        {
            categories.Remove(category);
            await SaveChanges();
        }
        public async Task SaveChanges()
        {
            await Db.SaveChangesAsync();
        }
        public async Task<IEnumerable<Category>> Search(Expression<Func<Category, bool>> predicate)
        {
            return await categories.AsNoTracking().Where(predicate).ToListAsync();
        }
        public async Task Update(Category category)
        {
            categories.Update(category);
            await SaveChanges();
        }
    }
}
