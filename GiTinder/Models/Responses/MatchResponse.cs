using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models.Responses
{
    public class MatchResponse : OKResponseBody
    {
        [JsonProperty]
        public string  Username { get; set; }
        [JsonProperty]
        public string AvatarUrl { get; set; }
        [JsonProperty]
        public int Time { get; set; }
        [JsonProperty]
        public List<string> Messages { get; set; }

        public MatchResponse(string message,string username, string avatar, int time) : base(message)
        {
            Username = username;
            AvatarUrl = avatar;
            Time = time;
        }
    }
}
