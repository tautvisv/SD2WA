using System.Collections.Generic;

namespace Data
{
    public class HeoresInfoDto : BaseDto
    {
        public Information Information { get; set; }
    }

    public class Information
    {
        public int MatchCount { get; set; }
        public int Hero { get; set; }
        public int HeroId { get; set; }
        public int PlayerId { get; set; }
        public IList<HeroWinrate> HeroesWinrates { get; set; }
    }
}
