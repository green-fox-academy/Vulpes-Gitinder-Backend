using GiTinder.Models.GitHubResponses;
using GiTinder.Services;
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
<<<<<<< HEAD
        public List<string> Repos { get; set; }

        [JsonProperty("languages")]
        public List<string> Languages { get; set; }
=======
        public List<string> ReposList { get; set; }

        [JsonProperty("languages")]
        public List<string> UserLanguageNamesList { get; set; }
>>>>>>> 416c02d8e20dd114f49d1e4ab90507d1a4a4e8ab

        [JsonProperty("snippets")]
        public List<string> Snippets { get; set; }

        public ProfileResponse(string username, string avatar, string repos)
        {
<<<<<<< HEAD
            Status = "ok";
            Username = username;
            Avatar = avatar;
            Repos = UserServices.SplitReposToList(repos);
            Languages = new List<string> { "Java" };
=======
        }

        public ProfileResponse(string username, string avatar, List<string> reposList)
        {
            Status = "ok";
            Username = username;
            Avatar = avatar;
            ReposList = reposList;
            UserLanguageNamesList = new List<string> { "Java" };
>>>>>>> 416c02d8e20dd114f49d1e4ab90507d1a4a4e8ab
            Snippets = new List<string> { "https://github.com/adamgyulavari/gf-chatapp", "https://github.com/adamgyulavari/gf-chatapp" };
        }

        public ProfileResponse(string username, string avatar, List<string> reposList, List<string> userLanguageNamesList)
        {
            Username = username;
            Avatar = avatar;
<<<<<<< HEAD
            Repos = UserServices.SplitReposToList(repos);
            Languages = new List<string> { };
=======
            ReposList = reposList;
            UserLanguageNamesList = userLanguageNamesList;
        }

        public ProfileResponse(User user)
        {
            Username = user.Username;
            Avatar = user.Avatar;
            ReposList = user.ReposList;
            UserLanguageNamesList = user.UserLanguageNamesList;
>>>>>>> 416c02d8e20dd114f49d1e4ab90507d1a4a4e8ab
        }

    }
  
    
}