using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models.Responses
{
    public class OneMatchResponse : GeneralApiResponseBody
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
        [JsonProperty("matched_at")]
        public DateTime Timestamp { get; set; }
        [JsonProperty("messages")]
        public List<string> Messages { get; set; }

        public OneMatchResponse(string username, string avatar, DateTime timeStamp)
        {
            Username = username;
            AvatarUrl = avatar;
            Timestamp = timeStamp;
            Messages = new List<string>();
        }
    }
}
