using System.Collections.Generic;
using System.Linq;
using DatabaseEntities.Entities;
using DataRepo;

namespace DataRepositories.Repositories
{
    public class HeroesRepository:  GenericRepositoryBase<Hero>, IHeroRepository
    {
        public HeroesRepository(Dota2DbContext dbContext)
            : base(dbContext)
        {
            
        }

    }
}
