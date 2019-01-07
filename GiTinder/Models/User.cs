using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GiTinder.Models
{
    public class User
    {
        
        [Key]
        [Required]
        [MinLength(1)]
        public string Username { get; set; }
        [Required]
        [JsonProperty("public_repos")]
        public int ReposCount { get; set; }
        [Required]
        public string UserToken { get; set; }

        public User(string username)
        {
            Username = username;
        }
    }
}
