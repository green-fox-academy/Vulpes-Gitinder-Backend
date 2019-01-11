using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace GiTinder.Models
{
    public class User
    {
        [Key]
        [Required]
        [MinLength(1)]
        public string Username { get; set; }

        public int ReposCount { get; set; }

        [Required]
        public string UserToken { get; set; }

        public Settings UserSettings { get; set; }

        public User()
        {
        }

        public User(string username)
        {
            Username = username;
        }

        public User(string Username, string UserToken, int ReposCount)
        {
            this.Username = Username;
            this.UserToken = UserToken;
            this.ReposCount = ReposCount;
            Settings defaultSettings = new Settings(Username, true, true, 10);
        }
    }
}
