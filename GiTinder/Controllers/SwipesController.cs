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
        public ObjectResult Swipe([FromQuery] string username, string direction)

        {
            System.Diagnostics.Debug.WriteLine(username + direction);
            System.Diagnostics.Debug.WriteLine("Pokebowl");
            System.Diagnostics.Trace.WriteLine(username + " " + direction);
            Debug.Write(username + direction);

            Console.WriteLine(username + direction);
            GeneralApiResponseBody responseBody;
            var usertoken = Request.Headers["X-Gitinder-Token"];

            if (String.IsNullOrEmpty(usertoken))
            {
                responseBody = new ErrorResponseBody("error", "Unauthorized request!");
                return StatusCode(403, responseBody);
            }
            else
            {
                responseBody = new OKResponseBody("ok", "success");
                return StatusCode(200, responseBody);
            }
        }
    }
}
