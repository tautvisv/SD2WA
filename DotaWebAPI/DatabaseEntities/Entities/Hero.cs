using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatabaseEntities.Interfaces;
using Newtonsoft.Json;

namespace DatabaseEntities.Entities
{
    //TODO DELETE method migrations
    public class Hero : ObjectBase
    {
        [JsonProperty("localized_name")]
        public string Name { get; set; }
        [JsonProperty("name")]
        public string SystemName { get; set; }
    }
}
