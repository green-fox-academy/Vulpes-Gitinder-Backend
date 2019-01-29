using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class PorEjemplo
    {
        public List<Match> matches { get; set; }
        public PorEjemplo(List<Match> matchesList)
        {
            matches = matchesList;
        }
    }
}
