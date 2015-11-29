using System;
using System.Collections.Generic;
using Data;
using DatabaseEntities.Entities;
using DataMockServices.Factories;
using DataRepositoriesInterfaces;
using DataServices;
using Newtonsoft.Json;

namespace DataMockServices.Services
{
    public class StatisticsMockService : BaseMockService<Match>, IStatisticsService
    {
        public StatisticsMockService()
            : base(null, null)
        {
        }

        public Match GetMatchByID(int id)
        {
            throw new NotImplementedException();
        }

        public MatchDto GetMatchStatistics(int id)
        {
            if (id < 1) throw new RankException("Bad id");
            return new MatchDto {Match = MatchFactory.GenerateMath(id), WaitingTime = 0 };
        }

        public HeroWinrateDto WinrateAgainstHero(int playerId, int enemyHeroID, bool refresh)
        {
            return new HeroWinrateDto {  Winrate = new WinrateItem() { PlayerId = playerId, EnemyHeroId = enemyHeroID, Winrate = 52.7m } };
        }

        public HeroWinrateDto WinrateAgainstHero(int playerId, int enemyHeroID, int fromMatch, bool refresh)
        {
            return new HeroWinrateDto { Winrate = new WinrateItem() { PlayerId = playerId, EnemyHeroId = enemyHeroID, MatchCount = fromMatch, Winrate = 49.2m} };
        }

        public HeroWinrateDto ChoosenWinrateAgainstHero(int playerId, int choosenHeroID, int enemyHeroID, bool refresh)
        {
            return new HeroWinrateDto { Winrate = new WinrateItem() { PlayerId = playerId, HeroId = choosenHeroID, Winrate = 48.0m} }; 
        }

        public HeroWinrateDto ChoosenWinrateAgainstHero(int playerId, int choosenHeroID, int enemyHeroID, int matchesCount, bool refresh)
        {
            return new HeroWinrateDto { Winrate = new WinrateItem() { PlayerId = playerId, HeroId = choosenHeroID, EnemyHeroId = enemyHeroID, MatchCount = matchesCount, Winrate = 53.86m} };
        }

        public PlayerRatingDto PlayerRating(int playerID, bool refresh)
        {
            return new PlayerRatingDto { Rating = new PlayerRating { MatchCount = 758, PlayerId = playerID, Rating = 4855 }, WaitingTime = 0 };
        }

        public PlayerRatingDto PlayerRating(int playerID, int matchCount, bool refresh)
        {
            return new PlayerRatingDto { Rating = new PlayerRating { MatchCount = matchCount, PlayerId = playerID, Rating = 4253 }, WaitingTime = 0}; ;
        }

        public HeoresInfoDto BestVs(int playerID, bool refresh)
        {
            return new HeoresInfoDto
            {
                Information = new Information
                {
                    PlayerId = playerID,
                    MatchCount = 500,
                    HeroesWinrates = new List<HeroWinrate>
            {
                new HeroWinrate(){HeroId = 53, Winrate = 59.7m},
                new HeroWinrate(){HeroId = 16, Winrate = 58.7m},
                new HeroWinrate(){HeroId = 18, Winrate = 55.7m},
                new HeroWinrate(){HeroId = 19, Winrate = 53.7m},
                new HeroWinrate(){HeroId = 20, Winrate = 51.1m},
}
                },
                WaitingTime = 0
            };
        }

        public HeoresInfoDto BestVs(int playerID, int matchCount, bool refresh)
        {
            return new HeoresInfoDto
            {
                Information = new Information
                {
                    PlayerId = playerID,
                    MatchCount = matchCount,
                    HeroesWinrates = new List<HeroWinrate>()
            {
                new HeroWinrate(){HeroId = 13, Winrate = 59.7m},
                new HeroWinrate(){HeroId = 35, Winrate = 58.7m},
                new HeroWinrate(){HeroId = 78, Winrate = 55.7m},
                new HeroWinrate(){HeroId = 37, Winrate = 53.7m},
                new HeroWinrate(){HeroId = 69, Winrate = 51.1m},
            }
                },
                WaitingTime = 0
            };
        }

        public HeoresInfoDto WorstVs(int playerID, bool refresh)
        {
            return new HeoresInfoDto
            {
                Information = new Information
                {
                PlayerId = playerID,
                MatchCount = 499,
                HeroesWinrates = new List<HeroWinrate>()
            {
                new HeroWinrate(){HeroId = 5, Winrate = 39.7m},
                new HeroWinrate(){HeroId = 6, Winrate = 43.7m},
                new HeroWinrate(){HeroId = 98, Winrate = 45.7m},
                new HeroWinrate(){HeroId = 89, Winrate = 46.7m},
                new HeroWinrate(){HeroId = 50, Winrate = 48.1m},
            }
                },
                WaitingTime = 0
            };
        }

        public HeoresInfoDto WorstVs(int playerID, int matchCount, bool refresh)
        {
            return new HeoresInfoDto
            {
                Information = new Information
                {
                PlayerId = playerID,
                
                MatchCount = matchCount,
                HeroesWinrates = new List<HeroWinrate>()
            {
                new HeroWinrate(){HeroId = 15, Winrate = 39.7m},
                new HeroWinrate(){HeroId = 25, Winrate = 43.7m},
                new HeroWinrate(){HeroId = 8, Winrate = 45.7m},
                new HeroWinrate(){HeroId = 17, Winrate = 46.7m},
                new HeroWinrate(){HeroId = 35, Winrate = 48.1m},
            }},WaitingTime = 0
            };
        }

    }
}
