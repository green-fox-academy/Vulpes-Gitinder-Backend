using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class MatchResponse
    {
        [JsonProperty]
        public string  Username { get; set; }
        [JsonProperty]
        public string AvatarUrl { get; set; }
        [JsonProperty]
        public int Time { get; set; }
        [JsonProperty]
        public List<string> Messages { get; set; }
        [JsonProperty]
        public List<Match> Matches { get; set; }

        public MatchResponse(string message,string username, string avatar, int time)
        {
            //Status = "ok";
            //Message = message;
            Username = username;
            AvatarUrl = avatar;
            Time = time;
        }
        public MatchResponse(List<Match> matches)
        {
            Matches = matches;
        }
    }
}
