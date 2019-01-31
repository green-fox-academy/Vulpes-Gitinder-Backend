using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models.Connections
{
    public class UserLanguages
    {
        [Required]
        public string Username { get; set; }
        [JsonIgnore]
        public User User { get; set; }

        [Required]
        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public UserLanguages(string username, int languageId)
        {
            Username = username;
            LanguageId = languageId;
        }
    }
}
