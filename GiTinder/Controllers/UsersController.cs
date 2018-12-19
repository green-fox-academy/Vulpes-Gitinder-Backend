using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiTinder.Data;
using GiTinder.Models;
using System.Net.Http;
using System.Net;
using GiTinder.Services;

namespace GiTinder.Controllers
{
    [Route("api/[controller]")]
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
        
        // POST: /api/login
        [HttpPost("/api/login")]
        public GeneralApiResponseBody Login([FromBody] LoginRequestBody loginRequestBody)
        {
            GeneralApiResponseBody responseBody;

            if (loginRequestBody.Username == null)
            {
                Response.StatusCode = 400;
                responseBody = new ErrorResponseBody("username");
            }                
            else if (loginRequestBody.AccessToken == null)
            {
                Response.StatusCode = 400;
                responseBody = new ErrorResponseBody("access_token");
            }                
            else if (UserExists(loginRequestBody.Username))
            {
                _context.Find<User>(loginRequestBody.Username).Username = _userServices.CreateGiTinderToken();                          
                _context.SaveChanges();
                responseBody = new TokenResponseBody(/*_context.Find<User>(loginRequestBody.Username).UserToken*/);
            }      
            else
            {
                string token = _userServices.CreateGiTinderToken();
                _context.Users.Add(new User(loginRequestBody.Username/*, token*/)); //CreateProfile should be here?
                responseBody = new TokenResponseBody(/*token*/);
            }

            return responseBody;
        }

        // Below this point are auto-generated end-points
        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] string id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Username)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Username }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        private bool UserExists(string username)
        {
            return _context.Users.Any(e => e.Username == username);
        }
    }
}