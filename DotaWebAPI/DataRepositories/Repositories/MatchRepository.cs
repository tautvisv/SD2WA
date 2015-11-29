using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DatabaseEntities.Entities;
using DataRepo;
using DataRepositoriesInterfaces;

namespace DataRepositories.Repositories
{
    public class MatchRepository : GenericRepositoryBase<Match>, IMatchRepository
    {
        public MatchRepository(Dota2DbContext context) : base(context)
        {
        }


        public Match GetByWebApiId(int id)
        {
           // return DBSet.Include(x => x.Players).Include(x => x.Players.Select(p => p.AbilityUpgrades)).Where(match => match.ID == id).FirstOrDefault();
            return DBSet.Include(x => x.Players).Include(x => x.Players.Select(p => p.AbilityUpgrades)).FirstOrDefault(match => match.ID == id);
        }

        public void AddWithChilds(Match match)
        {
            DBSet.AddOrUpdate(match);
        }

        public ICollection<Match> FilteredList(int playerID, int enemyHeroID)
        {
            var query = from matches in DBContext.Matches
                        where matches.Players.Any(player => player.AccountID == playerID)
                        select matches;
            query = query.Where(x => x.Players.Any(player => player.HeroID == enemyHeroID && player.AccountID != playerID));
            return query.Include(x => x.Players).Include(x => x.Players.Select(p => p.AbilityUpgrades)).ToList();
        }

        public ICollection<Match> FilteredList(int playerID, int enemyHeroID, int matchCount)
        {
            var query = from matches in DBContext.Matches
                        where matches.Players.Any(player => player.AccountID == playerID)
                        select matches;
            query = query.Where(x => x.Players.Any(player => player.HeroID == enemyHeroID && player.AccountID != playerID));
            return query.Include(x => x.Players).Include(x => x.Players.Select(p => p.AbilityUpgrades)).Take(matchCount).ToList();
        }

        public ICollection<Match> FilteredListByHero(int playerID, int choosenHeroID, int enemyHeroID)
        {
            var query = from matches in DBContext.Matches
                        where matches.Players.Any(player => player.AccountID == playerID)
                        select matches;
            query = query.Where(x => x.Players.Any(player => (player.HeroID == choosenHeroID && player.AccountID == playerID) || (player.AccountID != playerID && player.HeroID == enemyHeroID)));
            return query.Include(x => x.Players).Include(x => x.Players.Select(p => p.AbilityUpgrades)).ToList();
        }
        public ICollection<Match> FilteredListByHero(int playerID, int choosenHeroID, int enemyHeroID, int matchesCount)
        {
            var query = from matches in DBContext.Matches
                        where matches.Players.Any(player => player.AccountID == playerID)
                        select matches;
            query = query.Where(x => x.Players.Any(player => (player.HeroID == choosenHeroID && player.AccountID == playerID) || (player.AccountID != playerID && player.HeroID == enemyHeroID)));
            return query.Include(x => x.Players).Include(x => x.Players.Select(p => p.AbilityUpgrades)).Take(matchesCount).ToList();
        }
        public ICollection<Match> FilteredList(int playerID)
        {
            var query = from matches in DBContext.Matches
                        where matches.Players.Any(player => player.AccountID == playerID)
                        select matches;
            return query.Include(x => x.Players).Include(x => x.Players.Select(p => p.AbilityUpgrades)).ToList();
        }

    }
}
