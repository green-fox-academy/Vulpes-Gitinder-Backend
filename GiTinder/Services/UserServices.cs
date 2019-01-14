using GiTinder.Data;
using GiTinder.Models;
using GiTinder.Models.GitResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public const string ApiUrl = "https://api.github.com/users/";
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
            HttpResponseMessage responseRepos = await client.GetAsync(ApiUrl + username + "/repos");
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
        public string CreateGiTinderToken()
        {
            string token;

            do
            {
                token = Guid.NewGuid().ToString();
            }
            while (_context.Users.Where(e => e.UserToken == token).Count() > 0);

            return token;
        }

        public void HeadersSettingForGitHubApi()
        {
            client.DefaultRequestHeaders.Add("User-Agent", "GiTinderApp");

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
    }
}
