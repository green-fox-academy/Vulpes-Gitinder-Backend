using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class MatchResponseBody : OKResponseBody
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
        [JsonProperty("matched_at")]
        public DateTime Timestamp { get; set; }
        [JsonIgnore]
        public List<string> Messages { get; set; }

        public MatchResponseBody(string message, string username, string avatar) : base(message)
        {
            Username = username;
            Message = message;
            AvatarUrl = avatar;
            Timestamp = DateTime.Now;
        }
    }
}
