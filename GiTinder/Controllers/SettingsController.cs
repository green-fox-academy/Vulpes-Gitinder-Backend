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
        public GeneralApiResponseBody GetSettings()
        {
            GeneralApiResponseBody responseBody;
            var usertoken = Request.Headers["X-Gitinder-Token"];

            if (string.IsNullOrEmpty(usertoken) || !_userServices.TokenExists(usertoken))
            {
                Response.StatusCode = 403;
                responseBody = new ErrorResponseBody("error", "Unauthorized request!");
                return responseBody;
            }

            var foundSettings = _settingsServices.FindSettingsWithLanguagesByUserToken(usertoken);

            responseBody = new SettingsResponse(foundSettings);
            return responseBody;
        }

        [HttpPut("/settings")]
        //[ValidateAntiForgeryToken]
        public GeneralApiResponseBody PutSettings([FromBody] Settings settings)
        {
            GeneralApiResponseBody responseBody;
            var usertoken = Request.Headers["X-Gitinder-Token"];

            if (string.IsNullOrEmpty(usertoken) || !_userServices.TokenExists(usertoken))
            {
                Response.StatusCode = 403;
                responseBody = new ErrorResponseBody("error", "Unauthorized request!");
                return responseBody;
            }

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            _settingsServices.UpdateAndSaveSettingsFoundByUserToken(settings, usertoken);
            responseBody = new OKResponseBody("ok", "success");
            Response.StatusCode = 200;
            return responseBody;
        }
    }
}
