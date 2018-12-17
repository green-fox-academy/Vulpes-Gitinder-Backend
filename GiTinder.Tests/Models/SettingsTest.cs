using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GiTinder.Tests.Models
{
    public class SettingsTest
    {

        [Fact]
        public void CanCreateSettingsWithValidUserName()
        {
            var testSettings = new SettingsTest();
            Assert.False(testSettings == null);
        }

        [Fact]
        public void CanCreateSettingsWithGivenNameAndDefaultSettings()
        {
            //var testSettings = new SettingsFactory();
            var settingsFactory = new SettingsFactory();
            var testSettings = settingsFactory.CreateUserWithGivenUserNameAndDefaultSettings();

            //CreateDefaultUserWithGivenUserName();

            Assert.True(testSettings.UserName == "Test Tomek");
            Assert.True(testSettings.EnableNotification == true);
            Assert.True(testSettings.MaxDistanceInMeters == 10000);
            Assert.False(testSettings.MaxDistanceInMeters == 1);
        }

    }
}
