using GiTinder.Controllers;
using GiTinder.Data;
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
            var user = new LoginItem();
            user.Username = "pablos";
            Assert.Equal("pablos", user.Username);

        }

        [Fact]
        public void CheckStatus()
        {
            var response = new ErrorResponse("error");
            GiTinderContext item = new GiTinderContext();

            Assert.Contains("ok", response.Status = "ok");

        }

        [Fact]
        public void CheckProfile()
        {
            var prof = new ProfileResponse();

            Assert.Equal("aze", prof.Username = "aze");
        }



    }
}

