using GiTinder.Data;
using GiTinder.Models;
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

        internal object FindToken(StringValues usertoken)
        {
            return _context.Users.Single(a => a.UserToken == usertoken);
        }

        public virtual void RemoveToken(string usertoken, string username)
        {
            if (TokenExists(usertoken))
            {
                _context.Find<User>(username).UserToken = "";
                _context.SaveChanges();
            }
        }


        public virtual void UpdateUser(string username)
        {
            if (UserExists(username))
            {
                GetGithubProfilesReposAsync(username).Result.ToString();
                UpdateToken(username);
            }
            else
            {
                CreateNewUser(username);
            }
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
            //List<User> allUsers = _context.Users.OrderBy(x => x.Username).Take(20).ToList();
            //List<ProfileResponse> listOfProfileResponsesPage1 = _context;

            List<ProfileResponse> firstTwenty = _context.Users
                            .Select(user => new ProfileResponse(user))
                            .Take(20)
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


        //userServices.getAllProfiles()
        //getAllProfiles()
        //return new ProfilesResponse(context.Users.All
        //                         .Select(user => new Profile(user))
        //                         .ToList())

        public AvailableResponseBody GetAvailableResponseBodyForPage1()
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