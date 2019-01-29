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


        public UsersController(GiTinderContext context, UserServices userServices)
        {
            _context = context;
            _userServices = userServices;

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

        [HttpGet("/profile")]
        public object Profile()
        {
            var usertoken = Request.Headers["X-Gitinder-Token"];
            GeneralApiResponseBody responseBody;

            var responseProfile = _userServices.FindUserByUserToken(usertoken);
             

            if (string.IsNullOrEmpty(usertoken))
            {
                Response.StatusCode = 403;
                responseBody = new ErrorResponseBody("usertoken is missing!");
            }
            else if (_userServices.TokenExists(usertoken))
            {
                _userServices.UpdateUser(responseProfile.Username);
                responseBody = new ProfileResponse(responseProfile.Username, responseProfile.Avatar, responseProfile.Repos);
            }
            else
            {
                responseBody = new ErrorResponseBody("Unauthorized request!");
            }
            return responseBody;

        }

        [HttpDelete("/logout")]
        public object Logout()
        {
            var usertoken = Request.Headers["X-Gitinder-Token"];
            GeneralApiResponseBody responseBody;
            var responseUser = _userServices.FindUserByUserToken(usertoken);

            if (string.IsNullOrEmpty(usertoken))
            {
                Response.StatusCode = 403;
                responseBody = new ErrorResponseBody("Unauthorized request!");
            }
            else if (_userServices.TokenExists(usertoken))
            {
                responseBody = new OKResponseBody("Logged out successfully!");
                _userServices.RemoveToken(usertoken, responseUser.Username);
            }
            else
            {
                Response.StatusCode = 403;
                responseBody = new ErrorResponseBody("Unauthorized request!");
            }
            return responseBody;
        }


    }
}

