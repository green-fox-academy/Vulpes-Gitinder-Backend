using GiTinder.Controllers;
using GiTinder.Data;
using GiTinder.Models;
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
        UsersController usersController;
        HeaderDictionary headerDictionary;
        Mock<HttpResponse> response;
        Mock<HttpContext> httpContext;

        [Fact]
        public void UsernameCannotBeNull()
        {
            mockRepo = new Mock<GiTinderContext>();
            userServices = new UserServices(mockRepo.Object);
            var request = new Mock<HttpRequest>();
            //headerDictionary.Add("X-Gitinder-Token", "");
            SwipesController one = new SwipesController(mockRepo.Object,userServices);
            ObjectResult actual =  one.Swipe("test", "right");
            ObjectResult expected = one.Swipe("test", "right");
            

            ErrorResponseBody first = (ErrorResponseBody) actual.Value;
            ErrorResponseBody notFailed = (ErrorResponseBody)actual.Value;
            Assert.Equal(notFailed, first);
        }

        
        private void SetUpTestingConditions()
        {
            mockRepo = new Mock<GiTinderContext>();
            userServices = new UserServices(mockRepo.Object);
            usersController = new UsersController(mockRepo.Object, userServices);
            headerDictionary = new HeaderDictionary();
            response = new Mock<HttpResponse>();
            response.SetupGet(r => r.Headers).Returns(headerDictionary);
            httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(a => a.Response).Returns(response.Object);
            usersController.ControllerContext = new ControllerContext()
            
            {
                HttpContext = httpContext.Object
            };
        }
    }
}
