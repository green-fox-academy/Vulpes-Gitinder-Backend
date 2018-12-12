using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class User
    {
        private int id;
        private string userName;
        private string userToken;
        private int reposCount;

        public int Id { get => id; set => id = value; }
        public string UserName { get => userName; set => userName = value; }
        public int ReposCount { get => reposCount; set => reposCount = value; }
        public string UserToken { get => userToken; set => userToken = value; }
        public Settings UserSettings { get; set; }

        public User()
        {

        }

        
    }
}
