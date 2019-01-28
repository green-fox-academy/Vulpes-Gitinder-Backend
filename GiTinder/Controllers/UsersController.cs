﻿using GiTinder.Data;
using GiTinder.Models;
using GiTinder.Models.GitHubResponses;
using GiTinder.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
                    new ErrorResponseBody("username is missing!") : 
                    new ErrorResponseBody("access_token is missing!");
            }
            else if(await _userServices.LoginRequestIsValid(username, accessToken))
            {
                _userServices.UpdateUser(username);
                responseBody = new TokenResponseBody(_userServices.GetTokenOf(username));
            } else
            {
                responseBody = new ErrorResponseBody("Unauthorized request!");
            }
            return responseBody;
        }

        [HttpGet("/profile")]
        public object Profile()
        {
            var usertoken = Request.Headers["X-Gitinder-Token"];
            GeneralApiResponseBody responseBody;

            var responseProfile = _userServices.FindUserByUserToken(usertoken);
             

            if (string.IsNullOrEmpty(usertoken))
            {
                Response.StatusCode = 403;
                responseBody = new ErrorResponseBody("usertoken is missing!");
            }
            else if (_userServices.TokenExists(usertoken))
            {
                _userServices.UpdateUser(responseProfile.Username);
                responseBody = new ProfileResponse(responseProfile.Username, responseProfile.Avatar, responseProfile.Repos);
            }
            else
            {
                responseBody = new ErrorResponseBody("Unauthorized request!");
            }
            return responseBody;

        }

        [HttpDelete("/logout")]
        public object Logout()
        {
            var usertoken = Request.Headers["X-Gitinder-Token"];
            GeneralApiResponseBody responseBody;
            var responseUser = _userServices.FindUserByUserToken(usertoken);

            if (string.IsNullOrEmpty(usertoken))
            {
                Response.StatusCode = 403;
                responseBody = new ErrorResponseBody("Unauthorized request!");
            }
            else if (_userServices.TokenExists(usertoken))
            {
                responseBody = new OKResponseBody("Logged out successfully!");
                _userServices.RemoveToken(usertoken, responseUser.Username);
            }
            else
            {
                Response.StatusCode = 403;
                responseBody = new ErrorResponseBody("Unauthorized request!");
            }
            return responseBody;
        }


    }
}

