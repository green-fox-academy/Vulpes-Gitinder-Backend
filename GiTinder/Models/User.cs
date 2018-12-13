using System.ComponentModel.DataAnnotations;

namespace GiTinder.Models
{
    public class User
    {
        
        [Key, Required]
        public string UserName { get; set; }
        public int ReposCount { get; set; }
        [Required]
        public string UserToken { get; set; }
    }
}
