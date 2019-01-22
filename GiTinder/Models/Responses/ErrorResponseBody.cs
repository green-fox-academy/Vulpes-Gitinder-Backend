using Newtonsoft.Json;

namespace GiTinder.Models
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

        public ErrorResponseBody(string status, string errorMessage)
        {
            Status = status;
            Message = errorMessage;
        }
    }
}
