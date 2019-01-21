using GiTinder.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace GiTinder.Models
{
    public class SettingsResponse : GeneralApiResponseBody
    {
        [JsonIgnore]
        public Settings settingsForSettingsResponse;

        [JsonIgnore]
        public string Username { get; set; }

        [JsonProperty("enable_notifications")]
        public bool EnableNotification { get; set; }

        [JsonProperty("enable_background_sync")]
        public bool EnableBackgroundSync { get; set; }

        [JsonProperty("max_distance")]
        public int MaxDistanceInKm { get; set; }

        [JsonProperty("preferred_languages")]
        public List<string> PreferredLanguagesNames { get; set; }

        public SettingsResponse(Settings settings)
        {
            settingsForSettingsResponse = settings;
            EnableNotification = settingsForSettingsResponse.EnableNotification;
            EnableBackgroundSync = settingsForSettingsResponse.EnableBackgroundSync;
            MaxDistanceInKm = settingsForSettingsResponse.MaxDistanceInKm;

            List<string> preferredLanguagesNames = new List<string>();
            preferredLanguagesNames = settings.SettingsLanguages.Select(sl => sl.Language.LanguageName).ToList();
            PreferredLanguagesNames = preferredLanguagesNames;
        }
    }
}
