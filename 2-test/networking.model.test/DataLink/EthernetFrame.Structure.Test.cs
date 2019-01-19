using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Test.DataLink
{
    public class EthernetFrameStructureTest
    {
        [Fact]
        public void Structure_is_right()
        {
            EthernetFrame.Structure.MACAddressLength.Should().Be(6);

            EthernetFrame.Structure.DestinationMACAddressBegin.Should().Be(0);
            EthernetFrame.Structure.DestinationMACAddressEnd.Should().Be(6);

            EthernetFrame.Structure.SourceMACAddressBegin.Should().Be(6);
            EthernetFrame.Structure.SourceMACAddressEnd.Should().Be(12);

            EthernetFrame.Structure.TypeLength.Should().Be(2);
            EthernetFrame.Structure.TypeBegin.Should().Be(12);
            EthernetFrame.Structure.TypeEnd.Should().Be(14);

            EthernetFrame.Structure.HeaderLength.Should().Be(14);
        }
    }
}
