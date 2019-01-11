using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiTinder.Models
{
    public class Settings
    {
        [Key]
        [JsonIgnore]
        public int SettingsId { get; set; }

        // [JsonProperty(PropertyName = "username")]
        [JsonIgnore]
        //[Required]
        [MinLength(1)]
        [ForeignKey("User.Username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "enable_notifications")]
        [Required(ErrorMessage = "Enable notification information is required")]
        public bool EnableNotification { get; set; }

        [JsonProperty(PropertyName = "enable_background_sync")]
        [Required(ErrorMessage = "Enable background sync information is required")]
        public bool EnableBackgroundSync { get; set; }

        [JsonProperty(PropertyName = "max_distance")]
        [Required(ErrorMessage = "Maximum distance information (from 10 to 160 km) is required")]
        [Range(10, 160, ErrorMessage = "The Distance should be between 10 and 160 kilometers")]
        public int MaxDistanceInKm { get; set; }

        [JsonIgnore]
        public List<SettingsLanguage> SettingsLanguages { get; set; }

        [JsonIgnore]
        [NotMapped]
        public List<Language> LanguagesList { get; set; }

        [JsonIgnore]
        [NotMapped]
        public List<Language> PreferredLanguagesList { get; set; }

        [JsonProperty("preferred_languages")]
        [NotMapped]
        public List<string> PreferredLanguagesNames { get; set; }

        public Settings(string Username, bool EnableNotification, bool EnableBackgroundSync, int MaxDistanceInKm)
        {
            this.Username = Username;
            this.EnableNotification = EnableNotification;
            this.EnableBackgroundSync = EnableBackgroundSync;
            this.MaxDistanceInKm = MaxDistanceInKm;
            PreferredLanguagesNames = new List<string>();
        }
    }
}
