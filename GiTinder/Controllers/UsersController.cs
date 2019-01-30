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
        private readonly ProfileService _profileService;

        public UsersController(GiTinderContext context, UserServices userServices, ProfileService profileService)
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

        [HttpGet("/available/{page?}")]
        public GeneralApiResponseBody ShowAvailableProfiles()
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
                string adamImage = "https://f22bfca7a5abd176cefa-59c40a19620c1f22577ade10e9206cf5.ssl.cf1.rackcdn.com/571x670/sir-adam-mbo-k-01-x2-1.jpg";
                string michelImage = "http://ichef-1.bbci.co.uk/news/304/media/images/63133000/jpg/_63133978_francoishollande.jpg";
                string pavelImage = "https://inpolitics.ro/wp-content/uploads/2014/04/wpid-pavel-abraham6-280x222.jpg";
                string tomekImage = "https://cdn.smyk.com/media/catalog/product/cache/1/image/750x750/2091d5c437d0f7138d5a951d6205592d/4/4/443630.jpg";
                string filipImage = "https://i1.rgstatic.net/ii/profile.image/273702084411403-1442267070442_Q512/John_Siame.jpg";

                List<ProfileResponse> profiles = new List<ProfileResponse> {
                    new ProfileResponse("Michel Jobless", michelImage, "my-fav-html-tags", "php"),
                    new ProfileResponse("Adam Sterdam", adamImage, "javananas v4.2", "Java"),
                    new ProfileResponse("Pavel Dorado", pavelImage, "map-of-treasure-chests", "Ruby"),
                    new ProfileResponse("Tomek Snake", tomekImage, "my-first-repo", "Python"),
                    new ProfileResponse("Filip-The-Chemist", filipImage, "blue-meth-for-dummies", "C"),
                };
                responseBody = new AvailableResponseBody(profiles, 5, 5);
            }
            return responseBody;
        }
        [HttpGet("/return20Profiles")]
        public void whatevah()
        {
            _profileService.testOnReturn();
        }
        //[HttpPut("/createUsers")]
        //public void creatingUsers()
        //{
        //   User one = new User("one","abc",2);
        //   User two = new User("two","abc",2);
        //   User three = new User("three","abc",2);
        //   User four = new User("four", "abc", 2);
        //   User five = new User("five", "abc", 2);
        //   User six = new User("sada", "abc", 2);
        //   User seven = new User("taso", "abc", 2);
        //   User eight = new User("thsadsree", "abc",2);
        //   User nine = new User("asdadqw", "abc", 2);
        //   User ten = new User("asdadqwsadawd", "abc", 2);
        //    _context.SaveChanges();
        //}
    }
}

