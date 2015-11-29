using System.Collections.Generic;
using Data;
using DatabaseEntities.Entities;

namespace DataRepositoriesInterfaces
{
    public interface ISteamRepository:IGenericOnliePository
    {
        Match GetMatchById(int id);
        MinimizedMatchDtoContainer GetMatches(int? playerID = null, int? matchID = null, int? heroID = null, int? matchCount = null);
    }
}
