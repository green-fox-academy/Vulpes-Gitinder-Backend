using GiTinder.Controllers;
using GiTinder.Data;
using GiTinder.Models;
using GiTinder.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GiTinder.Tests.Controllers
{
    public class UsersControllerTests
    {
        [Fact]
        public void UsernameCannotBeNull()
        {
            var mockRepo = new Mock<GiTinderContext>();
            var userServices = new UserServices(mockRepo.Object);
            var usersController = new UsersController(mockRepo.Object, userServices);
            var headerDictionary = new HeaderDictionary();
            var response = new Mock<HttpResponse>();
            response.SetupGet(r => r.Headers).Returns(headerDictionary);
            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(a => a.Response).Returns(response.Object);
            usersController.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContext.Object
            };

            ErrorResponseBody result = usersController.Login(new LoginRequestBody()
            {
                Username = null,
                AccessToken = null
            }) as ErrorResponseBody;
            Assert.Equal("error", result.Status);
            Assert.Equal("username is missing!", result.Message);
        }
    }
}
