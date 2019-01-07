using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GiTinder.Data;
using GiTinder.Models;
using System.Collections;
using Microsoft.Extensions.Logging;

namespace GiTinder.Controllers
{
    public class SettingsController : Controller
    {
        private GiTinderContext _context;

        public SettingsController(GiTinderContext context)
        {
            _context = context;
        }

        // GET: Settings
        [HttpGet("/settings")]
        public object GetSettings([FromRoute] string username)
        {
            GeneralApiResponseBody responseBody;

            if (Request.Headers["X-Gitinder-Token"] == "" || !UserExists(Request.Headers["X-Gitinder-Token"]))
            {
                responseBody = new ErrorResponseBody("error", "Unauthorized request!");
                return StatusCode(403, responseBody);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var foundUser = _context.Users.Where(s => s.UserToken == Request.Headers["X-Gitinder-Token"]).FirstOrDefault();
            var foundSettings = _context.Settings.Where(s => s.UserName == foundUser.UserName).FirstOrDefault();
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                // var settings = new Settings("Mock Filip", true, true, 160);
                //_logger.LogInformation("Mock Settings was created!" );
                return foundSettings;
            }
        }

        ///////
        [HttpPut("/settings")]
        //[ValidateAntiForgeryToken]
        public object PutSettings([FromBody] Settings settings)
        {

            GeneralApiResponseBody responseBody;

            if (Request.Headers["X-Gitinder-Token"] == "" || !UserExists(Request.Headers["X-Gitinder-Token"]))
            {
                responseBody = new ErrorResponseBody("error", "Unauthorized request!");
                return StatusCode(403, responseBody);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var foundUser = _context.Users.Where(s => s.UserToken == Request.Headers["X-Gitinder-Token"]).FirstOrDefault();
            var foundSettings = _context.Settings.Where(s => s.UserName == foundUser.UserName).FirstOrDefault();

            //foundSettings.SettingsId = settings.SettingsId;
            foundSettings.UserName = settings.UserName;
            foundSettings.EnableNotification = settings.EnableNotification;
            foundSettings.EnableBackgroundSync = settings.EnableBackgroundSync;
            foundSettings.MaxDistanceInKm = settings.MaxDistanceInKm;

            _context.Settings.Update(foundSettings);
            _context.SaveChanges();
            responseBody = new OKResponseBody("ok", "success");
            return StatusCode(200, responseBody);
        }

        [HttpPost("/settings")]
        //[ValidateAntiForgeryToken]
        public object PostSettings([FromBody]Settings settings)
        {
            GeneralApiResponseBody responseBody;

            if (Request.Headers["X-Gitinder-Token"] == "")
            {

                responseBody = new ErrorResponseBody("error", "Unauthorized request!");

                return StatusCode(403, responseBody);
            }

            else if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Settings.Add(settings);
            _context.SaveChanges();
            return NoContent();
        }

        private bool UserExists(string usertoken)
        {
            return _context.Users.Any(e => e.UserToken == usertoken);
        }
    }
}


