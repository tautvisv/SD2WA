using System;
using System.Collections.Generic;
using DatabaseEntities.Entities;
using DataRepositoriesInterfaces;
using DataServices;

namespace DataMockServices
{
    public abstract class BaseMockService<T> : IEntityService<T> where T : ObjectBase
    {
        public BaseMockService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
        }

        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
        }


        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
        }

        public virtual IEnumerable<T> GetAll()
        {
            return null;
        }
    }
}
