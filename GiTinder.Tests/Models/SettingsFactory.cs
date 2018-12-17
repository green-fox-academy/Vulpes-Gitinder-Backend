using GiTinder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiTinder.Tests.Models
{
    class SettingsFactory
    {

        


        public Settings CreateSettingsWithValidUserName()
        {

            return new Settings()
            {
                UserName = "Filip Eager",
            };


        }

        public Settings CreateUserWithGivenUserNameAndDefaultSettings()
        {

            return new Settings()
            {
                UserName = "Test Tomek"
            };
        }

    }
}
