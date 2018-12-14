<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
=======
﻿using System.ComponentModel.DataAnnotations;
>>>>>>> Jonathan

namespace GiTinder.Models
{
    public class User
    {
<<<<<<< HEAD
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


=======
        
        [Key]
        [Required]
        [MinLength(1)]
        public string UserName { get; set; }
        public int ReposCount { get; set; }
        [Required]
        public string UserToken { get; set; }
>>>>>>> Jonathan
    }
}
