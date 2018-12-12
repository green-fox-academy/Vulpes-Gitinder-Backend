using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class Settings
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public bool SettingsAreValid { get; set; }
           
        //        Entity is created belonging to a user
        //User model updated
        //Repository is created
        //Database migration is created
        //Only valid settings can be saved in the database
        //Test for checking validity of the settings

        public Settings()
        {

        }

    }
}
