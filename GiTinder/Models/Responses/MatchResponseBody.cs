using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models.Responses
{
    public class MatchResponseBody
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("matched_at")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("messages")]
        public List<string> Messages { get; set; }

        public MatchResponseBody()
        {
        }

        public MatchResponseBody(Match match)
        {
            Username = match.Username_1;
            ///This AvatarUrl assignment needs to be changed. Either using Tomek`s middleware method GetCurrentUser() 
            ///or by introducing User1 and User2 properties in Match model 
            AvatarUrl = "";
            Timestamp = match.Timestamp;
        }

        public MatchResponseBody(string username, string avatar, DateTime timestamp)
        {
            Username = username;
            AvatarUrl = avatar;
            Timestamp = timestamp;
        }
    }
}
