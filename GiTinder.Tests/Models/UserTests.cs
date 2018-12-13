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
            Assert.True(user != null);
        }
    }
}
