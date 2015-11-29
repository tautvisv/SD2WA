using System.Collections.Generic;
using Data;
using DatabaseEntities.Entities;

namespace DataServices
{
    public interface IBridgeDotaCalculation
    {
        Match GetMatchStatistics(Match match);
        WinrateItem GetWinrate(IEnumerable<Match> matches);
        PlayerRating GetPlayerRating(IEnumerable<Match> matches);
        Information GetBestAgainst(IEnumerable<Match> matches);
        Information GetWorstAgainst(IEnumerable<Match> matches);
    }
}
