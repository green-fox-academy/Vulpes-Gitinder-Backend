using GiTinder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiTinder.Tests.Controllers
{
    class LoginRequestBodyFactory
    {
        public static LoginRequestBody CreateLoginRequestBodyWithNullUsername()
        {
            return new LoginRequestBody()
            {
                Username = null,
                AccessToken = "mock token"
            };
        }

        public static LoginRequestBody CreateLoginRequestBodyWithEmptyUsername()
        {
            return new LoginRequestBody()
            {
                Username = "",
                AccessToken = "mock token"
            };
        }

        public static LoginRequestBody CreateLoginRequestBodyWithNullAccessToken()
        {
            return new LoginRequestBody()
            {
                Username = "Tomek Sican",
                AccessToken = null
            };
        }

        public static LoginRequestBody CreateLoginRequestBodyWithEmptyAccessToken()
        {
            return new LoginRequestBody()
            {
                Username = "Tomek Syted",
                AccessToken = ""
            };
        }

        public static LoginRequestBody CreateValidLoginRequest()
        {
            return new LoginRequestBody()
            {
                Username = "Tomek Stasy",
                AccessToken = "VerySecure123"
            };
        }
    }
}
