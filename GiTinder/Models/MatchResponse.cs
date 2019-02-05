using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
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
<<<<<<< HEAD
=======
            Status = "ok";
            message = message;
>>>>>>> 416c02d8e20dd114f49d1e4ab90507d1a4a4e8ab
            Username = username;
            AvatarUrl = avatar;
            Time = time;
        }
    }
}
