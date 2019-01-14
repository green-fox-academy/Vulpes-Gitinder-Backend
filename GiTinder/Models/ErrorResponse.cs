using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class ErrorResponse : ResponseBody
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        public ErrorResponse(string messageParam)
        {
            Status = "error";
            Message = messageParam + " is missing!";
        }
        
    }
}
