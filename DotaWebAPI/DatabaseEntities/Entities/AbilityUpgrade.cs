using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DatabaseEntities.Entities
{
    public class AbilityUpgrade : ObjectBase
    {
        [JsonProperty("ability")]
        public int Ability { get; set; }
        [JsonProperty("time")]
        public int Time { get; set; }
        [JsonProperty("level")]
        public int Level { get; set; }
    }
}
