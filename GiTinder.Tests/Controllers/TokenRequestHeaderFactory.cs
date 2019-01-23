using GiTinder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiTinder.Tests.Controllers
{
    class TokenRequestHeaderFactory
    {
        public static LoginRequestBody CreateTokenRequest()
        {
            return new LoginRequestBody()
            {
                Username = null,
                AccessToken = "mock token"
            };
        }
    }
}
