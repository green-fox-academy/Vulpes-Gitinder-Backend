<<<<<<< HEAD
﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
=======
﻿using System.ComponentModel.DataAnnotations;
>>>>>>> b8a52ca500712c4e2ec5919c74bb702fa02b19ef

namespace GiTinder.Models
{
    public class User
    {
<<<<<<< HEAD
        public static Task Content { get; internal set; }
        public int Id { get; set; }
        [JsonProperty("login")]
        public string UserName { get; set; }
        [JsonProperty("public_repos")]
        public int ReposCount { get; set; }
        [JsonIgnore]
        public string UserToken { get; set; }
        [JsonProperty("avatar_url")]
        public string Avatar { get; set; }
        public string Repos { get; set; }
        //public List<string> Languages { get; set; }
        //public List<string> Snippets { get; set; }
    }
}
=======
        
        [Key]
        [Required]
        [MinLength(1)]
        public string UserName { get; set; }
        public int ReposCount { get; set; }
        [Required]
        public string UserToken { get; set; }
    }
}
>>>>>>> b8a52ca500712c4e2ec5919c74bb702fa02b19ef
