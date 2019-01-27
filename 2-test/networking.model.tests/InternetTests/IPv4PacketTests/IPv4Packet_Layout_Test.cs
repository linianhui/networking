using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPv4PacketTests
{
    public class IPv4Packet_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            IPv4Packet.Layout.TotalLengthBegin.Should().Be(2);
            IPv4Packet.Layout.TotalLengthEnd.Should().Be(4);

            IPv4Packet.Layout.IdBegin.Should().Be(4);
            IPv4Packet.Layout.IdEnd.Should().Be(6);

            IPv4Packet.Layout.TTLBegin.Should().Be(8);
            IPv4Packet.Layout.TTLEnd.Should().Be(9);

            IPv4Packet.Layout.ProtocolBegin.Should().Be(9);
            IPv4Packet.Layout.ProtocolEnd.Should().Be(10);

            IPv4Packet.Layout.HeaderChecksumBegin.Should().Be(10);
            IPv4Packet.Layout.HeaderChecksumEnd.Should().Be(12);

            IPv4Packet.Layout.SourceIPAddressBegin.Should().Be(12);
            IPv4Packet.Layout.SourceIPAddressEnd.Should().Be(16);

            IPv4Packet.Layout.DestinationIPAddressBegin.Should().Be(16);
            IPv4Packet.Layout.DestinationIPAddressEnd.Should().Be(20);
        }
    }
}
