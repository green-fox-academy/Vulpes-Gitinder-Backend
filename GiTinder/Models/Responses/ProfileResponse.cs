using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class ProfileResponse : GeneralApiResponseBody

    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("avatar_url")]
        public string Url { get; set; }

        public ProfileResponse(string userName, string uRl)
        {
            Status = "ok";
            Username = userName;
            Url = uRl;
          

        }
    }
}
