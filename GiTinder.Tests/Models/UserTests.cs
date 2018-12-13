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
            User user = new User();
            Assert.False(user == null);
        }

        [Fact]
        public void CanSetUserNameWithString()
        {
            User user = new User();
            user.UserName = "Michel";
            Assert.Equal("Michel", user.UserName);
        }

        //[Fact]
        //public void CanNotSetUserNameToEmpty()
        //{
        //    User user = new User();
        //    user.UserName = "Michel";
        //    user.UserName = ""; 
        //    Assert.Equal("Michel", user.UserName);
        //}

    }
}
