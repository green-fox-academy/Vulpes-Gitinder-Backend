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

                List<ProfileResponse> firstPageWithProfiles = new List<ProfileResponse>();
                //{
                //    new ProfileResponse("Michel Jobless", michelImage, "my-fav-html-tags", "php"),
                //    new ProfileResponse("Adam Sterdam", adamImage, "javananas v4.2", "Java"),
                //    new ProfileResponse("Pavel Dorado", pavelImage, "map-of-treasure-chests", "Ruby"),
                //    new ProfileResponse("Tomek Snake", tomekImage, "my-first-repo", "Python"),
                //    new ProfileResponse("Filip-The-Chemist", filipImage, "blue-meth-for-dummies", "C"),

                //};
                
                responseBody = _userServices.GetAvailableResponseBodyForPage1();

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

                responseBody = new ProfileResponse(responseProfile.Username, responseProfile.Avatar, responseProfile.Repos.ToString());
            }
            else
            {
                responseBody = new ErrorResponseBody("Unauthorized request!");
            }
            return responseBody;

        }




    }
}

//using GiTinder.Data;
//using GiTinder.Models;
//using GiTinder.Models.GitHubResponses;
//using GiTinder.Models.Responses;
//using GiTinder.Services;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace GiTinder.Controllers
//{
//    [ApiController]
//    public class UsersController : ControllerBase
//    {
//        private readonly GiTinderContext _context;
//        private readonly UserServices _userServices;
//        public UsersController(GiTinderContext context, UserServices userServices)
//        {
//            _context = context;
//            _userServices = userServices;
//        }


//        [HttpGet("/profile")]
//        public GeneralApiResponseBody MockProfile()
//        {
//            string Token = Request.Headers["X-Gitinder-Token"];
//            GeneralApiResponseBody responseBody;

//            if (!string.IsNullOrEmpty(Token) && Token == "aze")
//            {
//                responseBody = new ProfileResponse();
//            }
//            else
//            {
//                Response.StatusCode = 403;
//                responseBody = new ErrorResponseBody("Unauthorized request!");
//            }
//            return responseBody;
//        }

//        [HttpGet("/available/{page:int?}")]
//        public GeneralApiResponseBody ShowAvailableProfiles(int page = 1)
//        {
//            int allProfiles;
//            int allUsers;
//            int countOfProfilesOnPage1;
//            int numberOfPages;
//            GeneralApiResponseBody responseBody;
//            string token = Request.Headers["X-Gitinder-Token"];

//            if (string.IsNullOrEmpty(token) || !_userServices.TokenExists(token))
//            {
//                Response.StatusCode = 403;
//                responseBody = new ErrorResponseBody("Unauthorized request!");
//            }

//            else
//            {
//                //ProfileResponse(string username, string avatar, string repos, string languages)

//                string adamImage = "https://f22bfca7a5abd176cefa-59c40a19620c1f22577ade10e9206cf5.ssl.cf1.rackcdn.com/571x670/sir-adam-mbo-k-01-x2-1.jpg";
//                string michelImage = "http://ichef-1.bbci.co.uk/news/304/media/images/63133000/jpg/_63133978_francoishollande.jpg";
//                string pavelImage = "https://inpolitics.ro/wp-content/uploads/2014/04/wpid-pavel-abraham6-280x222.jpg";
//                string tomekImage = "https://cdn.smyk.com/media/catalog/product/cache/1/image/750x750/2091d5c437d0f7138d5a951d6205592d/4/4/443630.jpg";
//                string filipImage = "https://i1.rgstatic.net/ii/profile.image/273702084411403-1442267070442_Q512/John_Siame.jpg";

//                List<ProfileResponse> profiles = new List<ProfileResponse> {
//                    new ProfileResponse("Michel Jobless", michelImage, "my-fav-html-tags", "php"),
//                    new ProfileResponse("Adam Sterdam", adamImage, "javananas v4.2", "Java"),
//                    new ProfileResponse("Pavel Dorado", pavelImage, "map-of-treasure-chests", "Ruby"),
//                    new ProfileResponse("Tomek Snake", tomekImage, "my-first-repo", "Python"),
//                    new ProfileResponse("Filip-The-Chemist", filipImage, "blue-meth-for-dummies", "C"),
//                };



//                List<User> userList = _context.Users.ToList();


//                foreach (User user in userList)
//                {
//                    _context.

//                        List<string> reposList = user.Repos.Split(';').ToList();

//                    ProfileResponse profile = new ProfileResponse(user.Username, user.Avatar, user.Repos, user.)


//                }

//                allUsers = userList.Count();
//                allProfiles = allUsers;
//                double allProfilesAsDouble = Convert.ToDouble(allProfiles);
//                numberOfPages = (int)Math.Ceiling(Convert.ToDouble(allProfiles) / 20.00);

//                if (allProfiles < 20)
//                {
//                    countOfProfilesOnPage1 = allProfiles;
//                }
//                else
//                {
//                    countOfProfilesOnPage1 = 20;
//                }

//                responseBody = new AvailableResponseBody(profiles, countOfProfilesOnPage1, allProfiles);
//            }
//            return responseBody;
//        }
//    }
//}

//public class ProfileResponse : GeneralApiResponseBody
//{
//[JsonProperty("username")]
//public string Username { get; set; }
//[JsonProperty("avatar_url")]
//public string Avatar { get; set; }
//[JsonProperty("repos")]
//public string Repos { get; set; }
//[JsonProperty("languages")]
////public string Languages { get; set; }
//public List<string> LanguageNames { get; set; }


//    public ProfileResponse()
//    {
//        Username = "aze";
//        Avatar = "https://avatars1.githubusercontent.com/u/5855091?s=400&v=4";
//        Repos = "string";
//        Languages = "eng";

//    }

//    public ProfileResponse(string username, string avatar, string repos, string languages)
//    {
//        Username = username;
//        Avatar = avatar;
//        Repos = repos;
//        Languages = languages;
//    }
//}

//public class User
//    {
//        [Key]
//[Required]
//[MinLength(1)]
//[JsonProperty("login")]

//public string Username { get; set; }

//[JsonProperty("public_repos")]
//public int ReposCount { get; set; }
//[JsonIgnore]
//public string UserToken { get; set; }
//[JsonProperty("avatar_url")]

//public string Avatar { get; set; }
//public string Repos { get; set; }

