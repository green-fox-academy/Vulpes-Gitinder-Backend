using System;
using Newtonsoft.Json;

namespace GiTinder.Models
{
    public class GeneralApiResponseBody
    {
        [JsonProperty("status", Order = -2)]
        public string Status { get; set; }

        public static implicit operator GeneralApiResponseBody(Swipe v)
        {
            throw new NotImplementedException();
        }
    }
}
