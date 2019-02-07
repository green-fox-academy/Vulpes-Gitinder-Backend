using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models.Responses
{
    public class SwipesResponseBody : OKResponseBody
    {
        public MatchResponseBody MatchResponseBody { get; set; }
         
        public SwipesResponseBody(string message, MatchResponseBody matchResponseBody) : base(message)
        {
            Message = "success";
            MatchResponseBody = matchResponseBody;
        }
    }
}
