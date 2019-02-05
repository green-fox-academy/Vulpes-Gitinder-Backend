using GiTinder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiTinder.Tests.Models
{
    class ProfileFactory
    {
        private static Profile CreateToken()
        {
            return new Profile("abc123");       
        }
        public static Profile CreateTokenWithNullValue()
        {
            var usertoken = CreateToken();
            usertoken.UserToken = null;
            return usertoken;
        }
        public static Profile CreateTokenWithSpecificValue()
        {
            var usertoken = CreateToken();
            usertoken.UserToken = "verySecure";
            return usertoken;
        }
    }
}
