using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseEntities.Entities;
using DatabaseEntities.Interfaces;
using DataRepo;

namespace DataServices
{
    public abstract class BaseService<T> : IEntityService<T> where T : ObjectBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _repository;

        public BaseService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }


        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Add(entity);
            _unitOfWork.Commit();
        }


        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Update(entity);
            _unitOfWork.Commit();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public virtual IList<T> GetAll()
        {
            return _repository.List;
            //return _repository.GetAll();
        }
    }
}
