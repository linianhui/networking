using FluentAssertions;
using Xunit;

namespace Networking.Model.DataLink
{
    public class EthernetFrameLayoutTest
    {
        [Fact]
        public void layout_is_right()
        {
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
