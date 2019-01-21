using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class ProfileResponse : GeneralApiResponseBody
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("url")]
        public string Avatar { get; set; }
        [JsonProperty("repos")]
        public string Repos { get; set; }
        [JsonProperty("languages")]
        public string Languages { get; set; }


        public ProfileResponse()
        {
            Username = "aze";
            Avatar = "https://avatars1.githubusercontent.com/u/5855091?s=400&v=4";
            Repos = "string";
            Languages = "eng";

        }
    }
}
