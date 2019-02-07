using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class Match
    {
        [Required]
        [MinLength(1)]
        [ForeignKey("User.Username")]
        public string Username1 { get; set; }
        [Required]
        [MinLength(1)]
        [ForeignKey("User.Username")]
        public string Username2 { get; set; }

        [Required]
        [JsonProperty("matched_at")]
        public DateTime Timestamp { get; set; }

        public Match(string username1, string username2)
        {
            Username1 = username1;
            Username2 = username2;
            Timestamp = DateTime.Now;
        }
    }
}
