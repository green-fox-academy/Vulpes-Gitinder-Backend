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
        public string Username_1 { get; set; }
        [Required]
        [MinLength(1)]
        [ForeignKey("User.Username")]
        public string Username_2 { get; set; }

        [Required]
        [JsonProperty("matched_at")]
        public DateTime Timestamp { get; set; }
                       
        public Match(string username_1, string username_2)
        {
            Username_1 = username_1;
            Username_2 = username_2;
            this.Timestamp = DateTime.Now;
        }
    }
}
