using GiTinder.Controllers;
using Xunit;

namespace GiTinder.Tests.Controllers
{
    public class HelloWorldControllerTest
    {
        [Fact]
        public void HelloReturnsExpectedString()
        {
            var helloWorldController = new HelloWorldController();
            var expectedResult = "Hello, World! I am an endpoint that returns this string and does nothing else";
            var actualResult = helloWorldController.SayHello().Value;
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
