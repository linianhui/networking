using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.EthernetFrameTests
{
    public class EthernetFrame_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            EthernetFrame.Layout.DestinationMACAddressBegin.Should().Be(0);
            EthernetFrame.Layout.DestinationMACAddressEnd.Should().Be(6);

            EthernetFrame.Layout.SourceMACAddressBegin.Should().Be(6);
            EthernetFrame.Layout.SourceMACAddressEnd.Should().Be(12);

            EthernetFrame.Layout.TypeBegin.Should().Be(12);
            EthernetFrame.Layout.TypeEnd.Should().Be(14);

            EthernetFrame.Layout.HeaderLength.Should().Be(14);
        }
    }
}
