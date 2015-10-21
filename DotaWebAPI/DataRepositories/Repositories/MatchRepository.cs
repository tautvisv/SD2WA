using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseEntities.Entities;
using DataRepo;

namespace DataRepositories.Repositories
{
    public class MatchRepository : GenericRepositoryBase<Match>, IMatchRepository
    {
        public MatchRepository(Dota2DbContext context) : base(context)
        {
            
        }
    }
}
