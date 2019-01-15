using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;

namespace GiTinder.Tests.Models
{
    public class SwipeTests
    {
        [Fact]
        public void SwipeWithNullUserIdIsNotValid()
        {
            var swipe = SwipeFactory.CreateSwipeWithNullUserId();
            Assert.True(ValidateModel(swipe).Count == 1);
        }

        [Fact]
        public void SwipeWithNullSwipedUserIdIsNotValid()
        {
            var swipe = SwipeFactory.CreateSwipeWithNullSwipedUserId();
            Assert.True(ValidateModel(swipe).Count == 1);
        }

        [Fact]
        public void SwipeWithNullTimeStampIsNotValid()
        {
            var swipe = SwipeFactory.CreateSwipeWithNullTimestamp();
            Assert.True(ValidateModel(swipe).Count == 1);
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
