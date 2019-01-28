using Newtonsoft.Json;

namespace GiTinder.Models
{
    public class GeneralApiResponseBody
    {
        
        [JsonProperty("status", Order = -2)]
        [JsonIgnore]
        public string Status { get; set; }
    }
}
