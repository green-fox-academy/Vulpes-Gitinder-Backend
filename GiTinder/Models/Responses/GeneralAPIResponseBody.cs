using Newtonsoft.Json;

namespace GiTinder.Models
{
    public class GeneralApiResponseBody
    {

        //[JsonIgnore]
        [JsonProperty("status", Order = -2, NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
    }
}
