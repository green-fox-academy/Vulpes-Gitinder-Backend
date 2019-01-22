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

        public SettingsServices(GiTinderContext context, UserServices userServices)
        {
            _context = context;
            _userServices = userServices;
        }

        private bool SettingsExists(string username)
        {
            return _context.Settings.Any(s => s.Username == username);
        }

        public Settings FindSettingsById(int settingsId)
        {
            return _context.Settings.Where(s => s.SettingsId == settingsId).FirstOrDefault();
        }

        public virtual Settings FindSettingsWithLanguagesByUserToken(string usertoken)
        {
            var foundUser = _userServices.FindUserByUserToken(usertoken);
            return FindSettingsWithLanguagesByUser(foundUser);
        }

        public Settings FindSettingsWithLanguagesByUser(User user)
        {
            return _context.Settings
                .Include(e => e.SettingsLanguages)
                .ThenInclude(l => l.Language)
                .Where(s => s.Username == user.Username)
                .FirstOrDefault();
        }

        public Language FindLanguageByLanguageName(string languageName)
        {
            return _context.Languages.Where(l => l.LanguageName == languageName).FirstOrDefault();
        }

        private bool SettingsLanguageEntryExists(int settingsId, int languageId)
        {
            return _context.SettingsLanguage.Where(sl => sl.SettingsId == settingsId).Any(sl => sl.LanguageId == languageId);
        }

        public void UpdateAndSaveSettingsFoundByUserToken(Settings newsettings, string usertoken)
        {
            var oldsettings = FindSettingsWithLanguagesByUserToken(usertoken);
            UpdateSettings(oldsettings, newsettings);
            _context.SaveChanges();
        }

        public void UpdateSettings(Settings oldsettings, Settings newsettings)
        {
            //var foundUser = _userServices.FindUserByUserToken(usertoken);
            oldsettings.Username = newsettings.Username;
            oldsettings.EnableNotification = newsettings.EnableNotification;
            oldsettings.EnableBackgroundSync = newsettings.EnableBackgroundSync;
            oldsettings.MaxDistanceInKm = newsettings.MaxDistanceInKm;
            _context.Settings.Update(oldsettings);
            var usertoken = _userServices.GetTokenOf(oldsettings.Username);
            UpdateSettingsLanguageList(newsettings, usertoken);
        }

        public void UpdateSettingsLanguageList(Settings settings, string usertoken)
        {
            List<string> passedLanguageNameList = settings.PreferredLanguagesNames;
            var foundUser = _userServices.FindUserByUserToken(usertoken);
            var settingsIdOfUserFound = foundUser.UserSettings.SettingsId;
            var settingsFoundById = FindSettingsById(settingsIdOfUserFound);


            foreach (string languageName in passedLanguageNameList)
            {
                AddSettingsLanguageItemFromTheListWhenNotPresentDB(settingsIdOfUserFound, languageName);
            }

            List<string> preferredLanguagesNamesListInDB = _context.SettingsLanguage.Select(sl => sl.Language.LanguageName).ToList();

            foreach (string languageName in preferredLanguagesNamesListInDB)
            {
                RemoveLanguageNameFromDBWhenNotPresentInNewList(passedLanguageNameList, settingsIdOfUserFound, languageName);
            }
        }

        private void AddSettingsLanguageItemFromTheListWhenNotPresentDB(int settingsIdOfUserFound, string languageName)
        {
            var foundLanguage = FindLanguageByLanguageName(languageName);
            int languageId = foundLanguage.LanguageId;

            if (!SettingsLanguageEntryExists(settingsIdOfUserFound, languageId))
            {
                AddSettingsLanguageItem(settingsIdOfUserFound, languageId);
            }
        }

        private void RemoveLanguageNameFromDBWhenNotPresentInNewList(List<string> passedLanguageNameList, int settingsIdOfUserFound, string languageName)
        {
            var foundLanguage = FindLanguageByLanguageName(languageName);
            int languageId = foundLanguage.LanguageId;

            if (SettingsLanguageEntryExists(settingsIdOfUserFound, languageId) &&
                !passedLanguageNameList.Contains(languageName))
            {
                RemoveSettingsLanguageItem(settingsIdOfUserFound, languageId);
            }
        }

        public void AddSettingsLanguageItem(int settingsId, int languageId)
        {
            _context.Add(new SettingsLanguage(settingsId, languageId));
        }

        public void RemoveSettingsLanguageItem(int settingsId, int languageId)
        {
            _context.SettingsLanguage.Remove(FindSettingsLanguageItemByIds(settingsId, languageId));
        }

        private SettingsLanguage FindSettingsLanguageItemByIds(int settingsId, int languageId)
        {
            return _context.SettingsLanguage.Where(sl => sl.SettingsId == settingsId).Where(sl => sl.LanguageId == languageId).FirstOrDefault();
        }
    }
}
