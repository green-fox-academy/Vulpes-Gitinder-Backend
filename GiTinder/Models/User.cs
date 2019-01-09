using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace GiTinder.Models
{
    public class User
    {
        public static Task Content { get; internal set; }
        public int Id { get; set; }
        [Key]
        [Required]
        [MinLength(1)]
        [JsonProperty("login")]
        public string UserName { get; set; }
        [JsonProperty("public_repos")]
        public int ReposCount { get; set; }
        [JsonIgnore]
        public string UserToken { get; set; }
        [JsonProperty("avatar_url")]
        public string Avatar { get; set; }
        public string Repos { get; set; }
    }
}
