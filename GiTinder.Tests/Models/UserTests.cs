﻿using Xunit;
using System;
using System.Collections.Generic;
using System.Text;
using GiTinder.Models;
using System.ComponentModel.DataAnnotations;

namespace GiTinder.Tests.Models
{
    public class UserTests
    {
        [Fact]
        public void CanSetUserNameWithString()
        {
            var user = new User("Michel");
            Assert.Equal("Michel", user.Username);
        }

        [Fact]
        public void UserWithNullUserNameIsNotValid()
        {
            var user = UserFactory.CreateUserWithNullUserName();
            Assert.True(ValidateModel(user).Count == 1);
        }

        [Fact]
        public void UserWithNullUserTokenIsNotValid()
        {
            var user = UserFactory.CreateUserWithNullUserToken();
            Assert.True(ValidateModel(user).Count == 1);
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
