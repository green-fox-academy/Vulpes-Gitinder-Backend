using GiTinder.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace GiTinder.Models
{
    public class SettingsDAO
    {

        public Settings settingsForDAO;

        [JsonProperty("preferred_languages")]
        public List<string> PreferredLanguagesNames { get; set; }

        public SettingsDAO(Settings settings)
        {
            settingsForDAO = settings;

           // var settingsId = settings.SettingsId;
            
            List<string> preferredLanguagesNames = new List<string>();

            // var foundSettings = _context.Settings.Include(e => e.SettingsLanguages).ThenInclude(l => l.Language).Where(s => s.UserName == foundUser.UserName).FirstOrDefault();

            //        var result = context.Begrip
            //.Include(x => x.Categories)
            //.ThenInclude(x => x.category);

            preferredLanguagesNames = settings.SettingsLanguages.Select(sl => sl.Language.LanguageName).ToList();

            PreferredLanguagesNames = preferredLanguagesNames;

            //  List<string> firstNames = people.Select(person => person.FirstName).ToList();

            //List<object> objects = new List<object>();
            //List<string> strings = objects.Select(s => (string)s).ToList();

            //.Where(sl => sl.SettingsId == settings.SettingsId)


            //            .SelectMany(p => p.PersonClubs);

            //        .Where(p => p.PersonId == id)
            //        .SelectMany(p => p.PersonClubs);
            //.Select(pc => pc.Club);

            //        var sllist  = settings.SettingsLanguages.Where(sl => sl.SettingsId == settings.SettingsId);
            //            var landIdlist =
            //        preferredLanguagesNames 
            // Select(s => s.Language).LanguageName.ToList();

            //preferredLanguagesNames = settings.SettingsLanguages
            //    //.Where(s => s.Settings == settings)
            //    //.Include(e => e.SettingsLanguages)
            //    //.Include(l => l.Language)
            //   .Select(s => s.settingsId)
            //    .ToList();

            //preferredLanguagesNames = settings.PreferredLanguagesList.Select(lang => lang.LanguageName).ToList();


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