//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using Xunit;

//namespace GiTinder.Tests.Models
//{
//    public class SettingsTest
//    {

//        ///
//        [Fact]
//        public void CanCreateSettings()
//        {
//            var settings = SettingsFactory.CreateSettingsWithValidUserName();
//            Assert.False(ValidateModel(settings).Count == 1);
//        }

//        [Fact]
//        public void CanCreateSettingsWithInvalidUserName()
//        {
//            var settings = SettingsFactory.CreateSettingsWithInValidUserName();
//            Assert.True(ValidateModel(settings).Count == 1);
//        }
//        ///


//        [Fact]
//        public void CanCreateSettingsWithGivenNameAndDefaultSettings()
//        {
//            var testSettings = SettingsFactory.CreateSettingsWithGivenUserNameTest_TomekAndDefaultSettings();
//            Assert.False(ValidateModel(testSettings).Count == 1);

//            //Assert.True(testSettings.UserName == "Test_Tomek");
//            //Assert.True(testSettings.EnableNotification == true);
//            //Assert.True(testSettings.MaxDistanceInKm == 160);

//            //Assert.False(testSettings.MaxDistanceInKm == 1);
//            //Assert.True(testSettings.PreferredLanguages == "English");
//        }

//        //Why this test does not pass?

//        [Fact]
//        public void SettingsWithNullUserNameIsNotValid()
//        {
//            var settings = SettingsFactory.CreateSettingsWithNullUserName();
//            Assert.True(ValidateModel(settings).Count == 1);
//        }

//        //Why this test does not pass?
//        [Fact]
//        public void SettingsWithInvalidUserName()
//        {
//            var settings = SettingsFactory.CreateSettingsWithInValidUserName();
//            Assert.True(ValidateModel(settings).Count == 1);
//        }

//        [Fact]
//        public void SettingsWithMaxDistance170KmAreNotValid()
//        {
//            var settings = SettingsFactory.CreateSettingsWithDistance170Km();
//            Assert.True(ValidateModel(settings).Count == 1);
//        }

//        [Fact]
//        public void SettingsWithMaxDistance9KmAreNotValid()
//        {
//            var settings = SettingsFactory.CreateSettingsWithDistance9Km();
//            Assert.True(ValidateModel(settings).Count == 1);
//        }

//        private IList<ValidationResult> ValidateModel(object model)
//        {
//            var validationResults = new List<ValidationResult>();
//            var ctx = new ValidationContext(model, null, null);
//            Validator.TryValidateObject(model, ctx, validationResults, true);
//            return validationResults;
//        }
//    }
//}



