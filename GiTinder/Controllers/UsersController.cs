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
    public class UsersController : BaseController
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

        [HttpGet("/available/{page:int?}")]
        public GeneralApiResponseBody ShowAvailableProfiles(int page = 1)
        {
            return _userServices.GetAvailableResponseBodyForPage1();
        }

        [HttpGet("/profile")]
        public GeneralApiResponseBody GetProfile()
        {
            return new ProfileResponse(getCurrentUser());
        }
    }
}

