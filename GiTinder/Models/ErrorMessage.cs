using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class ErrorMessage
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }

}
