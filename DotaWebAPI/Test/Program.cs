using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseEntities.Entities;
using DataRepo;
using DataRepositories;
using DataRepositories.Repositories;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new Dota2DbContext();
            var hero = new HeroesRepository(dbContext);
            hero.Add(new Hero {Name = "Vardenis", SystemName = "vardenis_pavardenis"});
            Console.WriteLine("GREAT success!");
            Console.ReadKey();
        }
    }
}
