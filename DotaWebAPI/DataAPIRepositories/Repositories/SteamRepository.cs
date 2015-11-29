using System.Collections.Generic;
using Data;
using DatabaseEntities.Entities;
using DataRepositoriesInterfaces;
using Newtonsoft.Json;
using RestSharp;

namespace DataAPIRepositories.Repositories
{
    public class SteamRepository : ISteamRepository
    {
        public Match GetMatchById(int id)
        {
            var client = new RestClient(Globals.DotaSteamAPI);
            var request = new RestRequest(Globals.DotaSteamAPIDotaInterfarce + "GetMatchDetails/" + Globals.DotaSteamAPIWeb1 + "?key={raktas}&match_id={match_id}", Method.GET);
            request.AddUrlSegment("raktas", Globals.DotaAPIKey);
            request.AddUrlSegment("match_id", id.ToString());
            var response = client.Execute(request);
            var info = JsonConvert.DeserializeObject<SteamResponseMatche>(response.Content);
            return info.Result;
        }

        public MinimizedMatchDtoContainer GetMatches(int? playerID = null, int? matchID = null, int? heroID = null, int? matchCount = null)
        {
            var client = new RestClient(Globals.DotaSteamAPI);
            var request = new RestRequest(Globals.DotaSteamAPIDotaInterfarce + "GetMatchHistory/" + Globals.DotaSteamAPIWeb1 + "?key={raktas}&account_id={player_id}&matches_requested={match_count}&start_at_match_id={match_id}&hero_id={hero_id}", Method.GET);
            request.AddUrlSegment("raktas", Globals.DotaAPIKey);
            if (playerID != null)
            {
                request.AddUrlSegment("player_id", playerID.ToString());
            }
            if (matchID != null)
            {
                request.AddUrlSegment("match_id", matchID.ToString());
            }
            if (heroID != null)
            {
                request.AddUrlSegment("hero_id", heroID.ToString());
            }
            if (matchCount != null)
            {
                request.AddUrlSegment("match_count", matchCount.ToString());
            }
            var response = client.Execute(request);
            var data = JsonConvert.DeserializeObject<MinimizedMatchDtoContainer>(response.Content);

            return data;
        }

    }
}
