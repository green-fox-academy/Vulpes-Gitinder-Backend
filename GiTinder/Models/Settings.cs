using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiTinder.Models
{
    public class Settings
    {
        // [JsonIgnore]
        [Key]
        public int Id { get; set; }

        //this error appeared 
        //You have an error in your SQL syntax; check the manual that corresponds to your 
        //MySQL server version for the right syntax 
        //to use near 'CONSTRAINT `FK_Settings_Users_UserName`' at line 1
        //(AllowEmptyStrings = false, ErrorMessage = "User name is required")
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

        [NotMapped]
        [JsonProperty(PropertyName = "preferred_languages")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Information on preferred languages is required")]
        public List<Language> PreferredLanguages { get; set; }

        public Settings(string UserName, bool EnableNotification, bool EnableBackgroundSync,
            int MaxDistanceInKm, List<Language> PreferredLanguages)
        {
            this.UserName = UserName;
            this.EnableNotification = EnableNotification;
            this.EnableBackgroundSync = EnableBackgroundSync;
            this.MaxDistanceInKm = MaxDistanceInKm;
            this.PreferredLanguages = PreferredLanguages;
        }
    }
}



//enable_notifications	boolean
//enable_background_sync boolean
//max_distance integer
//preferred_languages[string]









