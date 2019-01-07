using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class ErrorGitinderResponse : ResponseBody
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        public ErrorGitinderResponse(string messageParam)
        {
            Status = "error";
            Message = messageParam;
        }
    }
}
