using GiTinder.Models;

namespace GiTinder.Tests.Models
{
    class SettingsFactory

    {


        public static Settings CreateSettings()
        {
            return new Settings();
        }


        public static Settings CreateSettingsWithValidUserName()
        {

            return new Settings()
            {
                UserName = "Filip Eager",
            };


        }

        public static Settings CreateSettingsWithInValidUserName()
        {

            return new Settings()
            {
                UserName = "f",
            };


        }

        public static Settings CreateSettingsWithGivenUserNameTest_TomekAndDefaultSettings()
        {

            return new Settings()
            {
                UserName = "Test_Tomek"
            };
        }



        public static Settings CreateSettingsWithNullUserName()
        {
            var settings = CreateSettings();
            //  settings.UserName = null;
            return settings;
        }

        public static Settings CreateSettingsWithDistance170Km()
        {
            var settings = CreateSettings();
            settings.MaxDistanceInKm = 170;
            return settings;
        }

        public static Settings CreateSettingsWithDistance9Km()
        {
            var settings = CreateSettings();
            settings.MaxDistanceInKm = 9;
            return settings;
        }


    }


}

