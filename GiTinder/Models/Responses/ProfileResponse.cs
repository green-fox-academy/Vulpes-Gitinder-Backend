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
        public List<string> ReposList { get; set; }

        [JsonProperty("languages")]
        public List<string> UserLanguageNamesList { get; set; }

        [JsonProperty("snippets")]
        public List<string> Snippets { get; set; }

        public ProfileResponse(string username, string avatar, List<string> reposList)
        {
            Status = "ok";
            Username = username;
            Avatar = avatar;
            ReposList = reposList;
            UserLanguageNamesList = new List<string> { "Java" };
            Snippets = new List<string> { "https://github.com/adamgyulavari/gf-chatapp", "https://github.com/adamgyulavari/gf-chatapp" };
        }

        public ProfileResponse(User user)
        {
            Username = user.Username;
            Avatar = user.Avatar;
            ReposList = user.ReposList;
            UserLanguageNamesList = user.UserLanguageNamesList;
            Snippets = user.FiveRawCodeFilesUrls.Split(";").ToList();
        }
    }
}