using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GiTinder.Models
{
    public class Language
    {
        public Language()
        {

        }

        public Language(string language)
        {
            LanguageName = language;
        }

        [Key]
        public int LanguageId { get; set; }

        [JsonProperty(PropertyName = "language")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Language information is required")]
        public string LanguageName { get; set; }

        [JsonIgnore]
        public List<SettingsLanguage> SettingsLanguages { get; set; }

    }
}
