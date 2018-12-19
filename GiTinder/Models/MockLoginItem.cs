using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GiTinder.Models
{
    public class MockLoginItem
    {
        [Key]
        public string username { get; set; }
        public string acces_token  { get; set; }

        public static object CreateUserWithNullUserName()
        {
            throw new NotImplementedException();
        }
    }
}   
