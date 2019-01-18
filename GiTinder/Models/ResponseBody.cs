using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class ResponseBody
    {
        [JsonProperty("status", Order =-2)]
        public string Status { get; set; }
    }
}
