//using GiTinder.Controllers;
//using GiTinder.Data;
//using GiTinder.Services;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using Moq;
//using Xunit;
//using GiTinder.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace GiTinder.Tests.Models
//{
//    public class SettingsControllerShould
//    {
//        SettingsController settingsController;
//        SettingsServices settingsServices;
//        Mock<GiTinderContext> mockRepo;
//        UserServices userServices;

//        HeaderDictionary headerDictionary;
//        Mock<HttpResponse> response;
//        Mock<HttpContext> httpContext;

//        [Fact]
//        public void UserTokenCannotBeNull()
//        {
//            //SetUpTestingConditions();

//            mockRepo = new Mock<GiTinderContext>();
//            settingsServices = new SettingsServices(mockRepo.Object, userServices);
//            userServices = new UserServices(mockRepo.Object);
//            settingsController = new SettingsController(settingsServices, userServices);

//            headerDictionary = new HeaderDictionary();
//            response = new Mock<HttpResponse>();
//            response.SetupGet(r => r.Headers).Returns(headerDictionary);

//            //var foundSettings = _settingsServices.FindSettingsWithLanguagesByUserToken(usertoken);

//            usertoken = null
//            ErrorResponseBody result =
//                settingsController.GetSettings()
//                Login(LoginRequestBodyFactory.CreateLoginRequestBodyWithNullUsername()) as ErrorResponseBody;
//            Assert.Equal("error", result.Status);
//            Assert.Equal("username is missing!", result.Message);
//        }

//        [Fact]
//        public void UsernameCannotBeEmpty()
//        {
//            SetUpTestingConditions();

//            ErrorResponseBody result =
//                usersController.Login(LoginRequestBodyFactory.CreateLoginRequestBodyWithEmptyUsername()) as ErrorResponseBody;
//            Assert.Equal("error", result.Status);
//            Assert.Equal("username is missing!", result.Message);
//        }

//        [Fact]
//        public void AccessTokenCannotBeNullOrEmpty()
//        {
//            SetUpTestingConditions();

//            ErrorResponseBody resultWithNullAccessToken =
//                usersController.Login(LoginRequestBodyFactory.CreateLoginRequestBodyWithNullAccessToken()) as ErrorResponseBody;
//            Assert.Equal("error", resultWithNullAccessToken.Status);
//            Assert.Equal("access_token is missing!", resultWithNullAccessToken.Message);

//            ErrorResponseBody resultWithEmptyAccessToken =
//                usersController.Login(LoginRequestBodyFactory.CreateLoginRequestBodyWithEmptyAccessToken()) as ErrorResponseBody;
//            Assert.Equal("error", resultWithEmptyAccessToken.Status);
//            Assert.Equal("access_token is missing!", resultWithEmptyAccessToken.Message);
//        }

//        [Fact]
//        public void LoginWithValidRequestBodyReturnsTokenResponseBody()
//        {
//            mockRepo = new Mock<GiTinderContext>();
//            var mockService = new Mock<UserServices>(mockRepo.Object);
//            mockService.Setup(u => u.UserExists("Tomek Stasy")).Returns(true);
//            mockService.Setup(u => u.CreateGiTinderToken()).Returns(Guid.NewGuid().ToString());
//            usersController = new UsersController(mockRepo.Object, mockService.Object);


//            TokenResponseBody result = usersController.Login(new LoginRequestBody()
//            {
//                Username = "Tomek Stasy",
//                AccessToken = "mock token"
//            }) as TokenResponseBody;

//            Assert.IsType<TokenResponseBody>(result);
//        }

//        private void SetUpTestingConditions()
//        {
//            settingsController = new SettingsController(settingsServices, userServices);
//            settingsServices = new SettingsServices(mockRepo.Object, userServices);
//            mockRepo = new Mock<GiTinderContext>();
//            userServices = new UserServices(mockRepo.Object);

                                                               
//            headerDictionary = new HeaderDictionary();
//            response = new Mock<HttpResponse>();
//            response.SetupGet(r => r.Headers).Returns(headerDictionary);

//            httpContext = new Mock<HttpContext>();
//            httpContext.SetupGet(a => a.Response).Returns(response.Object);

//            //settingsController.ControllerContext = new ControllerContext()
//            //{
//            //    HttpContext = httpContext.Object
//            //};
//        }
//    }
//}
