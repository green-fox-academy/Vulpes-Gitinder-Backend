using GiTinder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GiTinder.Controllers
{
    public class UsersController : Controller
    {
        private MockLoginContext _loginItem;

        public UsersController(MockLoginContext loginItem)
        {
            _loginItem = loginItem;
           // _loginItem.LoginItems.Add(new MockLoginItem {  });
            //_loginItem.SaveChanges();

           

        }


        [HttpPost("/login")]
        public IActionResult MockLogin([FromBody]MockLoginItem item, MockResponse response, MockErrorMessage errorMessage)
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
        public IActionResult MockLogout([FromHeader]MockLoginItem item, MockErrorMessage errorMessage)
        {
            string Token = Request.Headers["acces_token"];

            if (Token == null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new MockErrorMessage { status = "error", message = "Unauthorized request!" });


            }
            else if (Token == "abc")
            {
               
                return StatusCode(StatusCodes.Status200OK, new MockErrorMessage { status = "ok", message = "Logged out succesfully!" });
            }
            return StatusCode(StatusCodes.Status400BadRequest, new MockErrorMessage { status = "error", message = "Used wrong acces_token!"});
            
        }

        [HttpGet("/profile")]
        public IActionResult MockProfile([FromHeader]MockProfile profile)
        {
            string Token = Request.Headers["username"];
            

            if (Token == null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new MockErrorMessage { status = "error", message = "Unauthorized request!" });


            }
            else if (Token == "aze")
            {
                return new ObjectResult(profile);
            }
            return StatusCode(StatusCodes.Status404NotFound);
           
        }




    }
}
