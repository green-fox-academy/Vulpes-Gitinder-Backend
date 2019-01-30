using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using GiTinder.Models.GitHubResponses;
using System.ComponentModel.DataAnnotations.Schema;

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
        [JsonIgnore]
        public string UserToken { get; set; }
        [JsonProperty("avatar_url")]
        public string Avatar { get; set; }
        public string Repos { get; set; }

        [NotMapped]
        public List<string> ReposList
        {
            get
            {
                return SplitReposToList(Repos);
            }
        }


        [JsonIgnore]
        public List<UserLanguages> UserLanguage { get; set; }


        [NotMapped]
        public List<string> UserLanguageNamesList
        {
            get
            {
                return SplitReposToList(Repos);
            }
        }

        public Settings UserSettings { get; set; }

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

        public static List<string> SplitReposToList(string repos)
        {
            return repos.Split(';').ToList();
        }
    }
}
