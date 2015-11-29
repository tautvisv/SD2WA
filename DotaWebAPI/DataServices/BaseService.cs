using System;
using System.Collections.Generic;
using DatabaseEntities.Entities;
using DataRepositoriesInterfaces;

namespace DataServices
{
    public abstract class BaseService<T> : IEntityService<T> where T : ObjectBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IGenericRepository<T> _repository;

        public BaseService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        //public virtual void Create(T entity)
        //{
        //    if (entity == null)
        //    {
        //        throw new ArgumentNullException("entity");
        //    }
        //    _repository.Add(entity);
        //    _unitOfWork.Commit();
        //}


        //public virtual void Update(T entity)
        //{
        //    if (entity == null) throw new ArgumentNullException("entity");
        //    _repository.Update(entity);
        //    _unitOfWork.Commit();
        //}

        //public virtual void Delete(T entity)
        //{
        //    if (entity == null) throw new ArgumentNullException("entity");
        //    _repository.Delete(entity);
        //    _unitOfWork.Commit();
        //}

        //public virtual IEnumerable<T> GetAll()
        //{
        //    return _repository.List;
        //    //return _repository.GetAll();
        //}
    }
}
