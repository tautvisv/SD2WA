using DatabaseEntities.Entities;
using Newtonsoft.Json;

namespace Data
{
    public class SteamResponseMatche
    {
        [JsonProperty("result")]
        public Match Result { get; set; }
    }
}
