using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseEntities.Entities;

namespace Data
{
    public class WinrateDto:BaseDto
    {
        public int HeroID { get; set; }
        public Hero Hero { get; set; }
        public decimal Winrate { get; set; }
        public int MatchCount { get; set; }
    }
}
