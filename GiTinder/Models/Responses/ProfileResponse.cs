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
        [JsonProperty("repos")]
        public int ReposCout { get; set; }
        [JsonProperty("usertoken")]
        public string UserToken { get; set; }
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
        [JsonProperty("repos")]
        public int Repos { get; set; }

       
        public ProfileResponse(string username)
        {
            Username = username;
         
           

          

        }
    }
}
