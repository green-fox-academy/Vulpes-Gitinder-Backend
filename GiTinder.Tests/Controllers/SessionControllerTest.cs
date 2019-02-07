using GiTinder.Controllers;
using GiTinder.Data;
using GiTinder.Models;
using GiTinder.Models.Responses;
using GiTinder.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GiTinder.Tests.Controllers
{
    public class SessionControllerTest
    {
        Mock<GiTinderContext> mockRepo;
        UserServices userServices;
        SessionController sessionController;
        HeaderDictionary headerDictionary;
        Mock<HttpResponse> response;
        Mock<HttpRequest> httpRequest;
        Mock<HttpContext> httpContext;

        [Fact]
        public void UsernameCannotBeNull()
        {
            SetUpTestingConditions();

            ErrorResponseBody result =
                sessionController.Login(LoginRequestBodyFactory.CreateLoginRequestBodyWithNullUsername()).Result as ErrorResponseBody;
            Assert.Equal("error", result.Status);
            Assert.Equal("username is missing!", result.Message);
        }

        [Fact]
        public void UsernameCannotBeEmpty()
        {
            SetUpTestingConditions();

            ErrorResponseBody result =
                sessionController.Login(LoginRequestBodyFactory.CreateLoginRequestBodyWithEmptyUsername()).Result as ErrorResponseBody;
            Assert.Equal("error", result.Status);
            Assert.Equal("username is missing!", result.Message);
        }

        [Fact]
        public void AccessTokenCannotBeNullOrEmpty()
        {
            SetUpTestingConditions();

            ErrorResponseBody resultWithNullAccessToken =
                sessionController.Login(LoginRequestBodyFactory.CreateLoginRequestBodyWithNullAccessToken()).Result as ErrorResponseBody;
            Assert.Equal("error", resultWithNullAccessToken.Status);
            Assert.Equal("access_token is missing!", resultWithNullAccessToken.Message);

            ErrorResponseBody resultWithEmptyAccessToken =
                sessionController.Login(LoginRequestBodyFactory.CreateLoginRequestBodyWithEmptyAccessToken()).Result as ErrorResponseBody;
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
            sessionController = new SessionController(mockRepo.Object, mockService.Object);

            TokenResponseBody result = 
                sessionController.Login(LoginRequestBodyFactory.CreateValidLoginRequest()).Result as TokenResponseBody;

            Assert.IsType<TokenResponseBody>(result);
        }

        private void SetUpTestingConditions()
        {
            mockRepo = new Mock<GiTinderContext>();
            userServices = new UserServices(mockRepo.Object);
            sessionController = new SessionController(mockRepo.Object, userServices);
            headerDictionary = new HeaderDictionary();
            response = new Mock<HttpResponse>();
            httpContext = new Mock<HttpContext>();
            httpRequest = new Mock<HttpRequest>();
            httpRequest.SetupGet(r => r.Headers).Returns(headerDictionary);
            httpContext.SetupGet(a => a.Request).Returns(httpRequest.Object);
            httpContext.SetupGet(a => a.Response).Returns(response.Object);
            sessionController.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContext.Object
            };
        }
    }
}
