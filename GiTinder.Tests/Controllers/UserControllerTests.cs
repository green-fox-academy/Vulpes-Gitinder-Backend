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

namespace GiTinder.Tests.Controllers
{
    public class UsersControllerTests
    {
        Mock<GiTinderContext> mockRepo;
        Mock<UserServices> userServices;
        Mock<ProfileServices> profileServices;
        UsersController usersController;
        HeaderDictionary headerDictionary;
        Mock<HttpResponse> response;
        Mock<HttpRequest> httpRequest;
        Mock<HttpContext> httpContext;

        [Fact]
        public void CheckingAvailableProfilesWithTokenReturnsAvailableResponseBody()
        {
            SetUpTestingConditions();
            Mock<AvailableResponseBody> availableResponseBody = new Mock<AvailableResponseBody>();
            headerDictionary.Add("X-Gitinder-Token", "this is a mock token");
            userServices.Setup(s => s.GetAvailableResponseBodyForPage1("michel")).Verifiable();

            GeneralApiResponseBody result = usersController.ShowAvailableProfiles();

            userServices.Verify(s => s.GetAvailableResponseBodyForPage1("michel"), Times.Once());
        }

        private void SetUpTestingConditions()
        {
            mockRepo = new Mock<GiTinderContext>();
            userServices = new Mock<UserServices>(mockRepo.Object);
            profileServices = new Mock<ProfileServices>();

            usersController = new UsersController(mockRepo.Object, userServices.Object, profileServices.Object);
            headerDictionary = new HeaderDictionary();
            response = new Mock<HttpResponse>();
            httpContext = new Mock<HttpContext>();
            httpRequest = new Mock<HttpRequest>();
            httpRequest.SetupGet(r => r.Headers).Returns(headerDictionary);
            httpContext.SetupGet(a => a.Request).Returns(httpRequest.Object);
            var items = new Dictionary<object, object>();
            items.Add("user", new User("michel"));
            httpContext.SetupGet(a => a.Items).Returns(items);
            httpContext.SetupGet(a => a.Response).Returns(response.Object);
            usersController.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContext.Object
            };
        }
    }
}
