using DatabaseEntities.Entities;
using DataRepo;
using DataRepositoriesInterfaces;

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
