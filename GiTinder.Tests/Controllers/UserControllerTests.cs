using GiTinder.Controllers;
using GiTinder.Data;
using GiTinder.Models;
using GiTinder.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GiTinder.Tests.Controllers
{
    public class UsersControllerTests
    {
        Mock<GiTinderContext> mockRepo;
        UserServices userServices;
        UsersController usersController;
        HeaderDictionary headerDictionary;
        Mock<HttpResponse> response;
        Mock<HttpContext> httpContext;

        public object SimpleRepository { get; private set; }

        [Fact]
        public void UsernameCannotBeNull()
        {
            SetUpTestingConditions();

            ErrorResponseBody result = 
                usersController.Login(LoginRequestBodyFactory.CreateLoginRequestBodyWithNullUsername()).Result as ErrorResponseBody;
            Assert.Equal("error", result.Status);
            Assert.Equal("username is missing!", result.Message);
        }

        [Fact]
        public void UsernameCannotBeEmpty()
        {
            SetUpTestingConditions();

            ErrorResponseBody result = 
                usersController.Login(LoginRequestBodyFactory.CreateLoginRequestBodyWithEmptyUsername()).Result as ErrorResponseBody;
            Assert.Equal("error", result.Status);
            Assert.Equal("username is missing!", result.Message);
        }

        [Fact]
        public void AccessTokenCannotBeNullOrEmpty()
        {
            SetUpTestingConditions();

            ErrorResponseBody resultWithNullAccessToken = 
                usersController.Login(LoginRequestBodyFactory.CreateLoginRequestBodyWithNullAccessToken()).Result as ErrorResponseBody;
            Assert.Equal("error", resultWithNullAccessToken.Status);
            Assert.Equal("access_token is missing!", resultWithNullAccessToken.Message);

            ErrorResponseBody resultWithEmptyAccessToken =
                usersController.Login(LoginRequestBodyFactory.CreateLoginRequestBodyWithEmptyAccessToken()).Result as ErrorResponseBody;
            Assert.Equal("error", resultWithEmptyAccessToken.Status);
            Assert.Equal("access_token is missing!", resultWithEmptyAccessToken.Message);
        }

        [Fact]
        public void LoginWithValidRequestBodyReturnsTokenResponseBody()
        {
            mockRepo = new Mock<GiTinderContext>();
            var mockService = new Mock<UserServices>(mockRepo.Object);

            mockService.Setup(u => u.UserExists("Tomek Stasy")).Returns(true);
            mockService.Setup(u => u.LoginRequestIsValid("Tomek Stasy", "VerySecure123")).Returns(Task.FromResult(true));
            mockService.Setup(u => u.CreateGiTinderToken()).Returns(Guid.NewGuid().ToString());
            usersController = new UsersController(mockRepo.Object, mockService.Object);

            TokenResponseBody result = usersController.Login(new LoginRequestBody()
            {
                Username = "Tomek Stasy",
                AccessToken = "VerySecure123"
            }).Result as TokenResponseBody;

            Assert.IsType<TokenResponseBody>(result);
        }

        private void SetUpTestingConditions()
        {
            mockRepo = new Mock<GiTinderContext>();
            userServices = new UserServices(mockRepo.Object);
            usersController = new UsersController(mockRepo.Object, userServices);
            headerDictionary = new HeaderDictionary();
            response = new Mock<HttpResponse>();
            response.SetupGet(r => r.Headers).Returns(headerDictionary);
            httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(a => a.Response).Returns(response.Object);
            usersController.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContext.Object
            };
        }
    }
}
