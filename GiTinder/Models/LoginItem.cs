using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;


namespace GiTinder.Models
{
    public class LoginItem
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("access_token")]
        public string AccessToken  { get; set; }
    }
}   
