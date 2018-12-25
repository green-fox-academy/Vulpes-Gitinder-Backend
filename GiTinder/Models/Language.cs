using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }

        [JsonProperty(PropertyName = "language")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Language information is required")]
        public string LanguageName { get; set; }

        public List<SettingsLanguage> SettingsLanguages { get; set; }

        public Language(string LanguageName)
        {
            this.LanguageName = LanguageName;
        }
    }
}
