using System.ComponentModel.DataAnnotations;

namespace GiTinder.Models
{
    public class User
    {
        
        [Key]
        [Required]
        public string UserName { get; set; }
        //{
        //    get            
        //    {
        //    return UserName;
        //    }
        //    set
        //    {
        //        if (!string.IsNullOrEmpty(value))
        //        {
        //            UserName = value;
        //        }
        //    }
        //}
        public int ReposCount { get; set; }
        [Required]
        public string UserToken { get; set; }
    }
}
