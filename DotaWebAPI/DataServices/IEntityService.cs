using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{

    public interface IEntityService<T> : IService
    {
        void Create(T entity);
        void Delete(T entity);
        IList<T> GetAll();
        void Update(T entity);
    }
}
