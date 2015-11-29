using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace DatabaseEntities.Entities
{
    [DataContract]
    public class AbilityUpgrade : ObjectBase
    {
        [JsonProperty("ability")]
        [DataMember(Name = @"ability")]
        public int Ability { get; set; }
        [JsonProperty("time")]
        [DataMember(Name = @"time")]
        public int Time { get; set; }
        [JsonProperty("level")]
        [DataMember(Name = @"level")]
        public int Level { get; set; }
    }
}
