using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepo
{
    public interface IUnitOfWork : IDisposable
    {
    //    IHeroRepository HeroRepository { get; }
    //    IPlayerRepository PlayerRepository { get; }
    //    IMatchRepository MatchRepository { get; }
        int Commit();
    }
}
