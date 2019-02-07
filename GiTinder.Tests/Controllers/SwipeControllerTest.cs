using GiTinder.Controllers;
using GiTinder.Data;
using GiTinder.Models;
using GiTinder.Models.Responses;
using GiTinder.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace GiTinder.Tests.Controllers
{
    public class SwipeControllerTest
    {

        Mock<GiTinderContext> mockRepo;
        UserServices userServices;
        SwipesController swipesController;
        HeaderDictionary headerDictionary;
        Mock<HttpResponse> response;
        Mock<HttpContext> httpContext;
        Mock<GiTinderMiddleware> Middleware;

        [Fact]
        public void UsertokenPresent()
        {
            ArrangingMockEnviorment();

            SwipesController swipesController = new SwipesController(mockRepo.Object, userServices);
            swipesController.ControllerContext = new ControllerContext()
            {
                HttpContext = httpContext.Object
            };
            var result = swipesController.Swipe("test", "right");
            var actual = result as OKResponseBody;

            Assert.Equal("success", actual.Message);
            Assert.Equal("ok", actual.Status);
            Assert.Equal(200, response.Object.StatusCode);

        }
        [Fact]
        public void UsertokenPresentMatches()
        {
            ArrangingMockEnviorment();
            headerDictionary.Add("X-Gitinder-Token", "anytoken");
            SwipesController swipesMatchEndpoint = new SwipesController(mockRepo.Object,userServices);

        }

        private void ArrangingMockEnviorment()
        {
            
            mockRepo = new Mock<GiTinderContext>();
            userServices = new UserServices(mockRepo.Object);
            var request = new Mock<HttpRequest>();
            headerDictionary = new HeaderDictionary();
            response = new Mock<HttpResponse>();
            Middleware = new Mock<GiTinderMiddleware>();
            httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(a => a.Request).Returns(request.Object);
            httpContext.SetupGet(a => a.Response).Returns(response.Object);
            request.SetupGet(r => r.Headers).Returns(headerDictionary);
            //var Middleware = new GiTinderMiddleware: (innerHttpContext) => Task.FromResult(0));
        }
    }
}
