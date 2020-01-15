using FluentAssertions;
using Xunit;

namespace Networking.Tests.IPAddressTests
{
    public class IPAddress_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            IPAddress.Layout.V4Length.Should().Be(4);
            IPAddress.Layout.V6Length.Should().Be(16);
        }
    }
}
