using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class Message
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }
        [Required]
        [JsonProperty("from")]
        public string From { get; set; }
        [Required]
        [JsonProperty("to")]
        public string To { get; set; }
        [Required]
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [Required]
        [JsonProperty("message")]
        public string Content { get; set; }
    }
}
