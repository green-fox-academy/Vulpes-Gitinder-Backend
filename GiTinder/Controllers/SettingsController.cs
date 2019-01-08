using GiTinder.Data;
using GiTinder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

            var foundUser = _context.Users.Where(s => s.UserToken == Request.Headers["X-Gitinder-Token"]).FirstOrDefault();
            var foundSettings = _context.Settings.Include(e=>e.SettingsLanguages).ThenInclude(l=>l.Language).Where(s => s.UserName == foundUser.UserName).FirstOrDefault();
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var settingsDAO = new SettingsDAO(foundSettings);
            return settingsDAO;
            // return foundSettings;
        }

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

            if (!SettingsExists(Request.Headers["X-Gitinder-Token"]))
            {
                settings.UserName = foundUser.UserName;
                _context.Settings.Add(settings);
                _context.SaveChanges();
                responseBody = new OKResponseBody("ok", "success");
                return StatusCode(200, responseBody);
            }
            
            var foundSettings = _context.Settings.Where(s => s.UserName == foundUser.UserName).FirstOrDefault();

            foundSettings.UserName = foundUser.UserName;
            foundSettings.EnableNotification = settings.EnableNotification;
            foundSettings.EnableBackgroundSync = settings.EnableBackgroundSync;
            foundSettings.MaxDistanceInKm = settings.MaxDistanceInKm;

            _context.Settings.Update(foundSettings);
            _context.SaveChanges();
            responseBody = new OKResponseBody("ok", "success");
            return StatusCode(200, responseBody);
        }

        private bool UserExists(string usertoken)
        {
            return _context.Users.Any(e => e.UserToken == usertoken);
        }

        private bool SettingsExists(string usertoken)
        {
            var foundUser = _context.Users.Where(s => s.UserToken == usertoken).FirstOrDefault();
            return _context.Settings.Any(s => s.UserName == foundUser.UserName);
        }
    }
}


