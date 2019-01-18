﻿using GiTinder.Data;
using GiTinder.Models;
using GiTinder.Models.GitHubResponses;
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
                    new ErrorResponseBody("username") : new ErrorResponseBody("access_token");
            }
            else if(await _userServices.LoginRequestIsValid(username, accessToken))
            {
                _userServices.UpdateUser(username);
                responseBody = new TokenResponseBody(_userServices.GetTokenOf(username));
            } else
            {
                responseBody = new ErrorResponseBody("correct authorization");
            }
            return responseBody;
        }
    }
}