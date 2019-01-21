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
    public class SettingsControllerShould
    {
        Mock<GiTinderContext> mockRepo;
        Mock<UserServices> userServices;
        Mock<SettingsServices> settingsServices;
        SettingsController settingsController;
        Mock<HttpRequest> httpRequest;
        Mock<HttpResponse> httpResponse;
        HeaderDictionary headerDictionary;
        Mock<HttpContext> httpContext;

        private void ArrangeForSettingsControllerTests()
        {
            mockRepo = new Mock<GiTinderContext>();
            userServices = new Mock<UserServices>(mockRepo.Object);
            settingsServices = new Mock<SettingsServices>(mockRepo.Object, userServices.Object);
            settingsController = new SettingsController(settingsServices.Object, userServices.Object);
            httpRequest = new Mock<HttpRequest>();
            httpResponse = new Mock<HttpResponse>();
            headerDictionary = new HeaderDictionary();
            httpContext = new Mock<HttpContext>();

            httpRequest.SetupGet(r => r.Headers).Returns(headerDictionary);
            httpContext.SetupGet(a => a.Request).Returns(httpRequest.Object);
            httpContext.SetupGet(a => a.Response).Returns(httpResponse.Object);

            settingsController.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContext.Object
            };
        }

        [Fact]
        public void ReturnErrorIfTokenInReqHeaderIsEmptyString()
        {
            //Arrange
            ArrangeForSettingsControllerTests();
            headerDictionary.Add("X-Gitinder-Token", "");

            //Act
            var actualResponse = settingsController.GetSettings();
            var expectedResponseBody = new ErrorResponseBody("error", "Unauthorized request!");

            //Assert
            Assert.Equal(expectedResponseBody.Status, actualResponse.Status);
            Assert.Equal(expectedResponseBody.Message, (actualResponse as ErrorResponseBody).Message);
            httpRequest.VerifyGet(r => r.Headers);
            httpContext.VerifyGet(a => a.Request);

            Assert.True(headerDictionary.ContainsKey("X-Gitinder-Token"));
            Assert.True(string.IsNullOrEmpty(httpRequest.Object.Headers["X-Gitinder-Token"]));
            userServices.Verify(s => s.TokenExists(""), Times.Never);
        }

        [Fact]
        public void ReturnErrorIfReqHeaderIsNull()
        {
            //Arrange
            ArrangeForSettingsControllerTests();

            //Act
            var actualResponse = settingsController.GetSettings();
            var expectedResponseBody = new ErrorResponseBody("error", "Unauthorized request!");

            //Assert
            Assert.Equal(expectedResponseBody.Status, actualResponse.Status);
            Assert.Equal(expectedResponseBody.Message, (actualResponse as ErrorResponseBody).Message);
            httpRequest.VerifyGet(r => r.Headers);
            httpContext.VerifyGet(a => a.Request);

            Assert.False(headerDictionary.ContainsKey("X-Gitinder-Token"));
            Assert.True(string.IsNullOrEmpty(httpRequest.Object.Headers["X-Gitinder-Token"]));

            userServices.Verify(s => s.TokenExists(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void ReturnErrorIfTokenInReqHeaderNotFound()
        {
            //Arrange
            ArrangeForSettingsControllerTests();
            headerDictionary.Add("X-Gitinder-Token", "x");
            userServices.Setup(s => s.TokenExists(It.IsAny<string>())).Returns(false);

            //Act
            var actualResponse = settingsController.GetSettings();

            var expectedResponseBody = new ErrorResponseBody("error", "Unauthorized request!");

            //Assert

            Assert.Equal(expectedResponseBody.Status, actualResponse.Status);
            Assert.Equal(expectedResponseBody.Message, (actualResponse as ErrorResponseBody).Message);
            httpRequest.VerifyGet(r => r.Headers);
            httpContext.VerifyGet(a => a.Request);

            userServices.Verify(s => s.TokenExists("x"), Times.Once());
            Assert.True(headerDictionary.ContainsKey("X-Gitinder-Token"));
            Assert.False(string.IsNullOrEmpty(httpRequest.Object.Headers["X-Gitinder-Token"]));
        }
    }
}
