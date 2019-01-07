using GiTinder.Data;
using GiTinder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GiTinder.Controllers
{
    public class UsersController : Controller
    {
        private GiTinderContext _loginItem;
 
        public UsersController(GiTinderContext loginItem)
        {
            _loginItem = loginItem;
        }

        [HttpPost("/login")]
        public ResponseBody MockLogin([FromBody]LoginItem item)
        {
            ResponseBody responseBody;
            if (item.Username == null)
            {
                Response.StatusCode = 400;
                responseBody = new ErrorResponse("username");
            }
            else if (item.AccessToken == null)
            {
                Response.StatusCode = 402;
                responseBody = new ErrorResponse("acces_token");

            }
            else if (item.Username == "pavel")
            {
                responseBody = new GitinderResponse("exist_token");
            }
            else
            {
                responseBody = new GitinderResponse("new_token");
            }
            return responseBody;
        }

        [HttpDelete("/logout")]
        public IActionResult MockLogout([FromHeader]LoginItem item, ResponseBody errorMessage)
        {
            string Token = Request.Headers["acces_token"];

            if (Token == null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new ResponseBody { Status = "error" });
            }
            else if (Token == "abc")
            {
                return StatusCode(StatusCodes.Status200OK, new ResponseBody { Status = "ok" });
            }
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseBody { Status = "error"});
        }

        [HttpGet("/profile")]
        public IActionResult MockProfile([FromHeader]MockProfile profile)
        {
            string Token = Request.Headers["username"];
            
            if (Token == null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new ResponseBody { Status = "error"});
            }
            else if (Token == "aze")
            {
                return new ObjectResult(profile);
            }
            return StatusCode(StatusCodes.Status404NotFound);          
        }

    }
}
