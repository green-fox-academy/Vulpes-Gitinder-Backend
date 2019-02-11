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
            User swipingUser = GetCurrentUser();
            GeneralApiResponseBody swipesResponseBody = null;
            {
                _userServices.CreateAndSaveSwipe(swipingUser.Username, username, direction);
                swipesResponseBody = new OKResponseBody("success");
                if (direction == "right" && _userServices.RightSwipeExists(username, swipingUser.Username))
                {
                    Match match = _userServices.CreateAndSaveMatch(swipingUser.Username, username);
                    swipesResponseBody = _userServices.GetSwipesResponseBody("success", match);
                }
            }
            return StatusCode(200, swipesResponseBody);
        }

        [HttpGet("/matches")]
        public GeneralApiResponseBody Matches()
        {
            //Real Implementation of / matches, uncomment when swipping works:
            var usertoken = GetCurrentUser().UserToken;
            return _userServices.GetAllMatches(usertoken);
        }
    }
}
