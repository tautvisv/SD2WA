using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace DatabaseEntities.Entities
{
    [DataContract]
    public class Match : ObjectBase
    {
        public Match()
        {
            Players = new List<InGamePlayer>();
        }
        [JsonProperty("match_id")]
        [DataMember(Name = @"match_id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int ID { get; set; }
        [JsonProperty("players")]
        [DataMember(Name = @"players")]
        public virtual ICollection<InGamePlayer> Players { get; set; }
        [JsonProperty("radiant_win")]
        [DataMember(Name = @"radiant_win")]
        public bool RadiantWin { get; set; }
        [JsonProperty("duration")]
        [DataMember(Name = @"duration")]
        public int Duration { get; set; }
        [JsonProperty("start_time")]
        [DataMember(Name = @"start_time")]
        public int StartTime { get; set; }
        [JsonProperty("match_seq_num")]
        [DataMember(Name = @"match_seq_num")]
        public int MatchSeqNum { get; set; }
        [JsonProperty("tower_status_radiant")]
        [DataMember(Name = @"tower_status_radiant")]
        public int TowerStatusRadiant { get; set; }
        [JsonProperty("tower_status_dire")]
        [DataMember(Name = @"tower_status_dire")]
        public int TowerStatusDire { get; set; }
        [JsonProperty("barracks_status_radiant")]
        [DataMember(Name = @"barracks_status_radiant")]
        public int BarracksStatusRadiant { get; set; }
        [JsonProperty("barracks_status_dire")]
        [DataMember(Name = @"barracks_status_dire")]
        public int BarracksStatusDire { get; set; }
        [JsonProperty("cluster")]
        [DataMember(Name = @"cluster")]
        public int Cluster { get; set; }
        [JsonProperty("first_blood_time")]
        [DataMember(Name = @"first_blood_time")]
        public int FirstBloodTime { get; set; }
        [JsonProperty("lobby_type")]
        [DataMember(Name = @"lobby_type")]
        public int LobbyType { get; set; }
        [JsonProperty("human_players")]
        [DataMember(Name = @"human_players")]
        public int HumanPlayers { get; set; }
        [JsonProperty("leagueid")]
        [DataMember(Name = @"leagueid")]
        public int LeagueID { get; set; }
        [JsonProperty("positive_votes")]
        [DataMember(Name = @"positive_votes")]
        public int PositiveVotes { get; set; }
        [JsonProperty("negative_votes")]
        [DataMember(Name = @"negative_votes")]
        public int NegativeVotes { get; set; }
        [JsonProperty("game_mode")]
        [DataMember(Name = @"game_mode")]
        public int GameMode { get; set; }
        [JsonProperty("engine")]
        [DataMember(Name = @"engine")]
        public int Engine { get; set; }
    }
}
