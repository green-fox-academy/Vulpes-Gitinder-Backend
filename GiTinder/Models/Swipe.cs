using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class Swipe
    {
        [Key]
        [JsonIgnore]
        public int SwipeId { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("swiped_user_id")]
        public string SwipedUserId { get; set; }
        [JsonProperty("direction")]
        public SwipeDirection Direction { get; set; }
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        public Swipe(string userId, string swipedUserId, SwipeDirection direction)
        {
            UserId = userId;
            SwipedUserId = swipedUserId;
            SwipeDirection Direction = direction;
            Timestamp = DateTime.Now.ToString();
        }
    }
    public enum SwipeDirection { Left, Right };
    
}
