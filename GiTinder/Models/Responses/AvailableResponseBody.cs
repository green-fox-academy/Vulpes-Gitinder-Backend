using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models.Responses
{
    public class AvailableResponseBody : GeneralApiResponseBody
    {
        [JsonProperty("profiles")]
        public List<ProfileResponse> Profiles { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("all")]
        public int All { get; set; }

        public AvailableResponseBody(List<ProfileResponse> profiles, int count, int all)
        {
            Profiles = profiles;
            Count = count;
            All = all;
        }
    }
}
