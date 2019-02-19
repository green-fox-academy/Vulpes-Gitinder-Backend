using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;

namespace GiTinder.Tests.Models
{
    public class MessageTests
    {
        [Fact]
        public void ValidMessageIsHasNoErrors()
        {
            var message = MessageFactory.CreateValidMessage();
            Assert.True(ValidateModel(message).Count == 0);
        }

        [Fact]
        public void MessageWithNullFromHasOneError()
        {
            var message = MessageFactory.CreateValidMessage();
            message.From = null;
            Assert.True(ValidateModel(message).Count == 1);
        }

        [Fact]
        public void MessageWithNullToHasOneError()
        {
            var message = MessageFactory.CreateValidMessage();
            message.To = null;
            Assert.True(ValidateModel(message).Count == 1);
        }

        [Fact]
        public void MessageWithNullContentHasOneError()
        {
            var message = MessageFactory.CreateValidMessage();
            message.Content = null;
            Assert.True(ValidateModel(message).Count == 1);
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
