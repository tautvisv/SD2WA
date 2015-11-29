using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseEntities.Entities;

namespace Data
{
    public class HeroWinrate
    {
        public Hero Hero { get; set; }
        public int HeroId { get; set; }
        public decimal Winrate { get; set; }
    }
}
