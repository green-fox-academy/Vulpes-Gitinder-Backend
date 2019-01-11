using Newtonsoft.Json;

namespace GiTinder.Models
{
    public class TokenResponseBody : GeneralApiResponseBody
    {

        [JsonProperty("gitinder_token")]
        public string GiTinderToken { get; set; }

        public TokenResponseBody(/* string giTinderToken */)
        {
            Status = "ok";
           // GiTinderToken = UserServices.CreateGiTinderToken();
                //  GiTinderToken = giTinderToken ?
        }
    }
}
