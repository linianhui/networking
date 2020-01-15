using FluentAssertions;
using Xunit;

namespace Networking.Tests.MACAddressTests
{
    public class MACAddress_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            MACAddress.Layout.Length.Should().Be(6);
        }
    }
}
