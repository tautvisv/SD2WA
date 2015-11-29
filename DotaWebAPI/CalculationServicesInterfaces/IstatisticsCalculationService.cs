using System.Collections.Generic;
using Data;
using DatabaseEntities.Entities;

namespace CalculationServicesInterfaces
{

    public interface IStatisticsCalculationService
    {
        Match CalculateStatistics(Match match);
        WinrateItem CalculateWinrate(ICollection<Match> matches);
        PlayerRating CalculateRating(ICollection<Match> matches, int playerId);
        Information CalculateBestAgainst(ICollection<Match> matches);
        Information CalculateWorstAgainst(ICollection<Match> matches);
    }
}
