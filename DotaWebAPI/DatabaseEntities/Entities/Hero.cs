using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace DatabaseEntities.Entities
{
    public class Hero : ObjectBase
    {
        [JsonProperty("id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int ID { get; set; }
        [JsonProperty("localized_name")]
        public string Name { get; set; }
        [JsonProperty("name")]
        public string SystemName { get; set; }
    }
}
