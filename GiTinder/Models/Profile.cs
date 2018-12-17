using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class Profile
    {
        public string Username { get; set; }
        public string Avatar_url { get; set; }
        public List<string> Repos { get; set; }
        public List<string> Languages { get; set; }
        public List<string> Snippets { get; set; }
    }
}
