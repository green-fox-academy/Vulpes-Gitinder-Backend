//using GiTinder.Models;
//using System.Collections.Generic;

//namespace GiTinder.Tests.Models
//{
//    class SettingsFactory
//    {
//        public static Settings CreateSettingsWithValidUserName()
//        {
//            var settings = new Settings("Mock Filip", true, true, 160);
//            return settings;
//        }

//        public static Settings AttemptToCreateSettingsWithInvalidUserName()
//           // CreateSettingWithInvalidUsername
//        {
//            var settings = CreateSettingsWithValidUserName();
//            settings.UserName = null;
//            return settings;
//        }

//        public static Settings CreateSettingsWithNullUserName()
//        {
//            return new Settings(null, true, true, 160, new List<Language> { new Language("Java"), new Language("C#") });
//        }

//        public static Settings AttemptToCreateSettingsWithInvalidDistance170Km()
//        {
//            return new Settings("Mock Filip", true, true, 170, new List<Language> { new Language("Java"), new Language("C#") });
//        }

//        public static Settings AttemptToCreateSettingsWithInvalidDistance9Km()
//        {
//            return new Settings("Mock Filip", true, true, 9, new List<Language> { new Language("Java"), new Language("C#") });
//        }

//        //public static Settings 

//    }
//}

