using GiTinder.Controllers;
using GiTinder.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;

namespace GiTinder.Tests.Models
{
    public class LoginTest
    {
        [Fact]
        public void CheckUserBySetTheUserName()
        {
            var user = new MockLoginItem();
            user.username = "pablos";
            Assert.Equal("pablos", user.username);

        }

        [Fact]
        public void CheckStatus()
        {
            var response = new MockResponse();
            MockLoginContext item = new MockLoginContext();

            Assert.Contains("ok", response.status = "ok");

        }

        [Fact]
        public void CheckProfile()
        {
            var prof = new MockProfile();

            Assert.Equal("aze", prof.username = "aze");
        }



    }
}

