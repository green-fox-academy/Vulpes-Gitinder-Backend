using GiTinder.Data;
using GiTinder.Models;
using GiTinder.Models.Responses;
using GiTinder.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GiTinder.Controllers
{
    public class UsersMockController : Controller
    {
        private GiTinderContext _loginItem;
        private UserServices _userServices;

        public UsersMockController(GiTinderContext loginItem, UserServices userServices)
        {
            _loginItem = loginItem;
            _userServices = userServices;
        }

        [HttpDelete("/logout")]
        public GeneralApiResponseBody MockLogout()
        {
            string Token = Request.Headers["X-Gitinder-Token"];
            GeneralApiResponseBody responseBody;

            if (Token == null)
            {
                Response.StatusCode = 403;
                responseBody = new ErrorResponseBody("X-Gititnder-token is missing!");
            }
            else if (Token == "abc")
            {
                responseBody = new OKResponseBody("Logged out successfully!");
            }
            else
            {
                Response.StatusCode = 403;
                responseBody = new ErrorResponseBody("bad X-Gititnder-token");

            }
            return responseBody;
        }

        [HttpGet("/profile")]
        public GeneralApiResponseBody MockProfile()
        {
            string Token = Request.Headers["X-Gitinder-Token"];
            GeneralApiResponseBody responseBody;

            if (!string.IsNullOrEmpty(Token) && Token == "aze")
            {
                responseBody = new ProfileResponse();
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