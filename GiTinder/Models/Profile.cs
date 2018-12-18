using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class Profile
    {
        private int id;
        private string userName;
        private string userToken;
        private int reposCount;
        private string avatar_url;
        private string login;

        public string Username { get; set; }
        public string Avatar_url { get; set; }
        public List<string> Repos { get; set; }
        public List<string> Languages { get; set; }
        public List<string> Snippets { get; set; }
    }
}
