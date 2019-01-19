using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Test.DataLink
{
    public class EthernetFrameLayoutTest
    {
        [Fact]
        public void Structure_is_right()
        {
            EthernetFrame.Layout.MACAddressLength.Should().Be(6);

            EthernetFrame.Layout.DestinationMACAddressBegin.Should().Be(0);
            EthernetFrame.Layout.DestinationMACAddressEnd.Should().Be(6);

            EthernetFrame.Layout.SourceMACAddressBegin.Should().Be(6);
            EthernetFrame.Layout.SourceMACAddressEnd.Should().Be(12);

            EthernetFrame.Layout.TypeLength.Should().Be(2);
            EthernetFrame.Layout.TypeBegin.Should().Be(12);
            EthernetFrame.Layout.TypeEnd.Should().Be(14);

            EthernetFrame.Layout.HeaderLength.Should().Be(14);
        }
    }
}
