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
using System.Linq;

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
        public void ReturnErrorIfTokenInReqHeaderIsEmptyStringInGetSettings()
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
        public void ReturnErrorIfReqHeaderIsNullInGetSettings()
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
        public void ReturnErrorIfTokenInReqHeaderNotFoundInGetSettings()
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
        public void ReturnSettingsResponseIfTokenInReqHeaderFoundInGetSettings()
        {
            //Arrange
            ArrangeForSettingsControllerTests();
            headerDictionary.Add("X-Gitinder-Token", "x");
            userServices.Setup(s => s.TokenExists(It.IsAny<string>())).Returns(true);
            //mockSettings = new Mock<Settings>("Jonathan");
            mockSettings = new Mock<Settings>();
            Mock<SettingsLanguage> mockSettingsLanguages = new Mock<SettingsLanguage>();

            // mockSettings.Setup(s => s.Username).Returns("Jonathan");
            mockSettingsResponse = new Mock<SettingsResponse>();
            //PreferredLanguagesNames preferredLanguagesNames;
            //preferredLanguagesNames = new List<string>();

            List<string> list = new List<string>();

            //mockSettingsResponse.Setup(s => s.PreferredLanguagesNames).Returns(list);
            settingsServices.Setup(s => s.FindSettingsWithLanguagesByUserToken(It.IsAny<string>())).Returns(mockSettings.Object);
            mockSettings.Setup(s => s.SettingsLanguages.Select(sl => sl.Language.LanguageName).ToList()).Returns(list);

            //List<string> preferredLanguagesNames = new List<string>();
            //preferredLanguagesNames = settings.SettingsLanguages.Select(sl => sl.Language.LanguageName).ToList();
            //PreferredLanguagesNames = preferredLanguagesNames;

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





        [Fact]
        public void ReturnErrorIfTokenInReqHeaderIsEmptyStringInPutSettings()
        {
            //Arrange
            ArrangeForSettingsControllerTests();
            headerDictionary.Add("X-Gitinder-Token", "");
            mockSettings = new Mock<Settings>();
            // mockSettings.Setup(s => s.Username).Returns("Jonathan");

            //Act
            var actualResponse = settingsController.PutSettings(mockSettings.Object);
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
        public void ReturnErrorIfReqHeaderIsNullInPutSettings()
        {
            //Arrange
            ArrangeForSettingsControllerTests();
            mockSettings = new Mock<Settings>();

            //Act
            var actualResponse = settingsController.PutSettings(mockSettings.Object);
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
        public void ReturnErrorIfTokenInReqHeaderNotFoundInPutSettings()
        {
            //Arrange
            ArrangeForSettingsControllerTests();
            headerDictionary.Add("X-Gitinder-Token", "x");
            userServices.Setup(s => s.TokenExists(It.IsAny<string>())).Returns(false);
            mockSettings = new Mock<Settings>();

            //Act
            var actualResponse = settingsController.PutSettings(mockSettings.Object);
            var expectedResponseBody = new ErrorResponseBody("error", "Unauthorized request!");

            //Assert
            Assert.Equal(expectedResponseBody.Status, actualResponse.Status);
            Assert.Equal(expectedResponseBody.Message, (actualResponse as ErrorResponseBody).Message);
            httpRequest.VerifyGet(r => r.Headers);
            httpContext.VerifyGet(a => a.Request);
            userServices.Verify(s => s.TokenExists("x"), Times.Once());
            httpResponse.VerifySet(r => r.StatusCode = 403);
        }
    }
}
