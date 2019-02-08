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
        private UserServices _userServices;
        private LanguageServices _languageServices;

        public SettingsServices(GiTinderContext context, UserServices userServices, LanguageServices languageServices)
        {
            _context = context;
            _userServices = userServices;
            _languageServices = languageServices;
        }

        public Settings FindSettingsWithLanguagesByUser(User user)
        {
            var settings = _context.Settings.Include(e => e.SettingsLanguages).ThenInclude(l => l.Language).Where(s => s.Username == user.Username).FirstOrDefault();

            if (settings == null)
            {
                settings = new Settings(user.Username);
                _context.Add(settings);
                _context.SaveChanges();
            }
            return settings;
        }

        public virtual Settings FindSettingsWithLanguagesByUserToken(string usertoken)
        {
            var foundUser = _userServices.FindUserByUserToken(usertoken);
            var settings = FindSettingsWithLanguagesByUser(foundUser);

            return settings;
        }

        private bool UserExists(string username)
        {
            return _context.Users.Any(e => e.Username == username);
        }

        private bool SettingsExists(string username)
        {
            return _context.Settings.Any(s => s.Username == username);
        }

        public virtual void UpdateAndSaveSettingsFoundByUserToken(Settings newSettings, string usertoken)
        {
            var foundSettings = FindSettingsWithLanguagesByUserToken(usertoken);
            UpdateSettings(newSettings, usertoken);
            _context.SaveChanges();
        }

        public void UpdateSettings(Settings newSettings, string usertoken)
        {
            var settingsFoundInDb = FindSettingsByUserToken(usertoken);
            settingsFoundInDb.EnableNotification = newSettings.EnableNotification;
            settingsFoundInDb.EnableBackgroundSync = newSettings.EnableBackgroundSync;
            settingsFoundInDb.MaxDistanceInKm = newSettings.MaxDistanceInKm;
            _context.Settings.Update(settingsFoundInDb);
            UpdateSettingsLanguageList(newSettings, usertoken);
        }

        public void UpdateSettingsLanguageList(Settings newSettings, string usertoken)
        {
            List<string> passedLanguageNameList = newSettings.PreferredLanguagesNames;
            int settingsId = FindSettingsIdByUsertoken(usertoken);

            foreach (string languageName in passedLanguageNameList)
            {
                int languageId = GetLanguageIdByLanguageName(languageName);

                if (!SettingsLanguageItemExistsInDb(settingsId, languageId))
                {
                    AddSettingsLanguageItem(settingsId, languageId);
                }
            }
            List<string> LanguagesNamesListInLanguageDb = _languageServices.GetLanguageNamesListFromLanguageDb();

            foreach (string languageName in LanguagesNamesListInLanguageDb)
            {
                int languageId = GetLanguageIdByLanguageName(languageName);

                if (SettingsLanguageItemExistsInDb(settingsId, languageId) &&
                    !passedLanguageNameList.Contains(languageName))
                {
                    RemoveSettingsLanguageItem(settingsId, languageId);
                }
            }
        }

        private Settings FindSettingsByUserToken(string usertoken)
        {
            int settingsId = FindSettingsIdByUsertoken(usertoken);
            Settings settingsFoundInDb = FindSettingsBySettingsId(settingsId);
            return settingsFoundInDb;
        }

        private int FindSettingsIdByUsertoken(string usertoken)
        {
            User foundUser = _userServices.FindUserByUserToken(usertoken);
            int settingsId = foundUser.UserSettings.SettingsId;
            return settingsId;
        }

        private Settings FindSettingsBySettingsId(int settingsId)
        {
            return _context.Settings.Where(s => s.SettingsId == settingsId).FirstOrDefault();
        }

        private bool SettingsLanguageItemExistsInDb(int settingsId, int languageId)
        {
            return _context.SettingsLanguage.Where(sl => sl.SettingsId == settingsId).Any(sl => sl.LanguageId == languageId);
        }

        private int GetLanguageIdByLanguageName(string languageName)
        {
            Language foundLanguage = _context.Languages.Where(l => l.LanguageName == languageName).FirstOrDefault();
            int languageId = foundLanguage.LanguageId;
            return languageId;
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
