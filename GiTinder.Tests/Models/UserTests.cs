using Xunit;
using System;
using System.Collections.Generic;
using System.Text;
using GiTinder.Models;

namespace GiTinder.Tests.Models
{
    public class UserTests
    {
        [Fact]
        public void CanCreateUser()
        {
            User user1 = new User();
            Assert.True(user1 != null);
        }

        [Fact]
        public void CanSetUserNameToString()
        {
            User user2 = new User();
            user2.UserName = "Michel";
            //Assert.Equal("Michel", "Michel");
            Assert.Equal("Michel", user2.UserName);
        }
    }
}
