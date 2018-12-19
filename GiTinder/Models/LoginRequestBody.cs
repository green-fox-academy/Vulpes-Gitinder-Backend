using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
