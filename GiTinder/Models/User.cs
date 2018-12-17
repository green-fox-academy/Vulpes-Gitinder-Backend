using System.ComponentModel.DataAnnotations;



namespace GiTinder.Models
{
    public class User
    {
                         

        
        [Key]
        [Required]
        [MinLength(1)]
        public string UserName { get; set; }

        public int ReposCount { get; set; }

        [Required]
        public string UserToken { get; set; }

        public Settings UserSettings { get; set; }

    }
}
