using GiTinder.Controllers;
using GiTinder.Data;
using GiTinder.Models;
using GiTinder.Models.Responses;
using GiTinder.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace GiTinder.Tests.Models
{
    public class SettingsControllerTest
    {
        Mock<GiTinderContext> mockRepo;
        Mock<UserServices> userServices;
        Mock<SettingsServices> settingsServices;
        Mock<LanguageServices> languageServices;
        SettingsController settingsController;
        Mock<HttpRequest> httpRequest;
        Mock<HttpResponse> httpResponse;
        HeaderDictionary headerDictionary;
        Mock<HttpContext> httpContext;    

        private void ArrangeForSettingsControllerTests()
        {
            mockRepo = new Mock<GiTinderContext>();
            userServices = new Mock<UserServices>(mockRepo.Object);
            languageServices = new Mock<LanguageServices>(mockRepo.Object);
            settingsServices = new Mock<SettingsServices>(mockRepo.Object, userServices.Object, languageServices.Object);
            settingsController = new SettingsController(settingsServices.Object, userServices.Object);
            httpRequest = new Mock<HttpRequest>();
            httpResponse = new Mock<HttpResponse>();
            headerDictionary = new HeaderDictionary();
            httpContext = new Mock<HttpContext>();
            httpRequest.SetupGet(r => r.Headers).Returns(headerDictionary);
            httpContext.SetupGet(a => a.Request).Returns(httpRequest.Object);
            var items = new Dictionary<object, object>();
            items.Add("user", new User());
            httpContext.SetupGet(a => a.Items).Returns(items);
            httpContext.SetupGet(a => a.Response).Returns(httpResponse.Object);

            settingsController.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContext.Object
            };
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
    }
}
