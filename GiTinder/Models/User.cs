<<<<<<< HEAD
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

=======
﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
>>>>>>> ba9123ab47868405d039c3851fbcfee816e84dc4

namespace GiTinder.Models
{
    public class User
    {
        public static Task Content { get; internal set; }
        public int Id { get; set; }
        [Key]
        [Required]
        [MinLength(1)]
<<<<<<< HEAD
        [JsonProperty("login")]
        public string UserName { get; set; }
=======
        public string Username { get; set; }
        [Required]
>>>>>>> ba9123ab47868405d039c3851fbcfee816e84dc4
        [JsonProperty("public_repos")]
        public int ReposCount { get; set; }
        [JsonIgnore]
        public string UserToken { get; set; }
<<<<<<< HEAD
        [JsonProperty("avatar_url")]
        public string Avatar { get; set; }
        public string Repos { get; set; }
=======

        public User(string username)
        {
            Username = username;
        }
>>>>>>> ba9123ab47868405d039c3851fbcfee816e84dc4
    }
}
