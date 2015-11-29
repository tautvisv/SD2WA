using System.Collections.Generic;
using DatabaseEntities.Interfaces;

namespace DataRepositoriesInterfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity : class, IObject
    {
        TEntity GetById(int id);

        TEntity Add(TEntity entity);

        TEntity Delete(TEntity entity);

        void Update(TEntity entity);
        IEnumerable<TEntity> List { get; } 
    }
}
