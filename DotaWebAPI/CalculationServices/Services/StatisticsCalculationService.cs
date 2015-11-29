using System.Collections.Generic;
using CalculationServicesInterfaces;
using Data;
using DatabaseEntities.Entities;

namespace CalculationServices.Services
{
    public class StatisticsCalculationService : IStatisticsCalculationService
    {
        public StatisticsCalculationService()
        {
            
        }
        public Match CalculateStatistics(Match match)
        {
            //TODO some math
            return match;
        }

        public WinrateItem CalculateWinrate(ICollection<Match> matches)
        {
            return new WinrateItem { Winrate = 59.8m, MatchCount = matches.Count};
        }

        public PlayerRating CalculateRating(ICollection<Match> matches, int playerId)
        {
            return new PlayerRating { Rating = 4595, MatchCount = matches.Count, PlayerId = playerId };
        }

        public Information CalculateBestAgainst(ICollection<Match> matches)
        {
            return new Information { PlayerId = 1000, MatchCount = matches.Count };
        }

        public Information CalculateWorstAgainst(ICollection<Match> matches)
        {
            return new Information { PlayerId = 2000, MatchCount = matches.Count };
        }
    }
}
