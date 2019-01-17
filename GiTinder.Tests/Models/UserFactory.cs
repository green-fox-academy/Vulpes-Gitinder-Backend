using GiTinder.Models;

namespace GiTinder.Tests.Models
{
    class UserFactory
    {
        private static User CreateUser()
        {
            return new User("Michel")
            {
                ReposCount = 8,
                UserToken = "abc123"
            };
        }

        public static User CreateUserWithNullUserName()
        {
            var user = CreateUser();
            user.Username = null;
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
