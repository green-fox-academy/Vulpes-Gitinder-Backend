using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class MockProfile
    {
        public string username { get; set; }
        public string avatar_url = "https://avatars1.githubusercontent.com/u/5855091?s=400&v=4";
        public string[] repos = { "string", "repo2" };
        public string[] languages = { "eng", "hu" };

    }
}
