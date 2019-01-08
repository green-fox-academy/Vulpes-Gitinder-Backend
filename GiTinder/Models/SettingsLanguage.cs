using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class SettingsLanguage
    {
        public int SettingsId { get; set; }
        [JsonIgnore]
        public Settings Settings { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}

