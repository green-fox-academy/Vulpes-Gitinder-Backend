using GiTinder.Controllers;
using GiTinder.Data;
using GiTinder.Models;
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

    public class SwipeControllerTest
    {
        public static LoginRequestBody CreateLoginRequestBodyWithNullUsername()
        {
            return new LoginRequestBody()
            {
                Username = null,
                AccessToken = "mock token"
            };
        }
    }
