﻿using GiTinder.Data;
using GiTinder.Models;
using GiTinder.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GiTinder.Controllers
{
    public class UsersMockController : Controller
    {
        private GiTinderContext _loginItem;

        public UsersMockController(GiTinderContext loginItem)
        {
            _loginItem = loginItem;
        }


        [HttpDelete("/mlogout")]
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

        [HttpGet("/mprofile")]
        public GeneralApiResponseBody MockProfile()
        {
            string Token = Request.Headers["X-Gitinder-Token"];
            GeneralApiResponseBody responseBody;

            if (!string.IsNullOrEmpty(Token) && Token == "aze")
            {
                // responseBody = new ProfileResponse("Aze", "https://avatars0.githubusercontent.com/u/5855091?s=40&v=4", "https://avatars0.githubusercontent.com/u/5855091?s=40&v=4", "java");
                List<string> reposList = new List<string> { "https://avatars0.githubusercontent.com/u/5855091?s=40&v=4", "https://avatars0.githubusercontent.com/u/5855091?s=40&v=5" };
                responseBody = new ProfileResponse("Aze", "https://avatars0.githubusercontent.com/u/5855091?s=40&v=4", reposList);
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