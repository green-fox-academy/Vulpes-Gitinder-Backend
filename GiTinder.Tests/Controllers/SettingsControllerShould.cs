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
        Mock<Settings> mockSettings;
        Mock<SettingsResponse> mockSettingsResponse;

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

            userServices.Verify(s => s.TokenExists(""), Times.Never);
            httpResponse.VerifySet(r => r.StatusCode = 403);
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
            userServices.Verify(s => s.TokenExists(It.IsAny<string>()), Times.Never);
            httpResponse.VerifySet(r => r.StatusCode = 403);
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
            httpResponse.VerifySet(r => r.StatusCode = 403);
        }

        [Fact]
        public void ReturnSettingsResponseIfTokenInReqHeaderFound()
        {
            //Arrange
            ArrangeForSettingsControllerTests();
            headerDictionary.Add("X-Gitinder-Token", "x");
            userServices.Setup(s => s.TokenExists(It.IsAny<string>())).Returns(true);
            mockSettings = new Mock<Settings>("Jonathan");
           // mockSettings.Setup(s => s.Username).Returns("Jonathan");
            mockSettingsResponse = new Mock<SettingsResponse>();
            settingsServices.Setup(s => s.FindSettingsWithLanguagesByUserToken(It.IsAny<string>())).Returns(mockSettings.Object);

            //mockSettingsResponse.Setup(s => s.Username).Returns("Jonathan");
                                 
            //Act
            var actualResponse = settingsController.GetSettings();
            //var expectedResponseBody = new SettingsResponse(mockSettings.Object);
            //var foundSettings = _settingsServices.FindSettingsWithLanguagesByUserToken(usertoken);
            //responseBody = new SettingsResponse(foundSettings);
            //return responseBody;

            //Assert
            settingsServices.Verify(s => s.FindSettingsWithLanguagesByUserToken("x"), Times.Once());
            userServices.Verify(s => s.TokenExists("x"), Times.Once());
           // Assert.Equal(expectedResponseBody.Status, actualResponse.Status);
            //Assert.Equal(expectedResponseBody.Username, (actualResponse as SettingsResponse).Username);
            //Assert.Equal(expectedResponseBody.Status, expectedResponseBody.Status);
            //Assert.Equal(expectedResponseBody.Message, (actualResponse as ErrorResponseBody).Message);
            //mockSettings.VerifyGet(s => s.Username);
            //mockSettingsResponse.VerifyGet(s => s.Username);
            httpRequest.VerifyGet(r => r.Headers);
            httpContext.VerifyGet(a => a.Request);

            //Assert.True(headerDictionary.ContainsKey("X-Gitinder-Token"));
            //Assert.False(string.IsNullOrEmpty(httpRequest.Object.Headers["X-Gitinder-Token"]));
        }
    }
}
