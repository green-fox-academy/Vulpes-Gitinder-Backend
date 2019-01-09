using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiTinder.Data;
using GiTinder.Services;
using Microsoft.AspNetCore.Mvc;

namespace GiTinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {   //GET api/request
        private readonly GiTinderContext _context;
        private readonly UserServices _userService;

        public ValuesController(GiTinderContext context, UserServices userService)
        {
            _context = context;
            _userService = userService;
        }

        //GET api/values/create-user
        [HttpGet("create-user")]
        public async Task RequestForUser()
        {
           // await _userService.GetUserAsync("dypher91");
            await _userService.GetUserReposAsync("Jonathan-Bonnin");
            return;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost("")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
