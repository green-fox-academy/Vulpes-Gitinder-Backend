using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models.Responses
{
    public class MatchesResponseBody
    {

        [JsonProperty("matches")]
        public List<MatchResponseBody> Matches { get; set; }

        public MatchesResponseBody(List<MatchResponseBody> matchesList)
        {
            Matches = matchesList;
        }
    }
}
