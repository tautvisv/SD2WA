using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseEntities.Entities;
using DataRepo;

namespace DataServices.Services
{
    public class HeroesService:BaseService<Hero>, IHeroesService
    {
        public HeroesService(IUnitOfWork unitOfWork, IGenericRepository<Hero> repository) : base(unitOfWork, repository)
        {
        }
    }
}
