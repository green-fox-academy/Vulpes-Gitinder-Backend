using GiTinder.Data;
using GiTinder.Models;
using GiTinder.Models.Connections;
using GiTinder.Models.GitHubResponses;
using GiTinder.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
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
        

        public UserServices()
        {
            GiTinderContext _context = new GiTinderContext();
        }

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

        public ManyMatchesResponse GetAllMatches(string usertoken)
        {
            var username = FindUserByUserToken(usertoken).Username;

            List<OneMatchResponse> matchesResponse = null;
            List<Match> matches = _context.Matches.Where(m => m.Username1 == username || m.Username2 == username).ToList();
            matches.ForEach(m => matchesResponse.Add(new OneMatchResponse(GetOtherUsername(m, username), GetOtherAvatar(m, username), m.Timestamp)));

            return new ManyMatchesResponse(matchesResponse);
        }

        private string GetOtherAvatar(Match m, string username)
        {
            var otherUsername = (GetOtherUsername(m, username));
            return _context.Users.Find(otherUsername).Avatar;
        }

        private string GetOtherUsername(Match m, string username)
        {
            return (m.Username1 == username) ? m.Username2 : m.Username1;
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
            var newUser = new User(username)
            {
                UserToken = CreateGiTinderToken()
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();

            GetLinksToAllRawFiles(username, newUser.UserToken);
        }

        public virtual async Task<bool> UpdateUser(string username)
        {
            if (UserExists(username))
            {
                UpdateToken(username);
            }
            else
            {
                CreateNewUser(username);
                await UpdateLanguagesTableAndUserLanguageTable(username);
            }
            return true;
        }

        private async Task<bool> UpdateLanguagesTableAndUserLanguageTable(string username)
        {
            var currentUser = _context.Users.Find(username);
            List<UserRepos> userRepos = await GetGithubProfilesReposAsync(username);
            List<string> repoLanguagesNames = userRepos
                .Where(rL => !string.IsNullOrEmpty(rL.Language))
                .Select(rL => rL.Language)
                .Distinct()
                .ToList();

            CreateMissingLanguages(repoLanguagesNames);

            List<int> languageIdInRepo = repoLanguagesNames.ConvertAll(rLN => GetLanguageId(rLN));            
            if (currentUser.UserLanguages == null)
            {
                languageIdInRepo.ForEach(rLI => CreateUserLanguage(username, rLI));
            }

            else
            {
                List<Language> currentLanguages = currentUser.UserLanguages.Select(ul => ul.Language).ToList();
                List<int> currentLanguageId = currentLanguages.ConvertAll(oUL => GetLanguageId(oUL.LanguageName));
                languageIdInRepo.Except(currentLanguageId).ToList().ForEach(rLI => CreateUserLanguage(username, rLI));
            }
            return true;
        }

        public async Task<bool> GetFiveRandomRawCodeUrls(string username, string gitHubToken)
        {
            List<string> allUrls = await GetLinksToAllRawFiles(username, gitHubToken);
            Random rnd = new Random();
            List<string> fiveUrls = allUrls.Count() > 5 ?
                                    allUrls.OrderBy(x => rnd.Next()).Take(5).ToList() :
                                    allUrls;
            string rawCodeUrls = "This user has no code to show!";
            if (fiveUrls.Count > 0)
            {
                rawCodeUrls = "";
                foreach(string url in fiveUrls)
                {
                    rawCodeUrls += url + ";";
                }
                rawCodeUrls.Remove(rawCodeUrls.Length - 1);
            }
            _context.Users.Find(username).FiveRawCodeFilesUrls = rawCodeUrls;
            _context.SaveChanges();

            return true;
        }

        private async Task<List<string>> GetLinksToAllRawFiles(string username, string gitHubToken)
        {
            var user = _context.Users.Find(username);
            GetGithubProfilesReposAsync(username);
            List<string> userRepoNames = GetAllRepoNames(user.Repos);
            HeadersSettingForGitHubApi();
            client.DefaultRequestHeaders.Add("Authorization", "token " + gitHubToken);

            user.RawCodeFilesUrls = new List<string>();
            userRepoNames.ForEach(rN => GetLinksToAllRawFilesInDir(user, rN, gitHubToken));

            return user.RawCodeFilesUrls;
        }

        private void GetLinksToAllRawFilesInDir(User user, string repoName, string gitHubToken, string dirName = "")
        {
            HttpResponseMessage repoContentResponse = 
                 client.GetAsync(ApiUrl + "repos/" + user.Username + repoName + "/contents" + dirName).Result;
            if (repoContentResponse.IsSuccessStatusCode)
            {
                List<GitHubDirContents> dirContent = repoContentResponse.Content.ReadAsAsync<List<GitHubDirContents>>().Result;

                foreach(GitHubDirContents content in dirContent)
                {
                    if (content.Type == "dir")
                    {
                        GetLinksToAllRawFilesInDir(user, repoName, gitHubToken, dirName + "/" + content.Name);
                    }
                    else if (content.Type == "file" && FileExtensionIsValid(content.Name))
                    {                            
                        user.RawCodeFilesUrls.Add(content.DownloadUrl);
                    } 
                }
            }
        }

        private bool FileExtensionIsValid(string file)
        {
            string[] fileExtensions = { ".java", ".cs", ".py", ".js", ".css", ".html", ".php" };
            return fileExtensions.Any(e => file.EndsWith(e));
        }

        private List<string> GetAllRepoNames(string rawReposUrls)
        {
            rawReposUrls = rawReposUrls.Remove(rawReposUrls.Length - 1);
            List<string> repoUrls = rawReposUrls.Split(";").ToList();
            List<string> reposNames = repoUrls.ConvertAll(r => r.Substring(r.LastIndexOf("/"))).ToList();
            return reposNames;
        }

        private void CreateMissingLanguages(List<string> languagesNames)
        {
            List<string> currentLanguagesNames = _context.Languages.Where(l => languagesNames.Contains(l.LanguageName)).Select(l => l.LanguageName).ToList();
            List<string> newLanguagesNames = languagesNames.Except(currentLanguagesNames).ToList();
            newLanguagesNames.ForEach(nLN => CreateLanguage(nLN));
        }

        private int GetLanguageId(string languageName)
        {
            return _context.Languages.Where(l => l.LanguageName == languageName).FirstOrDefault().LanguageId;
        }

        private bool UserLanguageExists(string username, int language)
        {
            return _context.UserLanguages.Any(uL => uL.Username == username && uL.LanguageId == language);
        }

        private void CreateUserLanguage(string username, int languageId)
        {
            _context.UserLanguages.Add(new UserLanguages(username, languageId));
            _context.SaveChanges();
        }

        private void CreateLanguage(string languageName)
        {
            var newLanguage = new Language(languageName);
            _context.Languages.Add(newLanguage);
            _context.SaveChanges();
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

        public virtual bool LanguageExists(string languageName)
        {
            return _context.Languages.Any(l => l.LanguageName == languageName);
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

        public List<ProfileResponse> GetListOfProfileResponsesPage1()
        {
            List<ProfileResponse> firstTwenty = _context.Users                
                 .Take(20)
                 .Include(e => e.UserLanguages)
                 .ThenInclude(l => l.Language)
                 .Select(user => new ProfileResponse(user))
                 .ToList();

            return firstTwenty;
        }

        public int GetAllUsersCount()
        {
            return _context.Users.ToList().Count();
        }

        public List<ProfileResponse> GetAllProfiles()
        {
            var listOfProfileResponses = _context.Users
                            .Select(user => new ProfileResponse(user))
                            .ToList();
            return listOfProfileResponses;
        }

        public virtual AvailableResponseBody GetAvailableResponseBodyForPage1()
        {
            var listOfProfileResponsesPage1 = GetListOfProfileResponsesPage1();

            int countOfProfilesOnPage1;
            int allUsersCount = GetAllUsersCount();

            if (allUsersCount < 20)
            {
                countOfProfilesOnPage1 = allUsersCount;
            }
            else
            {
                countOfProfilesOnPage1 = 20;
            }

            var responseBody = new AvailableResponseBody(listOfProfileResponsesPage1, countOfProfilesOnPage1, allUsersCount);
            return responseBody;
        }
    }
}
