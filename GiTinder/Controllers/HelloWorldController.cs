using Microsoft.AspNetCore.Mvc;

namespace GiTinder.Controllers
{
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet("/hello")]
        public ActionResult<string> SayHello()
        {
            return "Hello, World! I am an endpoint that returns this string and does nothing else";
        }

        [HttpGet("/ci-test")]
        public ActionResult<string> TestOfCI()
        {
            return "Hello, World! This is to check if CI works properly";
        }
    }
}
