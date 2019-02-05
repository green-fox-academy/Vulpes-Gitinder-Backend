using GiTinder.Data;
using GiTinder.Models;
using GiTinder.Models.GitHubResponses;
using GiTinder.Models.Responses;
using GiTinder.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Controllers
{
    public class SessionController : BaseController
    {
        private readonly GiTinderContext _context;
        private readonly UserServices _userServices;
        public SessionController(GiTinderContext context, UserServices userServices)
        {
            _context = context;
            _userServices = userServices;
        }

        [HttpPost("/login")]
        public async Task<GeneralApiResponseBody> Login([FromBody] LoginRequestBody loginRequestBody)
        {
            GeneralApiResponseBody responseBody;
            var username = loginRequestBody.Username;
            var accessToken = loginRequestBody.AccessToken;

            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(accessToken))
            {
                Response.StatusCode = 400;
                responseBody =
                    String.IsNullOrEmpty(username) ?
                    new ErrorResponseBody("username is missing!") :
                    new ErrorResponseBody("access_token is missing!");
            }
            else if (await _userServices.LoginRequestIsValid(username, accessToken))
            {
                await _userServices.UpdateUser(username);
                responseBody = new TokenResponseBody(_userServices.GetTokenOf(username));
            }
            else
            {
                responseBody = new ErrorResponseBody("Unauthorized request!");
            }
            return responseBody;
        }

        [HttpDelete("/logout")]
        public async Task<GeneralApiResponseBody> Logout()
        {
            _userServices.RemoveToken(getCurrentUser());

            return new OKResponseBody("Logged out successfully!");
        }


    }
}