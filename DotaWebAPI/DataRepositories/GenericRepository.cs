using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DatabaseEntities.Interfaces;
using DataRepositories;

namespace DataRepo
{

    public abstract class GenericRepositoryBase<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IObject
    {
        protected readonly DbSet<TEntity> DBSet;
        protected readonly Dota2DbContext DBContext;

        protected GenericRepositoryBase(Dota2DbContext dbContext)
        {
            DBContext = dbContext;
            DBSet = dbContext.Set<TEntity>();
        }

        public virtual TEntity GetById(int id)
        {
            return DBSet.SingleOrDefault(entity => entity.ID == id);
        }

        public virtual TEntity Add(TEntity entity)
        {
            var newEntity = DBSet.Add(entity);

            return newEntity;
        }
        public virtual IQueryable<TEntity> AsQueryable()
        {
            return DBSet.AsQueryable();
        }

        public virtual TEntity Delete(TEntity entity)
        {
            var deletedEntity = DBSet.Remove(entity);

            return deletedEntity;
        }

        public virtual IList<TEntity> List
        {
            get
            {
                return DBSet.ToList();
            }
        }

        public virtual void Update(TEntity entity)
        {
            DBSet.Attach(entity);
            DBContext.Entry(entity).State = EntityState.Modified;
            //_dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}

