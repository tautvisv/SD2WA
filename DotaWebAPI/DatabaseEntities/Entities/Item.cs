using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace DatabaseEntities.Entities
{
    public class Item : ObjectBase
    {
        [JsonProperty("id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("cost")]
        public int Cost { get; set; }
        [JsonProperty("secret_shop")]
        public int SecretShop { get; set; }
        [JsonProperty("side_shop")]
        public int SideShop { get; set; }
        [JsonProperty("recipe")]
        public int Recipe { get; set; }
        [JsonProperty("localized_name")]
        public string LocalizedName { get; set; }
    }
}
