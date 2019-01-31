using GiTinder.Data;
using GiTinder.Models;
using GiTinder.Models.GitHubResponses;
using GiTinder.Models.Responses;
using GiTinder.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly GiTinderContext _context;
        private readonly UserServices _userServices;
        private readonly ProfileServices _profileService;

        public UsersController(GiTinderContext context, UserServices userServices, ProfileServices profileService)
        {
            _context = context;
            _userServices = userServices;
            _profileService = profileService;
        }

        [HttpGet("/profile")]
        public GeneralApiResponseBody MockProfile()
        {
            string Token = Request.Headers["X-Gitinder-Token"];
            GeneralApiResponseBody responseBody;

            if (!string.IsNullOrEmpty(Token) && Token == "aze")
            {
                responseBody = new ProfileResponse();
            }
            else
            {
                Response.StatusCode = 403;
                responseBody = new ErrorResponseBody("Unauthorized request!");
            }
            return responseBody;
        }

        [HttpGet("/available/{page:int?}")]
        public GeneralApiResponseBody ShowAvailableProfiles(int page = 1)
        {
            GeneralApiResponseBody responseBody;
            string token = Request.Headers["X-Gitinder-Token"];

            if (string.IsNullOrEmpty(token))
            {
                Response.StatusCode = 403;
                responseBody = new ErrorResponseBody("Unauthorized request!");
            }
            else
            {
                responseBody = _userServices.GetAvailableResponseBodyForPage1();
            }
            return responseBody;
        }
        [HttpGet("/return20Profiles")]
        public void whatevah()
        {
            _profileService.testOnReturn();
        }
    }
}
