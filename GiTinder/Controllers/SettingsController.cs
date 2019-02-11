using GiTinder.Data;
using GiTinder.Models;
using GiTinder.Models.Responses;
using GiTinder.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq;

namespace GiTinder.Controllers
{
    public class SettingsController : BaseController
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
            var foundSettings = _settingsServices.FindSettingsWithLanguagesByUserToken(GetCurrentUser().UserToken);
            var responseBody = new SettingsResponse(foundSettings);
            Log.Information("Info_2 from GetSettings() method of SettingsController:" +
                " New SettingsResponse: {@SettingsResponse} was created from foundSettings {@Settings}", responseBody, foundSettings);
            return responseBody;
        }

        [HttpPut("/settings")]
        //[ValidateAntiForgeryToken]
        public GeneralApiResponseBody PutSettings([FromBody] Settings settings)
        {
            GeneralApiResponseBody responseBody;
            
            _settingsServices.UpdateAndSaveSettingsFoundByUserToken(settings, GetCurrentUser().UserToken);
            responseBody = new OKResponseBody("success");
            Response.StatusCode = 200;
            Log.Information("Info_2 from PutSettings() method of SettingsController:" +
               " Settings: {@settings}. " +
               "ResponseBody returned: {@responseBody}", settings, responseBody);
            return responseBody;
        }
    }
}
