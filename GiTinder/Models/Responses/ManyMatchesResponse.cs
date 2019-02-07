using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models.Responses
{
    public class ManyMatchesResponse
    {

        [JsonProperty("matches")]
        public List<OneMatchResponse> Matches { get; set; }

        public ManyMatchesResponse(List<OneMatchResponse> matchesList)
        {
            Matches = matchesList;
        }
    }
}
