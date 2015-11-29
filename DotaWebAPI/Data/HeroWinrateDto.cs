using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseEntities.Entities;

namespace Data
{
    public class HeroWinrateDto:BaseDto
    {
        public WinrateItem Winrate { get; set; }
    }

    public class WinrateItem
    {
        public int PlayerId { get; set; }
        public Hero MyHero { get; set; }
        public int? HeroId { get; set; }
        public Hero EnemyHero { get; set; }
        public int? EnemyHeroId { get; set; }
        public int? MatchCount { get; set; }
        public decimal? Winrate { get; set; }
    }
}
