using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DatabaseEntities.Entities
{
    public class InGamePlayer : ObjectBase
    {
        [JsonProperty("account_id")]
        public long AccountID { get; set; }
        [JsonProperty("player_slot")]
        public int Slot { get; set; }
        public virtual Hero Heroes { get; set; }
        [ForeignKey("Heroes")]
        [JsonProperty("hero_id")]
        public int HeroID { get; set; }
        [JsonProperty("item_0")]
        public int ItemID0 { get; set; }
        [JsonProperty("item_1")]
        public int ItemID1 { get; set; }
        [JsonProperty("item_2")]
        public int ItemID2 { get; set; }
        [JsonProperty("item_3")]
        public int ItemID3 { get; set; }
        [JsonProperty("item_4")]
        public int ItemID4 { get; set; }
        [JsonProperty("item_5")]
        public int ItemID5 { get; set; }
        [JsonProperty("kills")]
        public int Kills { get; set; }
        [JsonProperty("deaths")]
        public int Deaths { get; set; }
        [JsonProperty("assists")]
        public int Assists { get; set; }
        [JsonProperty("leaver_status")]
        public int LeaverStatus { get; set; }
        [JsonProperty("gold")]
        public int Gold{ get; set; }
        [JsonProperty("last_hits")]
        public int LastHits { get; set; }
        [JsonProperty("denies")]
        public int Denies { get; set; }
        [JsonProperty("gold_per_min")]
        public int GoldPerMin { get; set; }
        [JsonProperty("xp_per_min")]
        public int XpPerMin { get; set; }
        [JsonProperty("gold_spent")]
        public int GoldSpent { get; set; }
        [JsonProperty("hero_damage")]
        public int HeroDamage { get; set; }
        [JsonProperty("tower_damage")]
        public int TowerDamage { get; set; }
        [JsonProperty("hero_healing")]
        public int HeroHealing { get; set; }
        [JsonProperty("level")]
        public int Level { get; set; }
        [JsonProperty("ability_upgrades")]
        public virtual IList<AbilityUpgrade> AbilityUpgrades { get; set; }
    }

}
