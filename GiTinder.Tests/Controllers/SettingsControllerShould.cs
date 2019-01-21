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
        SettingsController settingsController;
        Mock<SettingsServices> settingsServices;
        Mock<UserServices> userServices;
        Mock<GiTinderContext> mockRepo;
        Mock<HttpRequest> httpRequest;
        Mock<HttpResponse> httpResponse;
        HeaderDictionary headerDictionary;
        Mock<HttpContext> httpContext;

        private void ArrangeForSettingsControllerTests()
        {
            mockRepo = new Mock<GiTinderContext>();
            userServices = new Mock<UserServices>(mockRepo.Object);
            settingsServices = new Mock<SettingsServices>(mockRepo.Object, userServices.Object);
            httpRequest = new Mock<HttpRequest>();
            httpResponse = new Mock<HttpResponse>();
            headerDictionary = new HeaderDictionary();
            httpContext = new Mock<HttpContext>();
            settingsController = new SettingsController(settingsServices.Object, userServices.Object);

            httpRequest.SetupGet(r => r.Headers).Returns(headerDictionary);
            httpContext.SetupGet(a => a.Request).Returns(httpRequest.Object);
            httpContext.SetupGet(a => a.Response).Returns(httpResponse.Object);

            settingsController.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContext.Object
            };
        }

        [Fact]
        public void ReturnErrorResponseBodyWhenUserTokenInRequestHeaderIsEmptyString()
        {
            //Arrange
            ArrangeForSettingsControllerTests();
            //headerDictionary.Add("X-Gitinder-Token", "");

            //Act
            var actualResponse = settingsController.GetSettings();
            var expectedResponseBody = new ErrorResponseBody("error", "Unauthorized request!");

            //Assert
            Assert.Equal(expectedResponseBody.Status, actualResponse.Status);
            Assert.Equal(expectedResponseBody.Message, (actualResponse as ErrorResponseBody).Message);
            httpRequest.VerifyGet(r => r.Headers);
            httpContext.VerifyGet(a => a.Request);

            //userServices.Verify(s => s.TokenExists(""), Times.Once());
            //httpResponse.VerifyGet(r => r.StatusCode);
            //Assert.Equal(403, httpResponse.Object.StatusCode);
        }

        [Fact]
        public void ReturnErrorResponseBodyWhenRequestHeaderIsMissing()
        {
            //Arrange

            ArrangeForSettingsControllerTests();
            //headerDictionary.Add("X-Gitinder-Token", "x");
            //userServices.Setup(s => s.TokenExists(null)).Returns(false);

            mockRepo = new Mock<GiTinderContext>();
            userServices = new Mock<UserServices>(mockRepo.Object);
            settingsServices = new Mock<SettingsServices>(mockRepo.Object, userServices.Object);
            settingsController = new SettingsController(settingsServices.Object, userServices.Object);

            httpRequest = new Mock<HttpRequest>();
            httpResponse = new Mock<HttpResponse>();
            headerDictionary = new HeaderDictionary();

            httpRequest.SetupGet(r => r.Headers).Returns(headerDictionary);

            httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(a => a.Request).Returns(httpRequest.Object);
            httpContext.SetupGet(a => a.Response).Returns(httpResponse.Object);

            settingsController.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContext.Object
            };

            // !_userServices.TokenExists(usertoken)
            //Act
            var actualResponse = settingsController.GetSettings();

            var expectedResponseBody = new ErrorResponseBody("error", "Unauthorized request!");

            //Assert

            Assert.Equal(expectedResponseBody.Status, actualResponse.Status);
            Assert.Equal(expectedResponseBody.Message, (actualResponse as ErrorResponseBody).Message);
            userServices.Verify(s => s.TokenExists(null), Times.Once());
        }


        //[Fact]
        //public virtual void ReturnSettingsResponseWithStringUserToken()
        //{
        //    //Arrange

        //    mockRepo = new Mock<GiTinderContext>();
        //    settingsServices = new Mock<SettingsServices>(mockRepo.Object, userServices);
        //    userServices = new Mock<UserServices>(mockRepo.Object);

        //    settings = new Mock<Settings>();


        //    //    userServices = new UserServices(mockRepo.Object);

        //    //sut
        //    settingsController = new SettingsController(settingsServices.Object, userServices.Object);

        //    settingsServices.Setup(x => x.FindSettingsWithLanguagesByUserToken(It.IsAny<string>())).Returns(settings.Object);
        //    //.Returns<Settings>();

        //    //Act
        //    var result = settingsController.GetSettings();
        //    //settingsController.GetSettings();

        //    //Assert
        //    // settingsServices.Verify(mock => mock.FindSettingsWithLanguagesByUserToken(It.IsAny<string>()), Times.Once());

        //    // Assert.Equal(settings, settingsServices.FindSettingsWithLanguagesByUserToken("x"));
        //    Assert.IsType<Settings>(result);
        //}



        //headerDictionary = new HeaderDictionary();
        //response = new Mock<HttpResponse>();
        //    response.SetupGet(r => r.Headers).Returns(headerDictionary);


        //settingsServices.FindSettingsWithLanguagesByUserToken("x");
        //settingsServices.Verify(mock => mock.FindSettingsWithLanguagesByUserToken(), Times.Once());
        //var foundSettings = _settingsServices.FindSettingsWithLanguagesByUserToken(usertoken);

        //[Fact]
        //public void ReturnErrorResponseBodyWhenUserTokenIsNull()
        //{
        //    //SetUpTestingConditions();

        //    string usertoken = null;

        //    mockRepo = new Mock<GiTinderContext>();
        //    settingsServices = new SettingsServices(mockRepo.Object, userServices);
        //    userServices = new UserServices(mockRepo.Object);
        //    settingsController = new SettingsController(settingsServices, userServices);

        //    headerDictionary = new HeaderDictionary();
        //    response = new Mock<HttpResponse>();
        //    response.SetupGet(r => r.Headers).Returns(headerDictionary);

        //    //var foundSettings = _settingsServices.FindSettingsWithLanguagesByUserToken(usertoken);

        //    usertoken = null
        //    ErrorResponseBody result =
        //        settingsController.GetSettings()
        //        Login(LoginRequestBodyFactory.CreateLoginRequestBodyWithNullUsername()) as ErrorResponseBody;
        //    Assert.Equal("error", result.Status);
        //    Assert.Equal("username is missing!", result.Message);
        //}

        ////[HttpGet("/settings")]
        ////public object GetSettings()
        ////{
        ////    GeneralApiResponseBody responseBody;
        ////    var usertoken = Request.Headers["X-Gitinder-Token"];

        ////    if (usertoken == "" || !_userServices.TokenExists(usertoken))
        ////    {
        ////        responseBody = new ErrorResponseBody("error", "Unauthorized request!");
        ////        return StatusCode(403, responseBody);
        ////    }


        //[Fact]
        //public void UsernameCannotBeEmpty()
        //{
        //    SetUpTestingConditions();

        //    ErrorResponseBody result =
        //        usersController.Login(LoginRequestBodyFactory.CreateLoginRequestBodyWithEmptyUsername()) as ErrorResponseBody;
        //    Assert.Equal("error", result.Status);
        //    Assert.Equal("username is missing!", result.Message);
        //}

        //[Fact]
        //public void AccessTokenCannotBeNullOrEmpty()
        //{
        //    SetUpTestingConditions();

        //    ErrorResponseBody resultWithNullAccessToken =
        //        usersController.Login(LoginRequestBodyFactory.CreateLoginRequestBodyWithNullAccessToken()) as ErrorResponseBody;
        //    Assert.Equal("error", resultWithNullAccessToken.Status);
        //    Assert.Equal("access_token is missing!", resultWithNullAccessToken.Message);

        //    ErrorResponseBody resultWithEmptyAccessToken =
        //        usersController.Login(LoginRequestBodyFactory.CreateLoginRequestBodyWithEmptyAccessToken()) as ErrorResponseBody;
        //    Assert.Equal("error", resultWithEmptyAccessToken.Status);
        //    Assert.Equal("access_token is missing!", resultWithEmptyAccessToken.Message);
        //}

        //[Fact]
        //public void LoginWithValidRequestBodyReturnsTokenResponseBody()
        //{
        //    mockRepo = new Mock<GiTinderContext>();
        //    var mockService = new Mock<UserServices>(mockRepo.Object);
        //    mockService.Setup(u => u.UserExists("Tomek Stasy")).Returns(true);
        //    mockService.Setup(u => u.CreateGiTinderToken()).Returns(Guid.NewGuid().ToString());
        //    usersController = new UsersController(mockRepo.Object, mockService.Object);


        //    TokenResponseBody result = usersController.Login(new LoginRequestBody()
        //    {
        //        Username = "Tomek Stasy",
        //        AccessToken = "mock token"
        //    }) as TokenResponseBody;

        //    Assert.IsType<TokenResponseBody>(result);
        //}

        //private void SetUpTestingConditions()
        //{
        //    settingsController = new SettingsController(settingsServices, userServices);
        //    settingsServices = new SettingsServices(mockRepo.Object, userServices);
        //    mockRepo = new Mock<GiTinderContext>();
        //    userServices = new UserServices(mockRepo.Object);


        //    headerDictionary = new HeaderDictionary();
        //    response = new Mock<HttpResponse>();
        //    response.SetupGet(r => r.Headers).Returns(headerDictionary);

        //    httpContext = new Mock<HttpContext>();
        //    httpContext.SetupGet(a => a.Response).Returns(response.Object);

        //    //settingsController.ControllerContext = new ControllerContext()
        //    //{
        //    //    HttpContext = httpContext.Object
        //    //};
        //}
    }
}


//  SettingsController settingsController;
//SettingsServices settingsServices;
//Mock<GiTinderContext> mockRepo;
//UserServices userServices;
////Mock<User> mockUser;

//HeaderDictionary headerDictionary;
//Mock<HttpResponse> response;
//Mock<HttpContext> httpContext;

//[Fact]
//public void ReturnSettingsResponse()
//{
//    //Arrange
//    mockRepo = new Mock<GiTinderContext>();

//    settingsServices = new SettingsServices(mockRepo.Object, userServices);
//    userServices = new UserServices(mockRepo.Object);
//    settingsController = new SettingsController(settingsServices, userServices);
//    //settingsServices.Setup(x=>x.FindSettingsWithLanguagesByUserToken(It.IsAny<string>()));

//    headerDictionary = new HeaderDictionary();
//    response = new Mock<HttpResponse>();
//    response.SetupGet(r => r.Headers).Returns(headerDictionary);


//    settingsServices.FindSettingsWithLanguagesByUserToken(null);

//    //Act

//    //Assert

//    settingsServices.Verify(mock => mock.FindSettingsWithLanguagesByUserToken(), Times.Once());

//}

//response = new Mock<HttpResponse>();
//response.SetupGet(r => r.Headers).Returns(headerDictionary);

//httpRequest.Setup(x => x.Headers["X-Gitinder-Token"]).Returns("");
// userServices.Setup(x => x.TokenExists("")).Returns(false);

//httpRequest.Object.Headers.Add("X-Gitinder-Token", "");

//httpRequest.Setup(x => x.Headers["X-Gitinder-Token"] == "").Returns();

//GeneralApiResponseBody responseBody;
//var usertoken = Request.Headers["X-Gitinder-Token"];

//if (usertoken == "" || !_userServices.TokenExists(usertoken))
//{

//httpResponse.SetupGet(r => r.StatusCode).Returns(403);

// naming convention ofTests methods: 
//MyTest_Condition_Result
//UnitOfWork_InitialCondition_ExpectedResult
//1) propose the methods (eg. 
//GetPlaceDetails_WithPlaceId_ReturnsTheGooglePlace)  
// GetPlaceDetails_WithNoId_RaisesArgumentException
// GetPlaceDetails_WithInvalidId_RaisesApplicationException

//2) write the easiest one (AAA), limit yourself to 10 line per test max
//3)

