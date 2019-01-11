using GiTinder.Data;
using GiTinder.Models;
using GiTinder.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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
        
        [HttpPost("/login")]
        public GeneralApiResponseBody Login([FromBody] LoginRequestBody loginRequestBody)
        {
            GeneralApiResponseBody responseBody;

            if (String.IsNullOrEmpty(loginRequestBody.Username))
            {
                Response.StatusCode = 400;
                responseBody = new ErrorResponseBody("username");
            }                
            else if (String.IsNullOrEmpty(loginRequestBody.AccessToken))
            {
                Response.StatusCode = 400;
                responseBody = new ErrorResponseBody("access_token");
            }
            else if (UserExists(loginRequestBody.Username))
            {
                string newToken = _userServices.CreateGiTinderToken();
                _context.Find<User>(loginRequestBody.Username).UserToken = newToken;                         
                _context.SaveChanges();
                responseBody = new TokenResponseBody(newToken);
            }
            else
            {

                string token = _userServices.CreateGiTinderToken();
                var newProfile = new User(loginRequestBody.Username);
                newProfile.UserToken = token;
                _context.Users.Add(newProfile);
                _context.SaveChanges();
                responseBody = new TokenResponseBody(token);
            }
            return responseBody;
        }

        public bool UserExists(string username)
        {
            return _context.Users.Where(e => e.Username == username).Count() > 0;
        }
    }
}