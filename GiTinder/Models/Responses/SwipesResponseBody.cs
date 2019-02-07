using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GiTinder.Models.Responses
{
    public class SwipesResponseBody : OKResponseBody
    {
        [JsonProperty("match")]
        public OneMatchResponse OneMatchResponse { get; set; }
         
        public SwipesResponseBody(OneMatchResponse oneMatchResponse) : base("success")
        {
            OneMatchResponse = oneMatchResponse;
        }
    }
}
