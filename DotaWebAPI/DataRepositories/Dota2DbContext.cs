using System.Data.Entity;
using DatabaseEntities;
using DatabaseEntities.Entities;

namespace DataRepositories
{
    public class Dota2DbContext : DbContext
    {
        public Dota2DbContext(string name)
            : base(name)
        {
            this.Configuration.LazyLoadingEnabled = false;
            //HeroRepository = new HeroesRepository(this);
            //PlayerRepository = new PlayerStatisticsRepository(this);
            //MatchRepository = new MatchRepository(this);
        }
        public Dota2DbContext()
            : this(@"name=DotaConnectionString")
        {
        }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<InGamePlayer> InGamePlayers { get; set; }
        public DbSet<AbilityUpgrade> AbilityUpgrades { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Task> Tasks { get; set; } 

        //public IHeroRepository HeroRepository { get; private set; }
        //public IPlayerRepository PlayerRepository { get; private set; }
        //public IMatchRepository MatchRepository { get; private set; }
        public int Commit()
        {
            return this.SaveChanges();
        }
    }
}
