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
        public string UserName { get; set; }

        public bool EnableNotification { get; set; }

        public int MaxDistanceInMeters  { get; set; }

        public string PrefferedLanguages { get; set; }

        public Settings()
        {
            EnableNotification = true;
            MaxDistanceInMeters = 10000;
            PrefferedLanguages = "English" ;
        }

}
}








