using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.CoAPTests
{
    public class CoAP_Constant_Test
    {
        [Fact]
        public void Constant()
        {
            CoAP.ServerPort.Should().Be(5683);
        }
    }
}
