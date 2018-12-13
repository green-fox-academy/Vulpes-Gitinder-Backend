using GiTinder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiTinder.Tests.Models
{
    class UserFactory
    {
        public static User CreateUser()
        {
            return new User()
            {
                UserName = "Michel",
                ReposCount = 8,
                UserToken = "abc123"
            };
        }

        public static User CreateUserWithNullUserName()
        {
            var user = CreateUser();
            user.UserName = null;
            return user;
        }
    }
}
