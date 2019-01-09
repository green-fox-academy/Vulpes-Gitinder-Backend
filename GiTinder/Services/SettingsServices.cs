using GiTinder.Data;
using GiTinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Services
{
    public class SettingsServices
    {
        private GiTinderContext _context;

        public SettingsServices(GiTinderContext context)
        {
            _context = context;
        }
               
        public void addSettingsLanguageList(Settings settings)
        {
            var languageNameList = settings.PreferredLanguagesNames;
            var settingsId = settings.SettingsId;

            foreach (string languageName in languageNameList)
            {
                var foundLanguage = _context.Languages.Where(l => l.LanguageName == languageName).FirstOrDefault();

                var languageId = foundLanguage.LanguageId;

                var settingsLanguageItem = new SettingsLanguage(settingsId, languageId);
                _context.Add(settingsLanguageItem);
                _context.SaveChanges();
            }
        }

        public void updateSettingsLanguageList(Settings settings)
        {
            var languageNameList = settings.PreferredLanguagesNames;
            var settingsId = settings.SettingsId;

            foreach (string languageName in languageNameList)
            {
                var foundLanguage = _context.Languages.Where(l => l.LanguageName == languageName).FirstOrDefault();

                var languageId = foundLanguage.LanguageId;

                var settingsLanguageItem = new SettingsLanguage(settingsId, languageId);
                _context.Add(settingsLanguageItem);
                _context.SaveChanges();
            }
        }

    }
}
