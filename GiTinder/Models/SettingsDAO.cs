using GiTinder.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace GiTinder.Models
{
    public class SettingsDAO
    {
        [JsonIgnore]
        public Settings settingsForDAO;
        
        [JsonProperty("enable_notifications")]
        public bool EnableNotification { get; set; }

        [JsonProperty("enable_background_sync")]
        public bool EnableBackgroundSync { get; set; }

        [JsonProperty("max_distance")]
        public int MaxDistanceInKm { get; set; }

        [JsonProperty("preferred_languages")]
        public List<string> PreferredLanguagesNames { get; set; }

        public SettingsDAO(Settings settings)
        {
            settingsForDAO = settings;
            EnableNotification = settingsForDAO.EnableNotification;
            EnableBackgroundSync = settingsForDAO.EnableBackgroundSync;
            MaxDistanceInKm = settingsForDAO.MaxDistanceInKm;

            List<string> preferredLanguagesNames = new List<string>();
            preferredLanguagesNames = settings.SettingsLanguages.Select(sl => sl.Language.LanguageName).ToList();
            PreferredLanguagesNames = preferredLanguagesNames;
        }
    }
}

//{
//  "enable_notifications": true,
//  "enable_background_sync": true,
//  "max_distance": 0,
//  "preferred_languages": [
//    "string"
//  ]
//}