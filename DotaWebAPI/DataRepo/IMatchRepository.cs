using System.Collections.Generic;
using DatabaseEntities.Entities;

namespace DataRepositoriesInterfaces
{
    public interface IMatchRepository : IGenericRepository<Match>
    {
        Match GetByWebApiId(int id);
        void AddWithChilds(Match match);

        ICollection<Match> FilteredList(int playerID, int enemyHeroID);
        ICollection<Match> FilteredList(int playerId, int enemyHeroID, int matchCount);
        ICollection<Match> FilteredListByHero(int playerId, int choosenHeroID, int enemyHeroID);
        ICollection<Match> FilteredList(int playerID);
        ICollection<Match> FilteredListByHero(int playerId, int choosenHeroID, int enemyHeroID, int matchesCount);
    }
}
