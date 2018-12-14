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


    }
}








