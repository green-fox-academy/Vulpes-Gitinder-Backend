using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class User
    {
        public static Task Content { get; internal set; }
        public int Id { get; set; }
        [JsonProperty("login")]
        public string UserName { get; set; }
        [JsonIgnore]
        public int ReposCount { get; set; }
        [JsonIgnore]
        public string UserToken { get; set; }
        [JsonProperty("avatar_url")]
        public string Avatar { get; set; }
        public string Repos { get; set; }
        public List<string> Languages { get; set; }
        public List<string> Snippets { get; set; }
    }
}