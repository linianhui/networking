using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPv6PacketTests
{
    public class IPv6Packet_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            IPv6Packet.Layout.VersionBegin.Should().Be(0);
            IPv6Packet.Layout.VersionBitIndex.Should().Be(0);
            IPv6Packet.Layout.VersionBitLength.Should().Be(4);

            IPv6Packet.Layout.TrafficClassBegin.Should().Be(0);
            IPv6Packet.Layout.TrafficClassBitIndex.Should().Be(4);
            IPv6Packet.Layout.TrafficClassBitLength.Should().Be(8);

            IPv6Packet.Layout.FlowLabelBegin.Should().Be(0);
            IPv6Packet.Layout.FlowLabelBitIndex.Should().Be(12);
            IPv6Packet.Layout.FlowLabelBitLength.Should().Be(20);

            IPv6Packet.Layout.PayloadLengthBegin.Should().Be(4);
            IPv6Packet.Layout.PayloadLengthEnd.Should().Be(6);

            IPv6Packet.Layout.NextHeaderBegin.Should().Be(6);
            IPv6Packet.Layout.NextHeaderEnd.Should().Be(7);

            IPv6Packet.Layout.HopLimitBegin.Should().Be(7);
            IPv6Packet.Layout.HopLimitEnd.Should().Be(8);

            IPv6Packet.Layout.SourceIPAddressBegin.Should().Be(8);
            IPv6Packet.Layout.SourceIPAddressEnd.Should().Be(24);

            IPv6Packet.Layout.DestinationIPAddressBegin.Should().Be(24);
            IPv6Packet.Layout.DestinationIPAddressEnd.Should().Be(40);
        }
    }
}
