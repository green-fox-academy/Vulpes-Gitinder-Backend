using GiTinder.Data;
using GiTinder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public ResponseBody MockLogout()
        {
            string Token = Request.Headers["X-Gitinder-Token"];
            ResponseBody responseBody;

            if (Token == null)
            {
                Response.StatusCode = 403;
                responseBody = new ErrorResponse("X-Gititnder-token");
            }
            else if (Token == "abc")
            {
                responseBody = new GitinderResponse("Logged out successfully!");
            }
            else
            {
                Response.StatusCode = 403;
                responseBody = new ErrorGitinderResponse("bad X-Gititnder-token");

            }
            return responseBody;
        }

        [HttpGet("/profile")]
        public ResponseBody MockProfile()
        {
            string Token = Request.Headers["X-Gitinder-Token"];
            ResponseBody responseBody;

            if (Token == null)
            {
                Response.StatusCode = 403;
                responseBody = new ErrorGitinderResponse("Unauthorized request!");
            }
            else if (Token == "aze")
            {
                responseBody = new ProfileResponse();
            }
            else
            {
                Response.StatusCode = 403;
                responseBody = new ErrorGitinderResponse("Unauthorized request!");
            }
            return responseBody;
        }

    }
}