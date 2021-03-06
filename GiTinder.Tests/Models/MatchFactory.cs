﻿using GiTinder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiTinder.Tests.Models
{
    class MatchFactory
    {
        public static Match CreateValidMatch()
        {
            return new Match("Tomek", "Vojta");
        }

        public static Match CreateMatchWithEmptyUsername_1()
        {
            var match = CreateValidMatch();
            match.Username1 = "";
            return match;
        }

        public static Match CreateMatchWithEmptyUsername_2()
        {
            var match = CreateValidMatch();
            match.Username2 = "";
            return match;
        }

        public static Match CreateMatchWithNullUsername_1()
        {
            var match = CreateValidMatch();
            match.Username1 = null;
            return match;
        }

        public static Match CreateMatchWithNullUsername_2()
        {
            var match = CreateValidMatch();
            match.Username2 = null;
            return match;
        }
    }
}
