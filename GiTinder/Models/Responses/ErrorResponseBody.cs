using Newtonsoft.Json;

namespace GiTinder.Models.Responses
{
    public class ErrorResponseBody : GeneralApiResponseBody
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        public ErrorResponseBody(string errorMessage)
        {
            Status = "error";
            Message = errorMessage;
        }
    }
}
