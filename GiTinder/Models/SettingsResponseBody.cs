using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class SettingsResponseBody
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "enable_notifications")]
        public bool EnableNotification { get; set; }

        [JsonProperty(PropertyName = "enable_background_sync")]
        public bool EnableBackgroundSync { get; set; }

        [JsonProperty(PropertyName = "max_distance")]
        public int MaxDistanceInKm { get; set; }

        [JsonProperty("preferred_languages")]
        public List<string> PreferredLanguages { get; set; }

    }
}
