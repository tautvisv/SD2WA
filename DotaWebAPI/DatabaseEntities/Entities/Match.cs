using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DatabaseEntities.Interfaces;
using Newtonsoft.Json;

namespace DatabaseEntities.Entities
{
    public class Match : ObjectBase
    {
        [Key]
        [JsonProperty("match_id")]
        public new int ID { get; set; }
        [JsonProperty("players")]
        public IList<InGamePlayer> Players { get; set; }
        [JsonProperty("radiant_win")]
        public bool RadiantWin { get; set; }
        [JsonProperty("duration")]
        public int Duration { get; set; }
        [JsonProperty("start_time")]
        public int StartTime { get; set; }
        [JsonProperty("match_seq_num")]
        public int MatchSeqNum { get; set; }
        [JsonProperty("tower_status_radiant")]
        public int TowerStatusRadiant { get; set; }
        [JsonProperty("tower_status_dire")]
        public int TowerStatusDire { get; set; }
        [JsonProperty("barracks_status_radiant")]
        public int BarracksStatusRadiant { get; set; }
        [JsonProperty("barracks_status_dire")]
        public int BarracksStatusDire { get; set; }
        [JsonProperty("cluster")]
        public int Cluster { get; set; }
        [JsonProperty("first_blood_time")]
        public int FirstBloodTime { get; set; }
        [JsonProperty("lobby_type")]
        public int LobbyType { get; set; }
        [JsonProperty("human_players")]
        public int HumanPlayers { get; set; }
        [JsonProperty("leagueid")]
        public int LeagueID { get; set; }
        [JsonProperty("positive_votes")]
        public int PositiveVotes { get; set; }
        [JsonProperty("negative_votes")]
        public int NegativeVotes { get; set; }
        [JsonProperty("game_mode")]
        public int GameMode { get; set; }
        [JsonProperty("engine")]
        public int Engine { get; set; }
    }
}
