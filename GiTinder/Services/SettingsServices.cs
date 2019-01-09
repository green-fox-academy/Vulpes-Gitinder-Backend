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

        public void addSettingsLanguageItem(int settingsId, int languageId)
        {
            var settingsLanguageItem = new SettingsLanguage(settingsId, languageId);
            _context.Add(settingsLanguageItem);
        }

        public void removeSettingsLanguageItem(int settingsId, int languageId)
        {
            SettingsLanguage settingsLanguageItemForRemoval =
                _context.SettingsLanguage.Where(sl => sl.SettingsId == settingsId).Where(sl => sl.LanguageId == languageId).FirstOrDefault();
            _context.SettingsLanguage.Remove(settingsLanguageItemForRemoval);
        }

        public void updateSettingsLanguageList(Settings settings, string usertoken)
        {
            List<string> passedLanguageNameList = settings.PreferredLanguagesNames;
            User foundUser = _context.Users.Where(e => e.UserToken == usertoken).FirstOrDefault();
            int settingsId = foundUser.UserSettings.SettingsId;
            Settings settingsFoundInDB = _context.Settings.Where(s => s.SettingsId == settingsId).FirstOrDefault();

            foreach (string languageName in passedLanguageNameList)
            {
                Language foundLanguage = _context.Languages.Where(l => l.LanguageName == languageName).FirstOrDefault();
                int languageId = foundLanguage.LanguageId;

                if (!_context.SettingsLanguage.Where(sl => sl.SettingsId == settingsId).Any(sl => sl.LanguageId == languageId))
                {
                    addSettingsLanguageItem(settingsId, languageId);
                }
            }

            List<string> preferredLanguagesNamesListInDB = _context.SettingsLanguage.Select(sl => sl.Language.LanguageName).ToList();

            foreach (string languageName in preferredLanguagesNamesListInDB)
            {
                Language foundLanguage = _context.Languages.Where(l => l.LanguageName == languageName).FirstOrDefault();
                int languageId = foundLanguage.LanguageId;

                if (_context.SettingsLanguage.Where(sl => sl.SettingsId == settingsId).Any(sl => sl.LanguageId == languageId) &&
                    !passedLanguageNameList.Contains(languageName))
                {
                    removeSettingsLanguageItem(settingsId, languageId);
                }
            }
        }

        ///The following method will probably be removed after each user will have its default settings upon user creation
        public void addSettingsLanguageList(Settings settings)
        {
            var languageNameList = settings.PreferredLanguagesNames;
            var settingsId = settings.SettingsId;

            foreach (string languageName in languageNameList)
            {
                var foundLanguage = _context.Languages.Where(l => l.LanguageName == languageName).FirstOrDefault();

                var languageId = foundLanguage.LanguageId;

                addSettingsLanguageItem(settingsId, languageId);
                
            }
        }
        ///
    }
}
