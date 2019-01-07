using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class OKResponseBody : GeneralApiResponseBody
    {
        [JsonProperty("message")]
        public string Message { get; set; }
               
        public OKResponseBody(string Statu, string Messag)
        {
            Status = Statu;
            Message = Messag;
        }


    }
}
