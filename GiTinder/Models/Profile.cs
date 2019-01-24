using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Models
{
    public class Profile
    {
        [Key]
        //[Required]
        [MinLength(1)]
        [JsonProperty]
        public string UserToken { get; set; }

 
        public Profile(string usertoken)
        {
            this.UserToken = usertoken;
          
        }

    }
}
