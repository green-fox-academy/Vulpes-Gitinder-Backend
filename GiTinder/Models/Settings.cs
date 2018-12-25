using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiTinder.Models
{
    public class Settings
    {
        [Key, JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "username")]
        [Required]
        [MinLength(1)]
        [ForeignKey("User.UserName")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "enable_notifications")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enable notification information is required")]
        public bool EnableNotification { get; set; }

        [JsonProperty(PropertyName = "enable_background_sync")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enable background sync information is required")]
        public bool EnableBackgroundSync { get; set; }

        [JsonProperty(PropertyName = "max_distance")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Maximum distance information (in km) is required")]
        [Range(10, 160)]
        public int MaxDistanceInKm { get; set; }

        public Settings(string UserName, bool EnableNotification, bool EnableBackgroundSync,
    int MaxDistanceInKm)
        {
            this.UserName = UserName;
            this.EnableNotification = EnableNotification;
            this.EnableBackgroundSync = EnableBackgroundSync;
            this.MaxDistanceInKm = MaxDistanceInKm;
        }
    }
}










