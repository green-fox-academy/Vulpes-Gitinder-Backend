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
            User swipingUser;
            SwipesResponseBody swipesResponseBody = null;

            if (String.IsNullOrEmpty(usertoken) || !_userServices.TokenExists(usertoken))
            {
                responseBody = new ErrorResponseBody("error", "Unauthorized request!");
                return StatusCode(403, responseBody);
            }
            else
            {
                swipingUser = _userServices.FindUserByUserToken(usertoken);
                _userServices.CreateAndSaveSwipe(swipingUser.Username, username, direction);
                swipesResponseBody = _userServices.GetSwipesResponseBody("success", null);
                if (direction == "right" && _userServices.MirrorRightSwipeExists(swipingUser.Username, username))
                {
                    Match match = _userServices.CreateAndSaveMatch(swipingUser.Username, username);
                    swipesResponseBody = _userServices.GetSwipesResponseBody("success", match);
                }
            }
            return StatusCode(200, swipesResponseBody);
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
                List<MatchResponseBody> matches = new List<MatchResponseBody> {
                //new MatchResponseBody("Uno_username","http://ichef-1.bbci.co.uk/news/304/media/images/63133000/jpg/_63133978_francoishollande.jpg",1230),
                //new MatchResponseBody("theCat","https://bit.ly/2DIuOQR",1235),
            };
                return new MatchesResponseBody(matches);
            }
        }
    }
}
