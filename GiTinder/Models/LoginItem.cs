using System;
using System.ComponentModel.DataAnnotations;


namespace GiTinder.Models
{
    public class LoginItem
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
