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
    }
}
