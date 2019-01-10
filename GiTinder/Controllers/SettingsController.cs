using GiTinder.Data;
using GiTinder.Models;
using GiTinder.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GiTinder.Controllers
{
    public class SettingsController : Controller
    {
        private GiTinderContext _context;
        private SettingsServices _settingsServices;

        public SettingsController(GiTinderContext context, SettingsServices settingsServices)
        {
            _context = context;
            _settingsServices = settingsServices;
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
            var foundSettings = _context.Settings.Include(e => e.SettingsLanguages).ThenInclude(l => l.Language).Where(s => s.UserName == foundUser.UserName).FirstOrDefault();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var settingsResponse = new SettingsResponse(foundSettings);
            return settingsResponse;
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
            var foundSettings = _context.Settings.Where(s => s.UserName == foundUser.UserName).FirstOrDefault();

            ///This if clause can be omitted once each user will have its default settings upon user creation 
            if (!SettingsExists(Request.Headers["X-Gitinder-Token"]))
            {
                settings.UserName = foundUser.UserName;
                _context.Settings.Add(settings);
                _settingsServices.addSettingsLanguageList(settings);
                _context.SaveChanges();

                responseBody = new OKResponseBody("ok", "success");
                return StatusCode(200, responseBody);
            }
            ///

            foundSettings.UserName = foundUser.UserName;
            foundSettings.EnableNotification = settings.EnableNotification;
            foundSettings.EnableBackgroundSync = settings.EnableBackgroundSync;
            foundSettings.MaxDistanceInKm = settings.MaxDistanceInKm;

            _settingsServices.updateSettingsLanguageList(settings, Request.Headers["X-Gitinder-Token"]);
            _context.Settings.Update(foundSettings);
            _context.SaveChanges();
            responseBody = new OKResponseBody("ok", "success");
            return StatusCode(200, responseBody);
        }

        private bool UserExists(string usertoken)
        {
            return _context.Users.Any(e => e.UserToken == usertoken);
        }

        ///This method can be perhaps omitted once each user will have its default settings upon user creation 
        private bool SettingsExists(string usertoken)
        {
            var foundUser = _context.Users.Where(s => s.UserToken == usertoken).FirstOrDefault();
            return _context.Settings.Any(s => s.UserName == foundUser.UserName);
        }
    }
}


