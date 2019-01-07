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
        public Response response;
        public ErrorMessage errorMessage;

        public UsersController(GiTinderContext loginItem)
        {
            _loginItem = loginItem;
        }

        [HttpPost("/login")]
        public IActionResult MockLogin([FromBody]LoginItem item)
        {
            if (item != null)
            {
                return new ObjectResult(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest,errorMessage);
            }
        }

        [HttpDelete("/logout")]
        public IActionResult MockLogout([FromHeader]LoginItem item, ErrorMessage errorMessage)
        {
            string Token = Request.Headers["acces_token"];

            if (Token == null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorMessage { status = "error", message = "Unauthorized request!" });
            }
            else if (Token == "abc")
            {
                return StatusCode(StatusCodes.Status200OK, new ErrorMessage { status = "ok", message = "Logged out succesfully!" });
            }
            return StatusCode(StatusCodes.Status400BadRequest, new ErrorMessage { status = "error", message = "Used wrong acces_token!"});
        }

        [HttpGet("/profile")]
        public IActionResult MockProfile([FromHeader]MockProfile profile)
        {
            string Token = Request.Headers["username"];
            
            if (Token == null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorMessage { status = "error", message = "Unauthorized request!" });
            }
            else if (Token == "aze")
            {
                return new ObjectResult(profile);
            }
            return StatusCode(StatusCodes.Status404NotFound);          
        }

    }
}
