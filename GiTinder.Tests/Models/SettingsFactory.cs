using GiTinder.Models;
using System.Collections.Generic;

namespace GiTinder.Tests.Models
{
    class SettingsFactory
    {
        public static Settings CreateSettingsWithValidUserName()
        {
            var settings = new Settings("Mock Filip", true, true, 160);
            return settings;
        }

        public static Settings CreateSettingWithEmptyStringUserName()
        {
            var settings = CreateSettingsWithValidUserName();
            settings.UserName = "";
            return settings;
        }

        public static Settings CreateSettingsWithNullUserName()
        {
            var settings = CreateSettingsWithValidUserName();
            settings.UserName = null;
            return settings;
        }

        public static Settings CreateSettingsWithMaxDistance170Km()
        {
            var settings = CreateSettingsWithValidUserName();
            settings.MaxDistanceInKm = 170;
            return settings;
        }

        public static Settings CreateSettingsWithMaxDistance9Km()
        {
            var settings = CreateSettingsWithValidUserName();
            settings.MaxDistanceInKm = 9;
            return settings;
        }

        //public static Settings 

    }
}

