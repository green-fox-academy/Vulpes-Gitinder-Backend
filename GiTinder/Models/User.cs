using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class User
    {
        [JsonIgnore]
        public int id;
        [JsonProperty(PropertyName ="login")]
        public string userName;
        [JsonIgnore]
        public string userToken;
        [JsonProperty(PropertyName = "public_repos")]
        public int reposCount;
        [JsonProperty(PropertyName = "avatar_url")]
        public string avatar;

        public static Task Content { get; internal set; }
        public int Id { get => id; set => id = value; }
        public string UserName { get => userName; set => userName = value; }
        public int ReposCount { get => reposCount; set => reposCount = value; }
        public string UserToken { get => userToken; set => userToken = value; }
        public string Avatar{ get => avatar; set => avatar = value; }
        public string reposUrl { get; set; }
    }
}