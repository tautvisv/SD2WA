using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace DatabaseEntities.Entities
{
    [DataContract]
    public class InGamePlayer : ObjectBase
    {
        [JsonProperty("account_id")]
        [DataMember(Name = @"account_id")]
        public long AccountID { get; set; }
        [JsonProperty("player_slot")]
        [DataMember(Name = @"player_slot")]
        public int Slot { get; set; }
        [JsonProperty("hero_id")]
        [DataMember(Name = @"hero_id")]
        public int HeroID { get; set; }
        [JsonIgnore]
        [ForeignKey("HeroID")]
        public virtual Hero Hero { get; set; }
        [JsonProperty("item_0")]
        [DataMember(Name = @"item_0")]
        public int ItemID0 { get; set; }
        [JsonProperty("item_1")]
        [DataMember(Name = @"item_1")]
        public int ItemID1 { get; set; }
        [JsonProperty("item_2")]
        [DataMember(Name = @"item_2")]
        public int ItemID2 { get; set; }
        [JsonProperty("item_3")]
        [DataMember(Name = @"item_3")]
        public int ItemID3 { get; set; }
        [JsonProperty("item_4")]
        [DataMember(Name = @"item_4")]
        public int ItemID4 { get; set; }
        [JsonProperty("item_5")]
        [DataMember(Name = @"item_5")]
        public int ItemID5 { get; set; }
        [JsonProperty("kills")]
        [DataMember(Name = @"kills")]
        public int Kills { get; set; }
        [JsonProperty("deaths")]
        [DataMember(Name = @"deaths")]
        public int Deaths { get; set; }
        [JsonProperty("assists")]
        [DataMember(Name = @"assists")]
        public int Assists { get; set; }
        [JsonProperty("leaver_status")]
        [DataMember(Name = @"leaver_status")]
        public int LeaverStatus { get; set; }
        [JsonProperty("gold")]
        [DataMember(Name = @"gold")]
        public int Gold { get; set; }
        [JsonProperty("last_hits")]
        [DataMember(Name = @"last_hits")]
        public int LastHits { get; set; }
        [JsonProperty("denies")]
        [DataMember(Name = @"denies")]
        public int Denies { get; set; }
        [JsonProperty("gold_per_min")]
        [DataMember(Name = @"gold_per_min")]
        public int GoldPerMin { get; set; }
        [JsonProperty("xp_per_min")]
        [DataMember(Name = @"xp_per_min")]
        public int XpPerMin { get; set; }
        [JsonProperty("gold_spent")]
        [DataMember(Name = @"gold_spent")]
        public int GoldSpent { get; set; }
        [JsonProperty("hero_damage")]
        [DataMember(Name = @"hero_damage")]
        public int HeroDamage { get; set; }
        [JsonProperty("tower_damage")]
        [DataMember(Name = @"tower_damage")]
        public int TowerDamage { get; set; }
        [JsonProperty("hero_healing")]
        [DataMember(Name = @"hero_healing")]
        public int HeroHealing { get; set; }
        [JsonProperty("level")]
        [DataMember(Name = @"level")]
        public int Level { get; set; }
        [JsonIgnore]
        public int MatchID { get; set; }
        [JsonIgnore]
        [ForeignKey("MatchID")]
        public virtual Match Match { get; set; }
        [JsonProperty("ability_upgrades")]
        [DataMember(Name = @"ability_upgrades")]
        public virtual ICollection<AbilityUpgrade> AbilityUpgrades { get; set; }
    }

}
