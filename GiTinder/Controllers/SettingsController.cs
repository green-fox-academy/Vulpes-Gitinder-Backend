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
        private SettingsServices _settingsServices;
        private UserServices _userServices;

        public SettingsController(SettingsServices settingsServices, UserServices userServices)
        {
            _settingsServices = settingsServices;
            _userServices = userServices;
        }

        [HttpGet("/settings")]
        public object GetSettings()
        {
            GeneralApiResponseBody responseBody;
            var usertoken = Request.Headers["X-Gitinder-Token"];
            
            if (usertoken == "" || !_userServices.TokenExists(usertoken))
            {
                responseBody = new ErrorResponseBody("error", "Unauthorized request!");
                return StatusCode(403, responseBody);
            }

            var foundSettings = _settingsServices.FindSettingsWithLanguagesByUserToken(usertoken);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return new SettingsResponse(foundSettings);
        }

        [HttpPut("/settings")]
        //[ValidateAntiForgeryToken]
        public object PutSettings([FromBody] Settings settings)
        {
            GeneralApiResponseBody responseBody;
            var usertoken = Request.Headers["X-Gitinder-Token"];

            if (usertoken == "" || !_userServices.TokenExists(usertoken))
            {
                responseBody = new ErrorResponseBody("error", "Unauthorized request!");
                return StatusCode(403, responseBody);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _settingsServices.UpdateAndSaveSettingsFoundByUserToken(settings, usertoken);

            responseBody = new OKResponseBody("ok", "success");
            return Ok(responseBody);
        }
    }
}
