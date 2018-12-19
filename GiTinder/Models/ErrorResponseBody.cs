using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class ErrorResponseBody : GeneralApiResponseBody
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        public ErrorResponseBody(string missingParameter)
        {
            Status = "error";
            Message = missingParameter + " is missing!";
        }

    }
}
