using Newtonsoft.Json;

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
