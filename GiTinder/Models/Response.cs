using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class Response : ErrorMessage
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        public ResponseBody(string missingParam)
        {
            Status = "error";
            Message = missingParam + " is missing!";
        }

        //public string status = "ok";
        //public string gitinder_token = "abc123";




    }
}
