using Newtonsoft.Json;

namespace GiTinder.Models
{
    public class LoginRequestBody
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}
