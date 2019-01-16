using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;

namespace GiTinder.Tests.Models
{
    public class MatchTests
    {
        [Fact]
        public void CreateMatchWithValidUsernames()
        {
            var match = MatchFactoryForTests.CreateValidMatch();
            Assert.True(ValidateModel(match).Count == 0);
        }

        [Fact]
        public void FailToCreateMatchWithEmptyUsername_1()
        {
            var match = MatchFactoryForTests.CreateMatchWithEmptyUsername_1();
            Assert.True(ValidateModel(match).Count == 1);
        }

        [Fact]
        public void FailToCreateMatchWithEmptyUsername_2()
        {
            var match = MatchFactoryForTests.CreateMatchWithEmptyUsername_2();
            Assert.True(ValidateModel(match).Count == 1);
        }

        [Fact]
        public void FailToCreateMatchWithNullUsername_1()
        {
            var match = MatchFactoryForTests.CreateMatchWithNullUsername_1();
            Assert.True(ValidateModel(match).Count == 1);
        }

        [Fact]
        public void FailToCreateMatchWithNullUsername_2()
        {
            var match = MatchFactoryForTests.CreateMatchWithNullUsername_2();
            Assert.True(ValidateModel(match).Count == 1);
        }

        [Fact]
        public void CreatingMatchAssignsValueToTimestamp()
        {
            var match = MatchFactoryForTests.CreateMatchWithNullUsername_1();
            Assert.True(match.Timestamp != null);
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
