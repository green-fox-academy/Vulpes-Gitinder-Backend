using GiTinder.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class TokenResponseBody : GeneralApiResponseBody
    {

        [JsonProperty("gitinder_token")]
        public string GiTinderToken { get; set; }

        public TokenResponseBody(/* string giTinderToken */)
        {
            Status = "ok";
            GiTinderToken = UserServices.CreateGiTinderToken();
            //  GiTinderToken = giTinderToken ?
        }
    }
}
