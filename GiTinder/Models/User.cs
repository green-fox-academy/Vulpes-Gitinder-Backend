<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
﻿using Newtonsoft.Json;
=======
using Newtonsoft.Json;
using System.Collections.Generic;
>>>>>>> d7161859c4d022f04d6196325c1681daf70d60ac
using System.ComponentModel.DataAnnotations;


namespace GiTinder.Models
{ 
    public class User
    {
<<<<<<< HEAD
        public static Task Content { get; internal set; }
        public int Id { get; set; }
=======
>>>>>>> d7161859c4d022f04d6196325c1681daf70d60ac
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
            Settings defaultSettings = new Settings(Username, true, true, 10);
        }
    }
}
