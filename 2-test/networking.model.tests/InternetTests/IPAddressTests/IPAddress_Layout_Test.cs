using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPAddressTests
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
