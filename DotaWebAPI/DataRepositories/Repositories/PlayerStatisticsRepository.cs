using System.Collections.Generic;
using System.Linq;
using DatabaseEntities.Entities;
using DataRepo;

namespace DataRepositories.Repositories
{
    public class PlayerStatisticsRepository : GenericRepositoryBase<Player>, IPlayerRepository
    {
        public PlayerStatisticsRepository(Dota2DbContext dbContext)
            : base(dbContext)
        {
            
        }
        public IList<Player> List { get { return DBContext.Players.ToList(); } } 
    }
}
