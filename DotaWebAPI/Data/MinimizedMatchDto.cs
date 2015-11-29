using System.Collections.Generic;
using Newtonsoft.Json;

namespace Data
{
    public class MinimizedMatchDtoContainer
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
    }

    public class MinimizedMatchDto
    {
        [JsonProperty("match_id")]
        public int MatchID { get; set; }
        [JsonProperty("match_seq_num")]
        public int MatchSeqNum { get; set; }
        [JsonProperty("start_time")]
        public int StartTime { get; set; }
        [JsonProperty("lobby_type")]
        public int LobbyType { get; set; }
        [JsonProperty("radiant_team_id")]
        public int RadiantTeamID { get; set; }
        [JsonProperty("dire_team_id")]
        public int DireTeamID { get; set; }
    }
    public class Result
    {
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("num_results")]
        public int NumResults { get; set; }
        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
        [JsonProperty("results_remaining")]
        public int ResultsRemaining { get; set; }
        [JsonProperty("matches")]
        public ICollection<MinimizedMatchDto> Matches { get; set; }
    }

}
