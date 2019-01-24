using GiTinder.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;

namespace GiTinder.Tests.Models
{
    public class ProfileTest
    {
        [Fact]
        public void IsItTokenNull()
        {
            var usertoken = ProfileFactory.CreateTokenWithNullValue();
            Assert.False(ValidateModel(usertoken).Count == 0);
        }
        [Fact]
        public void CanSetTokenWithString()
        {
            var usertoken = new Profile("abc123");
            Assert.Equal("abc123",usertoken.UserToken);
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
