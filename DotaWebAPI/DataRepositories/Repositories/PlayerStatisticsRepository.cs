using DatabaseEntities.Entities;
using DataRepo;
using DataRepositoriesInterfaces;

namespace DataRepositories.Repositories
{
    public class PlayerStatisticsRepository : GenericRepositoryBase<Player>, IPlayerRepository
    {
        public PlayerStatisticsRepository(Dota2DbContext dbContext)
            : base(dbContext)
        {
            
        }
    }
}
