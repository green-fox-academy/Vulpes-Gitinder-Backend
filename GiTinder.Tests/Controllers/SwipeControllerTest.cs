using GiTinder.Controllers;
using GiTinder.Data;
using GiTinder.Services;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiTinder.Tests.Controllers
{
    Mock<GiTinderContext> mockRepo;
    UserServices userServices;
    UsersController usersController;
    HeaderDictionary headerDictionary;
    Mock<HttpResponse> response;
    Mock<HttpContext> httpContext;

    class SwipeControllerTest
    {
    }
}
