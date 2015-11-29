using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseEntities.Entities;

namespace DataServices
{
    public interface IMiscService
    {
        IEnumerable<Hero> GetAllHeroes();
        IEnumerable<Item> GetAllItems();
        Hero GetHero(int id);
    }
}
