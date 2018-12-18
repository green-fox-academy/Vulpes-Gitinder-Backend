//using GiTinder.Models;

//namespace GiTinder.Tests.Models
//{
//    class SettingsFactory
//    {
//        public static Settings CreateSettingsWithValidUserName()
//        {
//            return new Settings("Filip Eager", true, 160, "English")
//            {
//            };
//        }

//        public static Settings CreateSettingsWithInValidUserName()
//        {
//            return new Settings("", true, 160, "English")
//            {
//            };
//        }

//        public static Settings CreateSettingsWithGivenUserNameTest_TomekAndDefaultSettings()
//        {
//            return new Settings("Test_Tomek", true, 160, "English")
//            {
//            };
//        }

//        public static Settings CreateSettingsWithNullUserName()
//        {
//            var settings = CreateSettingsWithValidUserName();
//            settings.UserName = null;
//            return settings;
//        }

//        public static Settings CreateSettingsWithDistance170Km()
//        {
//            var settings = CreateSettingsWithValidUserName();
//            settings.MaxDistanceInKm = 170;
//            return settings;
//        }

//        public static Settings CreateSettingsWithDistance9Km()
//        {
//            var settings = CreateSettingsWithValidUserName();
//            settings.MaxDistanceInKm = 9;
//            return settings;
//        }
//    }
//}

