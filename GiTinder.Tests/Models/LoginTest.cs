using GiTinder.Models;
using GiTinder.Models.Responses;
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
            var response = new ErrorResponseBody("error");
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

