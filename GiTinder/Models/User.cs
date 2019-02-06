using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using GiTinder.Models.GitHubResponses;
using System.ComponentModel.DataAnnotations.Schema;
using GiTinder.Models.Connections;
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
        [JsonProperty("user_token")]
        public string UserToken { get; set; }
        [JsonProperty("avatar_url")]
        public string Avatar { get; set; }
        public string Repos { get; set; }
        [NotMapped]
        public List<string> RawCodeFilesUrls { get; set; }
        [JsonProperty("raw_code_urls")]
        public string FiveRawCodeFilesUrls { get; set; }

        [JsonIgnore]
        public List<UserLanguages> UserLanguages { get; set; }

        public Settings UserSettings { get; set; }

        [NotMapped]
        public List<string> ReposList
        {
            get
            {
                return SplitReposToList(Repos);
            }
        }

        [NotMapped]
        public List<string> UserLanguageNamesList
        {
            get
            {
                return UserLanguages
                    .Select(ul => ul.Language.LanguageName)
                    .ToList();
            }
        }

        public User(string username)
        {
            Username = username;
            UserSettings = new Settings(Username);
        }

        public User()
        {
        }

        public static List<string> SplitReposToList(string repos)
        {
            if (repos == null)
            {
                return new List<string>();
            }
            char[] charsToTrim = { ' ', '\'', '\"' };
            return repos.Split(';').Select(p => p.Trim(charsToTrim)).ToList();
        }
    }
}
