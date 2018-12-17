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

        [ForeignKey("User.UserName")]
        [Required]
        [MinLength(2)]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public bool EnableNotification { get; set; }

        [Required]
        [Range(10,160)]
        public int MaxDistanceInKm { get; set; }

        [Required]
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








