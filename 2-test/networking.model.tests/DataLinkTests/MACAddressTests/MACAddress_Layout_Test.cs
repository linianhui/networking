using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.MACAddressTests
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
