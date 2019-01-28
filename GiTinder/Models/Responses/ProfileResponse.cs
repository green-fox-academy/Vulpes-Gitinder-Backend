using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [JsonProperty("languages")]
        public string Languages { get; set; }

        [JsonProperty("snippets")]
        public string Snippets { get; set; }

        [JsonProperty("repos")]
        public string Repos { get; set; }
     
        

        public ProfileResponse(string username, string url, string repos)
        {
            Status = "ok";
            Username = username;
            Url = url;
            Repos = repos;
            Languages = "Java";
            Snippets = "https://github.com/adamgyulavari/gf-chatapp";
        }
    }
}

