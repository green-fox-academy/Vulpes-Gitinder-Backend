using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GiTinder.Data;
using GiTinder.Models;
using GiTinder.Models.Responses;
using GiTinder.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiTinder.Controllers
{
    public class SwipesController : BaseController
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
                responseBody = new ErrorResponseBody("Unauthorized request!");
                return StatusCode(403, responseBody);
            }
            else
            {
                responseBody = new OneMatchResponse("user", "https://f22bfca7a5abd176cefa-59c40a19620c1f22577ade10e9206cf5.ssl.cf1.rackcdn.com/571x670/sir-adam-mbo-k-01-x2-1.jpg", DateTime.Now);
                return StatusCode(200, responseBody);
            }
        }
        [HttpGet("/matches")]
        public GeneralApiResponseBody Matches()
        {

            GetCurrentUser();
            {
                List<OneMatchResponse> matches = new List<OneMatchResponse> {
                new OneMatchResponse("Uno_username","http://ichef-1.bbci.co.uk/news/304/media/images/63133000/jpg/_63133978_francoishollande.jpg", DateTime.Now),
                new OneMatchResponse("theCat","https://f22bfca7a5abd176cefa-59c40a19620c1f22577ade10e9206cf5.ssl.cf1.rackcdn.com/571x670/sir-adam-mbo-k-01-x2-1.jpg", DateTime.Now),
            };
                return new ManyMatchesResponse(matches);
            }

            //Real Implementation of /matches, uncomment when swipping works:
            //var usertoken = Request.Headers["X-Gitinder-Token"];
            //return _userServices.GetAllMatches(usertoken); 
        }
    }
}
