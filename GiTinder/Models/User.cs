using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class User
    {
        //private int id;
        //private string userName;
        //private string userToken;
        //private int reposCount;

        [Key]
        [Required]
        [Range(1, 3)]
        public string userName { get; set; }

        public int ReposCount { get; set; }
        public string UserToken { get; set; }

        public Settings UserSettings { get; set; }

        //public User()
        //{
        //}

        //public User(UserName userName)
        //{
        //    User user = new User();
        //    this.userName = user.userName;
        //}


    }
}
