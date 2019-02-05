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
    public class UsersControllerTests
    {
        Mock<GiTinderContext> mockRepo;
        UserServices userServices;
        UsersController usersController;
        HeaderDictionary headerDictionary;
        Mock<HttpResponse> response;
        Mock<HttpRequest> httpRequest;
        Mock<HttpContext> httpContext;

        public object SimpleRepository { get; private set; }

        [Fact]
        public void CheckingAvailableProfilesWithNoTokenReturnsAnErrorResponse()
        {
            SetUpTestingConditions();
            ErrorResponseBody result = usersController.ShowAvailableProfiles() as ErrorResponseBody;
            response.VerifySet(r => r.StatusCode = 403);
            Assert.Equal("error", result.Status);
        }

        [Fact]
        public void CheckingAvailableProfilesWithTokenReturnsAvailableResponseBody()
        {
            SetUpTestingConditions();
            headerDictionary.Add("X-Gitinder-Token", "this is a mock token");
            GeneralApiResponseBody result = usersController.ShowAvailableProfiles();
            Assert.IsType<AvailableResponseBody>(result);
        }

        private void SetUpTestingConditions()
        {
            mockRepo = new Mock<GiTinderContext>();
            userServices = new UserServices(mockRepo.Object);
            usersController = new UsersController(mockRepo.Object, userServices);
            headerDictionary = new HeaderDictionary();
            response = new Mock<HttpResponse>();
            httpContext = new Mock<HttpContext>();
            httpRequest = new Mock<HttpRequest>();
            httpRequest.SetupGet(r => r.Headers).Returns(headerDictionary);
            httpContext.SetupGet(a => a.Request).Returns(httpRequest.Object);
            httpContext.SetupGet(a => a.Response).Returns(response.Object);
            usersController.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContext.Object
            };
        }
    }
}
