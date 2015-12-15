using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public WinrateItem CalculateWinrate(ICollection<Match> matches, int playerId, int? enemyPlayerId)
        {
            var wonMatches = 0;
            var total = matches.Count;
            var player = matches.FirstOrDefault().Players.Where(x => x.AccountID == playerId).First();
            foreach (var match in matches)
            {
                var thisPlayer = match.Players.First(x => x.AccountID == playerId);
                if (enemyPlayerId != null)
                {
                    var enemy = match.Players.First(x => x.HeroID == enemyPlayerId);
                    if (Math.Abs(enemy.Slot - thisPlayer.Slot) < 20)
                    {
                        total--;
                        continue;
                    }
                }
                if (thisPlayer.Slot < 120 == match.RadiantWin) wonMatches++;
            }
            return new WinrateItem { Winrate = (decimal)(wonMatches * 100) / (decimal)total, MatchCount = matches.Count, HeroId = player.HeroID, EnemyHeroId = enemyPlayerId, PlayerId = playerId };
        }

        public PlayerRating CalculateRating(ICollection<Match> matches, int playerId)
        {
            var rating = 0m;
            foreach (var match in matches)
            {
                var thisPlayer = match.Players.First(player => player.AccountID.Equals(playerId));
                var deaths = thisPlayer.Deaths > 0 ? thisPlayer.Deaths : 1;
                var bonus = (decimal)(thisPlayer.Kills + thisPlayer.Assists) / (decimal)(deaths*2.5m);
                if (bonus > 4)
                {
                    bonus = 5;
                }
                else if (bonus < 0.25m)
                {
                    bonus = 0.2m;
                }
                var points = thisPlayer.Slot < 120 == match.RadiantWin ? 25*bonus : -25/bonus;
                rating += points;
                //match.RadiantWin
            }
            return new PlayerRating { Rating = decimal.ToInt32(rating), MatchCount = matches.Count, PlayerId = playerId };
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
