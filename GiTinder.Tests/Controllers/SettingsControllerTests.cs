using GiTinder.Controllers;
using GiTinder.Data;
using GiTinder.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;
using GiTinder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiTinder.Tests.Models
{
    public class SettingsControllerTests
    {
        Mock<GiTinderContext> mockContext;
        SettingsServices settingsServices;
        UserServices userServices;
        SettingsController settingsController;

        HeaderDictionary headerDictionary;
        Mock<HttpResponse> response;
        Mock<HttpContext> httpContext;
        
        [Fact]
        public void UsernameCannotBeNull()
        {
            SetUpTestingConditions();

            ErrorResponseBody result =
                usersController.Login(LoginRequestBodyFactory.CreateLoginRequestBodyWithNullUsername()) as ErrorResponseBody;
            Assert.Equal("error", result.Status);
            Assert.Equal("username is missing!", result.Message);
        }

        [Fact]
        public void UsernameCannotBeEmpty()
        {
            SetUpTestingConditions();

            ErrorResponseBody result =
                usersController.Login(LoginRequestBodyFactory.CreateLoginRequestBodyWithEmptyUsername()) as ErrorResponseBody;
            Assert.Equal("error", result.Status);
            Assert.Equal("username is missing!", result.Message);
        }

        [Fact]
        public void AccessTokenCannotBeNullOrEmpty()
        {
            SetUpTestingConditions();

            ErrorResponseBody resultWithNullAccessToken =
                usersController.Login(LoginRequestBodyFactory.CreateLoginRequestBodyWithNullAccessToken()) as ErrorResponseBody;
            Assert.Equal("error", resultWithNullAccessToken.Status);
            Assert.Equal("access_token is missing!", resultWithNullAccessToken.Message);

            ErrorResponseBody resultWithEmptyAccessToken =
                usersController.Login(LoginRequestBodyFactory.CreateLoginRequestBodyWithEmptyAccessToken()) as ErrorResponseBody;
            Assert.Equal("error", resultWithEmptyAccessToken.Status);
            Assert.Equal("access_token is missing!", resultWithEmptyAccessToken.Message);
        }

        [Fact]
        public void LoginWithValidRequestBodyReturnsTokenResponseBody()
        {
            mockRepo = new Mock<GiTinderContext>();
            var mockService = new Mock<UserServices>(mockRepo.Object);
            mockService.Setup(u => u.UserExists("Tomek Stasy")).Returns(true);
            mockService.Setup(u => u.CreateGiTinderToken()).Returns(Guid.NewGuid().ToString());
            usersController = new UsersController(mockRepo.Object, mockService.Object);


            TokenResponseBody result = usersController.Login(new LoginRequestBody()
            {
                Username = "Tomek Stasy",
                AccessToken = "mock token"
            }) as TokenResponseBody;

            Assert.IsType<TokenResponseBody>(result);
        }

        private void SetUpTestingConditions()
        {
            mockContext = new Mock<GiTinderContext>();
            settingsController = new SettingsController(settingsServices, userServices);

            settingsServices = new SettingsServices(mockContext.Object, userServices);

            userServices = new UserServices(mockContext.Object);

            //usersController = new UsersController(mockRepo.Object, userServices);


            headerDictionary = new HeaderDictionary();
            response = new Mock<HttpResponse>();
            response.SetupGet(r => r.Headers).Returns(headerDictionary);

            httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(a => a.Response).Returns(response.Object);

            settingsController.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContext.Object
            };
        }
    }
}


