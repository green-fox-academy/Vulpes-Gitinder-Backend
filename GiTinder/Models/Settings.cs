using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class Settings

    {
        [Key]
        public int Id { get; set; }

        //I tried to have the following params in [Required(params)]but I got error 
        //You have an error in your SQL syntax; check the manual that corresponds to your 
        //MySQL server version for the right syntax 
        //to use near 'CONSTRAINT `FK_Settings_Users_UserName`' at line 1
        //(AllowEmptyStrings = false, ErrorMessage = "User name is required")
        [Required]
        [MinLength(1)]
        [ForeignKey("User.UserName")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Enable notification information is required")]
        public bool EnableNotification { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Maximum distance  information (in km) is required")]
        [Range(10, 160)]
        public int MaxDistanceInKm { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Information on preferred languages is required")]
        [MinLength(2)]
        public string PreferredLanguages { get; set; }

        public Settings()
        {
            EnableNotification = true;
            MaxDistanceInKm = 160;
            PreferredLanguages = "English";
        }

        public Settings(string UserName, bool EnableNotification,
            int MaxDistanceInKm, string PreferredLanguages)
        {
        }

    }
}








