using GiTinder.Data;
using GiTinder.Models;
using Microsoft.EntityFrameworkCore;
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

        public bool TokenExists(string usertoken)
        {
            return _context.Users.Any(u => u.UserToken == usertoken);
        }

        public bool UserTokenCorrespondsToUsername(string username, string usertoken)
        {
            return _context.Users.Where(u => u.Username == username).Any(u => u.UserToken == usertoken);
        }

        public User FindUserByUserToken(string usertoken)
        {
            User foundUser = _context.Users.Where(u => u.UserToken == usertoken).FirstOrDefault();
            return foundUser;
        }

        public Settings FindSettingsWithLanguagesByUser(User user)
        {
            var foundSettings = _context.Settings.Include(e => e.SettingsLanguages).ThenInclude(l => l.Language).Where(s => s.Username == user.Username).FirstOrDefault();
            return foundSettings;
        }

        public Settings FindSettingsWithLanguagesByUserToken(string usertoken)
        {
            var foundUser = FindUserByUserToken(usertoken);
            var foundSettings = FindSettingsWithLanguagesByUser(foundUser);
            return foundSettings;
        }

        private bool UserExists(string username)
        {
            return _context.Users.Any(e => e.Username == username);
        }

        private bool SettingsExists(string username)
        {
            return _context.Settings.Any(s => s.Username == username);
        }

        public void UpdateAndSaveSettingsFoundByUserToken(Settings settings, string usertoken)
        {
            var foundSettings = FindSettingsWithLanguagesByUserToken(usertoken);
            UpdateSettings(foundSettings, settings, usertoken);
            _context.SaveChanges();
        }

        public void UpdateSettings(Settings oldsettings, Settings newsettings, string usertoken)
        {
            var foundUser = FindUserByUserToken(usertoken);
            oldsettings.Username = foundUser.Username;
            oldsettings.EnableNotification = newsettings.EnableNotification;
            oldsettings.EnableBackgroundSync = newsettings.EnableBackgroundSync;
            oldsettings.MaxDistanceInKm = newsettings.MaxDistanceInKm;
            _context.Settings.Update(oldsettings);
            UpdateSettingsLanguageList(newsettings, usertoken);
        }


        public void UpdateSettingsLanguageList(Settings settings, string usertoken)
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
                    AddSettingsLanguageItem(settingsId, languageId);
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
                    RemoveSettingsLanguageItem(settingsId, languageId);
                }
            }
        }

        public void AddSettingsLanguageItem(int settingsId, int languageId)
        {
            var settingsLanguageItem = new SettingsLanguage(settingsId, languageId);
            _context.Add(settingsLanguageItem);
        }

        public void RemoveSettingsLanguageItem(int settingsId, int languageId)
        {
            SettingsLanguage settingsLanguageItemForRemoval =
                _context.SettingsLanguage.Where(sl => sl.SettingsId == settingsId).Where(sl => sl.LanguageId == languageId).FirstOrDefault();
            _context.SettingsLanguage.Remove(settingsLanguageItemForRemoval);
        }
    }
}
