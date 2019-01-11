using GiTinder.Controllers;
using GiTinder.Data;
using GiTinder.Models;
using GiTinder.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Linq;
using Xunit;

namespace GiTinder.Tests.Controllers
{
    public class UsersControllerTests
    {
        [Fact]
        public void UsernameCannotBeNull()
        {
            var mockRepo = new Mock<GiTinderContext>();
            var userServices = new UserServices(mockRepo.Object);
            var usersController = new UsersController(mockRepo.Object, userServices);
            var headerDictionary = new HeaderDictionary();
            var response = new Mock<HttpResponse>();
            response.SetupGet(r => r.Headers).Returns(headerDictionary);
            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(a => a.Response).Returns(response.Object);
            usersController.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContext.Object
            };

            ErrorResponseBody result = usersController.Login(new LoginRequestBody()
            {
                Username = null,
                AccessToken = null
            }) as ErrorResponseBody;
            Assert.Equal("error", result.Status);
            Assert.Equal("username is missing!", result.Message);
        }

        [Fact]
        public void UsernameCannotBeEmpty()
        {
            var mockRepo = new Mock<GiTinderContext>();
            var userServices = new UserServices(mockRepo.Object);
            var usersController = new UsersController(mockRepo.Object, userServices);
            var headerDictionary = new HeaderDictionary();
            var response = new Mock<HttpResponse>();
            response.SetupGet(r => r.Headers).Returns(headerDictionary);
            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(a => a.Response).Returns(response.Object);
            usersController.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContext.Object
            };

            ErrorResponseBody result = usersController.Login(new LoginRequestBody()
            {
                Username = "",
                AccessToken = null
            }) as ErrorResponseBody;
            Assert.Equal("error", result.Status);
            Assert.Equal("username is missing!", result.Message);
        }

        [Fact]
        public void AccessTokenCannotBeNullOrEmpty()
        {
            var mockRepo = new Mock<GiTinderContext>();
            var userServices = new UserServices(mockRepo.Object);
            var usersController = new UsersController(mockRepo.Object, userServices);
            var headerDictionary = new HeaderDictionary();
            var response = new Mock<HttpResponse>();
            response.SetupGet(r => r.Headers).Returns(headerDictionary);
            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(a => a.Response).Returns(response.Object);
            usersController.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContext.Object
            };

            ErrorResponseBody resultWithNullAccessToken = usersController.Login(new LoginRequestBody()
            {
                Username = "Tomek Sican",
                AccessToken = null
            }) as ErrorResponseBody;
            Assert.Equal("error", resultWithNullAccessToken.Status);
            Assert.Equal("access_token is missing!", resultWithNullAccessToken.Message);

            ErrorResponseBody resultWithEmptyAccessToken = usersController.Login(new LoginRequestBody()
            {
                Username = "Tomek Syted",
                AccessToken = ""
            }) as ErrorResponseBody;
            Assert.Equal("error", resultWithEmptyAccessToken.Status);
            Assert.Equal("access_token is missing!", resultWithEmptyAccessToken.Message);
        }

        [Fact]
        public void LoginWithValidRequestBodyReturnsTokenResponseBody()
        {
            var mockRepo = new Mock<GiTinderContext>();
            var userServices = new UserServices(mockRepo.Object);
            var usersController = new UsersController(mockRepo.Object, userServices);
            var headerDictionary = new HeaderDictionary();
            var response = new Mock<HttpResponse>();
            response.SetupGet(r => r.Headers).Returns(headerDictionary);
            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(a => a.Response).Returns(response.Object);
            usersController.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContext.Object
            };

            TokenResponseBody result = usersController.Login(new LoginRequestBody()
            {
                Username = "Tomek Stasy",
                AccessToken = "mock token"
            }) as TokenResponseBody;
            Assert.IsType<TokenResponseBody>(result);          
        }
    }
}
