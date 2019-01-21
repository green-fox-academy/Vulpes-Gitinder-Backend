using GiTinder.Data;
using GiTinder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiTinder.Controllers
{
    public class UsersMockController : Controller
    {
        private GiTinderContext _loginItem;

        public UsersMockController(GiTinderContext loginItem)
        {
            _loginItem = loginItem;
        }

        [HttpDelete("/logout")]
        public GeneralApiResponseBody MockLogout()
        {
            string Token = Request.Headers["X-Gitinder-Token"];
            GeneralApiResponseBody responseBody;

            if (Token == null)
            {
                Response.StatusCode = 403;
                responseBody = new ErrorResponseBody("X-Gititnder-token is missing!");
            }
            else if (Token == "abc")
            {
                responseBody = new OKResponseBody("Logged out successfully!");
            }
            else
            {
                Response.StatusCode = 403;
                responseBody = new ErrorResponseBody("bad X-Gititnder-token");

            }
            return responseBody;
        }

        [HttpGet("/profile")]
        public GeneralApiResponseBody MockProfile()
        {
            string Token = Request.Headers["X-Gitinder-Token"];
            GeneralApiResponseBody responseBody;

            if (Token == null)
            {
                Response.StatusCode = 403;
                responseBody = new ErrorResponseBody("Unauthorized request!");
            }
            else if (Token == "aze")
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

    }
}