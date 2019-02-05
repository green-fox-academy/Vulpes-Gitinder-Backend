using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using GiTinder.Models.Connections;
using GiTinder.Models.GitHubResponses;

namespace GiTinder.Models
{
    public class User
    {
        [Key]
        [Required]
        [MinLength(1)]
        [JsonProperty("login")]
        public string Username { get; set; }
        [JsonProperty("public_repos")]
        public int ReposCount { get; set; }
        [JsonProperty("user_token")]
        public string UserToken { get; set; }
        [JsonProperty("avatar_url")]
        public string Avatar { get; set; }
        public string Repos { get; set; }

        public Settings UserSettings { get; set; }

        [JsonIgnore]
        public List<UserLanguages> UserLanguages { get; set; }

        public User()
        {
        }

        public User(string username)
        {
            Username = username;
        }

        public User(string Username, string UserToken, int ReposCount)
        {
            this.Username = Username;
            this.UserToken = UserToken;
            this.ReposCount = ReposCount;
            Settings defaultSettings = new Settings(Username);
        }
        public void setUserRepos(List<UserRepos> repos)
        {
            string urls = null;
            for (int i = 0; i < repos.Count; i++)
            {
                urls = repos[i].Url + ";" + urls;
            }
        }
    }
}
