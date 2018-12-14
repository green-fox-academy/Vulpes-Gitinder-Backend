using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GiTinder.Tests.Models
{
    public class SettingsTest
    {

        [Fact]
        public void CanCreateSettings()
        {
            var testSettings = new SettingsTest();
            Assert.False(testSettings == null);
        }
        
        
    }
}
