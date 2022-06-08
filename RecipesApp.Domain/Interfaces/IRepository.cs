using RecipesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RecipesApp.Domain.Interfaces
{
    //The class that will implement this interface, also need to implement the interface IDisposible for release memory
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        // adding a new entity
        Task Add(TEntity entity);

        //get all records for the entity
        Task<List<TEntity>> GetAll();

        //get an entity by it’s Id
        Task<TEntity> GetById(int id);

        //update an entity
        Task Update(TEntity entity);

        //delete an entity
        Task Remove(TEntity entity);

        //searching an entity passing a lambda expression to search any entity with any parameter
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);

        //save the changes of the entity
        Task SaveChanges();
    }
}
