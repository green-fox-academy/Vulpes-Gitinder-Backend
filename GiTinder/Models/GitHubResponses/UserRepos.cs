using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models.GitHubResponses
{
    public class UserRepos
    {
        [JsonProperty("html_url")]
        public string Url { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
    }
}
