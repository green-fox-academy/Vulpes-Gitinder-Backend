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
using GiTinder.Models.Responses;

namespace GiTinder.Tests.Models
{
    public class SettingsControllerTest
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
        public void ReturnErrorIfTokenInReqHeaderIsEmptyStringInGetSettings()
        {
            //Arrange
            ArrangeForSettingsControllerTests();
            headerDictionary.Add("X-Gitinder-Token", "");

            //Act
            var actualResponse = settingsController.GetSettings();
            var expectedResponseBody = new ErrorResponseBody("Unauthorized request!");

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
            var expectedResponseBody = new ErrorResponseBody("Unauthorized request!");

            //Assert
            Assert.Equal(expectedResponseBody.Status, actualResponse.Status);
            Assert.Equal(expectedResponseBody.Message, (actualResponse as ErrorResponseBody).Message);
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
            var expectedResponseBody = new ErrorResponseBody("Unauthorized request!");

            //Assert
            Assert.Equal(expectedResponseBody.Status, actualResponse.Status);
            Assert.Equal(expectedResponseBody.Message, (actualResponse as ErrorResponseBody).Message);
            userServices.Verify(s => s.TokenExists("x"), Times.Once());
            httpResponse.VerifySet(r => r.StatusCode = 403);
        }
               
        [Fact]
        public void CallUpdateAndSaveSettingsIfTokenInReqHeaderFoundInPutSettings()
        {
            //Arrange
            ArrangeForSettingsControllerTests();
            headerDictionary.Add("X-Gitinder-Token", "x");
            userServices.Setup(s => s.TokenExists(It.IsAny<string>())).Returns(true);

            Settings settings = SettingsFactory.CreateSettingsWithValidUserName();
            settingsServices.Setup(s => s.FindSettingsWithLanguagesByUserToken("x")).Returns(settings);

            settingsServices.Setup(s => s.UpdateAndSaveSettingsFoundByUserToken(settings, It.IsAny<string>())).Verifiable();

            //Act
            var actualResponse = settingsController.PutSettings(settings);
            var expectedResponseBody = new OKResponseBody("success");

            //Assert
            Assert.Equal(expectedResponseBody.Status, actualResponse.Status);
            Assert.Equal(expectedResponseBody.Message, (actualResponse as OKResponseBody).Message);
            settingsServices.Verify(s => s.UpdateAndSaveSettingsFoundByUserToken(settings, It.IsAny<string>()), Times.Once());
            httpResponse.VerifySet(r => r.StatusCode = 200);
        }

        [Fact]
        public void ReturnErrorIfTokenInReqHeaderIsEmptyStringInPutSettings()
        {
            //Arrange
            ArrangeForSettingsControllerTests();
            headerDictionary.Add("X-Gitinder-Token", "");
            Settings settings = SettingsFactory.CreateSettingsWithValidUserName();

            //Act
            var actualResponse = settingsController.PutSettings(settings);
            var expectedResponseBody = new ErrorResponseBody("Unauthorized request!");

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
            Settings settings = SettingsFactory.CreateSettingsWithValidUserName();

            //Act
            var actualResponse = settingsController.PutSettings(settings);
            var expectedResponseBody = new ErrorResponseBody("Unauthorized request!");

            //Assert
            Assert.Equal(expectedResponseBody.Status, actualResponse.Status);
            Assert.Equal(expectedResponseBody.Message, (actualResponse as ErrorResponseBody).Message);
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
            Settings settings = SettingsFactory.CreateSettingsWithValidUserName();

            //Act
            var actualResponse = settingsController.PutSettings(settings);
            var expectedResponseBody = new ErrorResponseBody("Unauthorized request!");

            //Assert
            Assert.Equal(expectedResponseBody.Status, actualResponse.Status);
            Assert.Equal(expectedResponseBody.Message, (actualResponse as ErrorResponseBody).Message);
            userServices.Verify(s => s.TokenExists("x"), Times.Once());
            httpResponse.VerifySet(r => r.StatusCode = 403);
        }
    }
}
