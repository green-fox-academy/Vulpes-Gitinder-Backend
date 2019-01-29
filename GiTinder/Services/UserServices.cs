using GiTinder.Data;
using GiTinder.Models;
using GiTinder.Models.Connections;
using GiTinder.Models.GitHubResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GiTinder.Services
{
    public class UserServices
    {
        private readonly GiTinderContext _context;
        public const string ApiUrl = "https://api.github.com/";
        private HttpClient client = new HttpClient();

        public UserServices(GiTinderContext context)
        {
            _context = context;
        }
        public async Task<User> GetGithubProfileAsync(string username)
        {
            HeadersSettingForGitHubApi();
            User rawUser = null;
            HttpResponseMessage responseUser = await client.GetAsync(ApiUrl + username);
            if (responseUser.IsSuccessStatusCode)
            {
                rawUser = await responseUser.Content.ReadAsAsync<User>();
                _context.Users.Add(rawUser);
                _context.SaveChanges();
            }
            return rawUser;
        }
        public async Task<List<UserRepos>> GetGithubProfilesReposAsync(string username)
        {
            HeadersSettingForGitHubApi();
            List<UserRepos> rawRepos = null;
            HttpResponseMessage responseRepos = await client.GetAsync(ApiUrl + "users/" + username + "/repos");
            if (responseRepos.IsSuccessStatusCode)
            {
                rawRepos = await responseRepos.Content.ReadAsAsync<List<UserRepos>>();
                string Urls = null;
                for (int i = 0; i < rawRepos.Count; i++)
                {
                    Urls = rawRepos[i].Url + ";" + Urls;
                }
                _context.Users.Find(username).Repos = Urls;
                _context.SaveChanges();
            }
            return rawRepos;
        }
        public virtual string CreateGiTinderToken()
        {
            string token;

            do
            {
                token = Guid.NewGuid().ToString();
            }
            while (_context.Users.Where(e => e.UserToken == token).Count() > 0);

            return token;
        }

        public virtual bool UserExists(string username)
        {
            return _context.Users.Where(e => e.Username == username).Count() > 0;
        }

        public virtual void UpdateToken(string username)
        {
            _context.Find<User>(username).UserToken = CreateGiTinderToken();
            _context.SaveChanges();
        }

        public virtual void CreateNewUser(string username)
        {
            var newProfile = new User(username)
            {
                UserToken = CreateGiTinderToken()
            };
            _context.Users.Add(newProfile);
            _context.SaveChanges();


        }

        public virtual async Task<bool> UpdateUser(string username)
        {
            if (UserExists(username))
            {            
                UpdateToken(username);
            }
            else
            {
                await UpdateLanguagesTableAndUserLanguageTable(username);
                CreateNewUser(username);              
            }
            return true;
        }

        private async Task<bool> UpdateLanguagesTableAndUserLanguageTable(string username)
        {
            List<UserRepos> userRepos = await GetGithubProfilesReposAsync(username);
            foreach (UserRepos userRepo in userRepos)
            {
                string languageName = userRepo.Language;
                if (!string.IsNullOrEmpty(languageName))
                { 
                    if (LanguageDoesntExist(languageName))
                    {
                        int newLangageId = CreateLanguageAndReturnItsId(languageName);
                        CreateUserLanguage(username, newLangageId);
                    }
                    else
                    {
                        int languageId = _context.Languages.Where(l => l.LanguageName == languageName).FirstOrDefault().LanguageId;
                        if (UserLanguageDoesntExist(username, languageId))
                        {
                            CreateUserLanguage(username, languageId);
                        }
                    }                    
                }
            }
            return true;
        }

        private bool UserLanguageDoesntExist(string username, int language)
        {
            return !_context.UserLanguage.Any(uL => uL.Username == username && uL.LanguageId == language);
        }

        private void CreateUserLanguage(string username, int languageId)
        {
            _context.UserLanguage.Add(new UserLanguage(username, languageId));
            _context.SaveChanges();
        }

        private int CreateLanguageAndReturnItsId(string languageName)
        {
            var newLanguage = new Language(languageName);
            _context.Languages.Add(newLanguage);
            _context.SaveChanges();
            return newLanguage.LanguageId;
        }

        public virtual string GetTokenOf(string username)
        {
            return _context.Find<User>(username).UserToken;
        }

        public void HeadersSettingForGitHubApi()
        {
            client.DefaultRequestHeaders.Add("User-Agent", "GiTinderApp");
        }

        public virtual bool TokenExists(string usertoken)
        {
            return _context.Users.Any(u => u.UserToken == usertoken);
        }

        public virtual bool LanguageDoesntExist(string languageName)
        {
            return !_context.Languages.Any(l => l.LanguageName == languageName);
        }

        public bool UserTokenCorrespondsToUsername(string username, string usertoken)
        {
            return _context.Users.Where(u => u.Username == username).Any(u => u.UserToken == usertoken);
        }

        public User FindUserByUserToken(string usertoken)
        {
            var foundUser = _context.Users.Where(u => u.UserToken == usertoken).FirstOrDefault();
            return foundUser;
        }

        public virtual async Task<bool> LoginRequestIsValid(string username, string gitHubToken)
        {
            HeadersSettingForGitHubApi();
            client.DefaultRequestHeaders.Add("Authorization", "token " + gitHubToken);
            HttpResponseMessage gitHubProfileResponse = await client.GetAsync(ApiUrl + "user");

            var profileLoggingIn = new GitHubProfile();

            if (gitHubProfileResponse.IsSuccessStatusCode)
            {
                profileLoggingIn = await gitHubProfileResponse.Content.ReadAsAsync<GitHubProfile>();
            }

            return username.Equals(profileLoggingIn.Login);
        }
    }
}