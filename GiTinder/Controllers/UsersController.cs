using GiTinder.Data;
using GiTinder.Models;
using GiTinder.Models.GitResponses;
using GiTinder.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly GiTinderContext _context;
        private readonly UserServices _userServices;
        public UsersController(GiTinderContext context, UserServices userServices)
        {
            _context = context;
            _userServices = userServices;
        }
        
        [HttpPost("/login")]
        public GeneralApiResponseBody Login([FromBody] LoginRequestBody loginRequestBody)
        {
            GeneralApiResponseBody responseBody;
            var username = loginRequestBody.Username;
            var accessToken = loginRequestBody.AccessToken;

            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(accessToken))
            {
                Response.StatusCode = 400;
                responseBody =
                    String.IsNullOrEmpty(username) ? 
                    new ErrorResponseBody("username") : new ErrorResponseBody("access_token");
            }                
            else
            {

                _userServices.UpdateUser(username);
                responseBody = new TokenResponseBody(_userServices.GetTokenOf(username));
            }
            return responseBody;
        }

        [HttpGet("/create-user")]
        public async Task RequestForUser(string username)
        {
            await _userServices.GetGithubProfileAsync(username);
            return;
        }
        [HttpGet("/create-user-repos")]
        public async Task RequestForUserRepos(string username)
        {
           await _userServices.GetGithubProfilesReposAsync(username);
           return;
        }
    }
}