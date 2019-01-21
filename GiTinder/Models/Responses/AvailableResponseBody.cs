using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models.Responses
{
    public class AvailableResponseBody
    {
        [JsonProperty("profiles")]
        public List<Profile> Profiles { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("all")]
        public int All { get; set; }
    }
}
