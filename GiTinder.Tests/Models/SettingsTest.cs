//using GiTinder.Controllers;
//using GiTinder.Data;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using Xunit;

//namespace GiTinder.Tests.Models
//{
//    public class SettingsTest
//    {
//        [Fact]
//        public void CanCreateSettingsWithValidUserName()
//        {
//            var settings = SettingsFactory.CreateSettingsWithValidUserName();
//            Assert.True(ValidateModel(settings).Count == 0);
//        }

//        [Fact]
//        public void CannotCreateSettingsWithInvalidEmptyStringUserName()
//        {
//            var settings = SettingsFactory.AttemptToCreateSettingsWithInvalidUserName();
//            Assert.True(ValidateModel(settings).Count == 1);
//        }

//        [Fact]
//        public void CannotCreateSettingsWithNullUserName()
//        {
//            var settings = SettingsFactory.AttemptToCreateSettingsWithInvalidUserName();
//            Assert.True(ValidateModel(settings).Count == 1);
//        }

//        [Fact]
//        public void CannotCreateSettingsWithInvalidMaxDistance170Km()
//        {
//            var settings = SettingsFactory.AttemptToCreateSettingsWithInvalidDistance170Km();
//            Assert.True(ValidateModel(settings).Count == 1);
//        }

//        [Fact]
//        public void CannotCreateSettingsWithInvalidMaxDistance9Km()
//        {
//            var settings = SettingsFactory.AttemptToCreateSettingsWithInvalidDistance9Km();
//            Assert.True(ValidateModel(settings).Count == 1);
//        }

//        private IList<ValidationResult> ValidateModel(object model)
//        {
//            var validationResults = new List<ValidationResult>();
//            var ctx = new ValidationContext(model, null, null);
//            Validator.TryValidateObject(model, ctx, validationResults, true);
//            return validationResults;
//        }

//        [Fact]
//        public void GetReturnsSettings()
//        {
//            // Arrange
//            var controller = new SettingsController(repository);
//            controller.Request = new HttpRequestMessage();
//            controller.Configuration = new HttpConfiguration();

//            // Act
//            var response = controller.Get(10);

//            // Assert
//            Product product;
//            Assert.IsTrue(response.TryGetContentValue<Product>(out product));
//            Assert.AreEqual(10, product.Id);

//            SettingsController settingsController = new SettingsController(context, testSetting);
//            var testSettings = new SettingsController.settings();
//            Assert.True(ValidateModel(settings).Count == 0);
//        }

//    }
//}



