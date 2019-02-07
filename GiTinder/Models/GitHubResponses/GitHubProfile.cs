using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models.GitHubResponses
{
    public class GitHubProfile
    {
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("public_repos")]
        public int ReposCount { get; set; }
        [JsonProperty("user_token")]
        public string UserToken { get; set; }
        [JsonProperty("avatar_url")]
        public string Avatar { get; set; }
    }
}
