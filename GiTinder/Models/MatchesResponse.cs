﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class MatchesResponseBody
    {
        public List<MatchResponseBody> matches { get; set; }
        public MatchesResponseBody(List<MatchResponseBody> matchesList)
        {
            matches = matchesList;
        }
    }
}