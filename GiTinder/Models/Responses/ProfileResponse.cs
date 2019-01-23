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

        [JsonProperty("repos")]
        public string Repos { get; set; }

        [JsonProperty("languages")]
        public string Languages { get; set; }

        [JsonProperty("snippets")]
        public string Snippets { get; set; }

        public ProfileResponse(string userName, string uRl, string rePos)
        {
            Status = "ok";
            Username = userName;
            Url = uRl;
            Repos = rePos;
            Languages = "Java";
            Snippets = "https://github.com/adamgyulavari/gf-chatapp";
        }
    }
}
