using GiTinder.Data;
using GiTinder.Models;
using GiTinder.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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
    }
}

