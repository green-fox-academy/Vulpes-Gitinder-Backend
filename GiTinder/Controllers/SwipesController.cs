using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GiTinder.Data;
using GiTinder.Models;
using GiTinder.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiTinder.Controllers
{
    public class SwipesController : ControllerBase
    {
        private readonly GiTinderContext _context;
        private readonly UserServices _userServices;

        public SwipesController(GiTinderContext context, UserServices userServices)
        {
            _context = context;
            _userServices = userServices;

        }
        [HttpPut("profiles/{username}/{direction}")]
        public ObjectResult Swipe([FromRoute] string username, string direction)

        {
            GeneralApiResponseBody responseBody;
            var usertoken = Request.Headers["X-Gitinder-Token"];
            var Swipe = new Swipe(usertoken, username, direction);

            if (String.IsNullOrEmpty(usertoken))
            {
                responseBody = new ErrorResponseBody("error", "Unauthorized request!");
                return StatusCode(403, responseBody);
            }
            else
            {
                responseBody = new OKResponseBody("success");
                return StatusCode(200, responseBody);
            }
        }
        [HttpGet("/matches")]
        public Object Matches()
        {
            GeneralApiResponseBody responseBody;
            var usertoken = Request.Headers["X-Gitinder-Token"];
            if (String.IsNullOrEmpty(usertoken))
            {
                responseBody = new ErrorResponseBody("error", "Unauthorized request!");
                return StatusCode(403, responseBody);
            }
            else
            {
                responseBody = new MatchResponse("success","Michel Jackson", "famous.repo", 1233);
                return responseBody;
            }
        }
    }
}
