using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace DatabaseEntities.Entities
{
    public class Ability:ObjectBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [JsonProperty("id")]
        public override int ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
