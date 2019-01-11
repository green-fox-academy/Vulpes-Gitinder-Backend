using GiTinder.Controllers;
using GiTinder.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace GiTinder.Tests.Models
{
    public class SettingsTest
    {
        [Fact]
        public void CanCreateSettingsWithValidUserName()
        {
            var settings = SettingsFactory.CreateSettingsWithValidUserName();
            Assert.True(ValidateModel(settings).Count == 0);
        }

        [Fact]
        public void CannotCreateSettingsWithInvalidEmptyStringUserName()
        {
            var settings = SettingsFactory.CreateSettingWithEmptyStringUserName();
            Assert.True(ValidateModel(settings).Count == 1);
        }
               
        [Fact]
        public void CannotCreateSettingsWithInvalidMaxDistance170Km()
        {
            var settings = SettingsFactory.CreateSettingsWithMaxDistance170Km();
            Assert.True(ValidateModel(settings).Count == 1);
        }

        [Fact]
        public void CannotCreateSettingsWithInvalidMaxDistance9Km()
        {
            var settings = SettingsFactory.CreateSettingsWithMaxDistance9Km();
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



