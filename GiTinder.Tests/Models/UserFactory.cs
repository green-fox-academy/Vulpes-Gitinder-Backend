using GiTinder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiTinder.Tests.Models
{
    class UserFactory
    {
<<<<<<< HEAD
        private static User CreateUser()
=======
        public static User CreateUser()
>>>>>>> 86ace2f0f4fee38e0556e02328d08e632d49bf24
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

        public static User CreateUserWithNullUserToken()
        {
            var user = CreateUser();
            user.UserToken = null;
            return user;
        }
    }
}
