using RecipesApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipesApp.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetByName(string name);
    }
}
