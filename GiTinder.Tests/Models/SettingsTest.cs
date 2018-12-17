using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace GiTinder.Tests.Models
{
    public class SettingsTest
    {

        [Fact]
        public void CanCreateSettingsWithNullUserName()
        {
            var settings = SettingsFactory.CreateSettings();
            Assert.True(settings.UserName == null);
        }

        [Fact]
        public void CanSetUserNameWithString()
        {
            var settings = SettingsFactory.CreateSettings();
            settings.UserName = "Pablos";
            Assert.Equal("Pablos", settings.UserName);
        }





        [Fact]
        public void CanCreateSettingsWithGivenNameAndDefaultSettings()
        {

            var testSettings = SettingsFactory.CreateSettingsWithGivenUserNameTest_TomekAndDefaultSettings();


            Assert.True(testSettings.UserName == "Test_Tomek");
            Assert.True(testSettings.EnableNotification == true);
            Assert.True(testSettings.MaxDistanceInKm == 160);

            Assert.False(testSettings.MaxDistanceInKm == 1);
            Assert.True(testSettings.PreferredLanguages == "English");
            Assert.False(testSettings.PreferredLanguages == "Czech");
            //  Assert.True(testSettings.PreferredLanguages == "Czech");


        }


        //Why this test does not pass?

        [Fact]
        public void SettingsWithNullUserNameIsNotValid()
        {
            var settings = SettingsFactory.CreateSettingsWithNullUserName();
            Assert.True(ValidateModel(settings).Count == 1);
        }


        //Why this test does not pass?
        [Fact]
        public void SettingsWithInvalidUserName()
        {
            var settings = SettingsFactory.CreateSettingsWithInValidUserName();
            Assert.True(ValidateModel(settings).Count == 1);
        }

        [Fact]
        public void SettingsWithMaxDistance170KmIsNotValid()
        {
            var settings = SettingsFactory.CreateSettingsWithDistance170Km();
            Assert.True(ValidateModel(settings).Count == 1);
        }

        [Fact]
        public void SettingsWithMaxDistance9KmIsNotValid()
        {
            var settings = SettingsFactory.CreateSettingsWithDistance9Km();
            Assert.True(ValidateModel(settings).Count == 1);
        }

    

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }


    }
}



