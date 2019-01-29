using GiTinder.Models.GitHubResponses;
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
        public string Avatar { get; set; }

        [JsonProperty("repos")]
        public string Repos { get; set; }

        [JsonProperty("languages")]
        public List<string> Languages { get; set; }

        [JsonProperty("snippets")]
        public List<string> Snippets { get; set; }

        public ProfileResponse(string username, string avatar, string repos)
        {
            Status = "ok";
            Username = username;
            Avatar = avatar;
            Repos = repos;
            Languages = new List<string> { "Java" };
            Snippets = new List<string> { "https://github.com/adamgyulavari/gf-chatapp", "https://github.com/adamgyulavari/gf-chatapp" };
        }

        public ProfileResponse(string username, string avatar, string repos, string languages)
        {
            Username = username;
            Avatar = avatar;
            Repos = repos;
            Languages = new List<string> { };
        }

    }
  
    
}