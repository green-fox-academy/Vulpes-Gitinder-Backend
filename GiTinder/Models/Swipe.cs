using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class Swipe
    {
        [Required]
        [JsonProperty("swiping_user")]
        public User SwipingUser { get; set; }
        [Required]
        [JsonProperty("swiped_user")]
        public User SwipedUser { get; set; }
        [Required]
        [JsonProperty("direction")]
        public SwipeDirection Direction { get; set; }
        [Required]
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        public Swipe(User swipingUser, User swipedUser, SwipeDirection direction)
        {
            SwipingUser = swipingUser;
            SwipedUser = swipedUser;
            SwipeDirection Direction = direction;
            Timestamp = DateTime.Now;
        }
    }

    public enum SwipeDirection
    {
        [EnumMember(Value = "left")]
        Left,
        [EnumMember(Value = "right")]
        Right
    };
    
}
