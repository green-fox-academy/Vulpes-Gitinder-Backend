using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class GitinderResponse : ResponseBody
    {
        [JsonProperty("gitinder_token")]
        public string GiTinderToken { get; set; }

        public GitinderResponse(string token)
        {
            Status = "ok";
            GiTinderToken = token;
        }
       
    }
}
