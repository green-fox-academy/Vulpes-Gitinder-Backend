using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GiTinder.Models
{   [JsonObject]
    public class Swipe : GeneralApiResponseBody
    {
        [Required]
        public string SwipingUserId { get; set; }
        [Required]
        public string SwipedUserId { get; set; }
        [Required]
        public string Direction { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }

        public Swipe()
        {
            this.Timestamp = DateTime.Now;
        }
        public Swipe(string SwipingUserId, string SwipedUserId,string Direction)
        {
            this.SwipingUserId = SwipingUserId;
            this.SwipedUserId = SwipedUserId;
            this.Direction = Direction;
            this.Timestamp = DateTime.Now;
        }
    }   
}
