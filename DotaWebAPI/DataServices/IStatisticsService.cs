using System.Collections.Generic;
using Data;
using DatabaseEntities.Entities;

namespace DataServices
{
    public interface IStatisticsService:IEntityService<Match>
    {
        MatchDto GetMatchStatistics(int id);
        HeroWinrateDto WinrateAgainstHero(int playerId, int enemyHeroID, bool refresh);
        HeroWinrateDto WinrateAgainstHero(int playerId, int enemyHeroID, int matchCount, bool refresh);
        HeroWinrateDto ChoosenWinrateAgainstHero(int playerId, int choosenHeroID, int enemyHeroID, bool refresh);
        HeroWinrateDto ChoosenWinrateAgainstHero(int playerId, int choosenHeroID, int enemyHeroID, int matchesCount, bool refresh);
        PlayerRatingDto PlayerRating(int playerID, bool refresh);
        PlayerRatingDto PlayerRating(int playerID, int matchCount, bool refresh);
        HeoresInfoDto BestVs(int playerID, bool refresh);
        HeoresInfoDto BestVs(int playerID, int matchCount, bool refresh);
        HeoresInfoDto WorstVs(int playerID, bool refresh);
        HeoresInfoDto WorstVs(int playerID, int matchCount, bool refresh);
    }
}
