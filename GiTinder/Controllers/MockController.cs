using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiTinder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GiTinder.Controllers
{
    [Route("api/[controller]")]
    public class MockController : Controller
    {
        private MockLoginContext _loginItem;

        public MockController(MockLoginContext loginItem)
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
          
            if (item.acces_token == null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new MockErrorMessage { status = "error", message = "Unauthorized request!" });


            }
            else if (item.acces_token == "abc")
            {
                //item.acces_token = [] Request.Headers.ToString();
                return StatusCode(StatusCodes.Status200OK, new MockErrorMessage { status = "ok", message = "Logged out succesfully!" });
            }
            return StatusCode(StatusCodes.Status400BadRequest, new MockErrorMessage { status = "error", message = "Used wrong acces_token!"});
            
        }

        [HttpGet("/profile")]
        public IActionResult MockProfile(MockProfile profile)
        {
            string Token = Request.Headers["username"];
            
            //string temp = Request.Headers.GetType("something");

            if (Token == null/*profile.username == null*/)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new MockErrorMessage { status = "error", message = "Unauthorized request!" });


            }
            else if (Token == "aze"/* profile.username == "aze"*/)
            {
                return new ObjectResult(profile);
            }
            return StatusCode(StatusCodes.Status404NotFound);
           
        }

        [HttpGet("/prof")]
        public IActionResult Prof([FromBody]object jsonData)
        {
            IEnumerable<string> headerValues;

            if (Request.Headers.TryGetValue("Custom", out headerValues))
            {
                string token = headerValues.First();
            }
            return new OkObjectResult(headerValues);
        }



    }
}
