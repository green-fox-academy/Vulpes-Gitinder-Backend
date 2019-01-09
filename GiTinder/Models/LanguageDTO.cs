using GiTinder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class LanguageDTO
    {
        private GiTinderContext _context;

        public LanguageDTO(GiTinderContext context)
        {
            _context = context;
        }

        public LanguageDTO(Settings settings)
        {
            // Language languageForDTO = new Language();

            var languageNameList = settings.PreferredLanguagesNames;

            foreach (string languageName in languageNameList)
            {
                //saveSettingsLanguageList(settings, languageName);
            }
        }

        //public void saveSettingsLanguageList(Settings settings, string languageName)
        //{
        //    var foundLanguage = _context.Languages.Where(l => l.LanguageName == languageName).FirstOrDefault();
        //    var settingsId = settings.SettingsId;
        //    var languageId = foundLanguage.LanguageId;

        //    SettingsLanguage settingsLanguageItem = new SettingsLanguage();
        //    settingsLanguageItem.SettingsId = settingsId;
        //    settingsLanguageItem.LanguageId = languageId;
        //    _context.Add(settingsLanguageItem);
        //    _context.SaveChanges();
        //}
    }
}
