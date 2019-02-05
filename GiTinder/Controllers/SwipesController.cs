﻿using System;
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
        public GeneralApiResponseBody Swipe([FromRoute] string username, string direction)

        {
            OKResponseBody responseBody = new OKResponseBody("success");
            Response.StatusCode = 200;

            return responseBody;
        }
        [HttpGet("/matches")]
        public Object Matches()
        {
            getCurrentUser();
            {
                List<MatchResponseBody> matches = new List<MatchResponseBody> {
                new MatchResponseBody("Uno_username","http://ichef-1.bbci.co.uk/news/304/media/images/63133000/jpg/_63133978_francoishollande.jpg",1230),
                new MatchResponseBody("theCat","https://f22bfca7a5abd176cefa-59c40a19620c1f22577ade10e9206cf5.ssl.cf1.rackcdn.com/571x670/sir-adam-mbo-k-01-x2-1.jpg",1235),
            };
                return new MatchesResponseBody(matches);
            }
        }
    }
}
