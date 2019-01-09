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

        public User()
        {
            //UserSettings.EnableNotification = true;
            //UserSettings.EnableBackgroundSync = true;
            //UserSettings.MaxDistanceInKm = 10;
            //UserSettings.PreferredLanguagesNames = null;
        }
    }
}
