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
            IPv4Packet.Layout.VersionBegin.Should().Be(0);
            IPv4Packet.Layout.VersionEnd.Should().Be(1);
            IPv4Packet.Layout.VersionBitIndex.Should().Be(0);
            IPv4Packet.Layout.VersionBitLength.Should().Be(4);

            IPv4Packet.Layout.HeaderLengthBegin.Should().Be(0);
            IPv4Packet.Layout.HeaderLengthEnd.Should().Be(1);
            IPv4Packet.Layout.HeaderLengthBitIndex.Should().Be(4);
            IPv4Packet.Layout.HeaderLengthBitLength.Should().Be(4);

            IPv4Packet.Layout.DSCPBegin.Should().Be(1);
            IPv4Packet.Layout.DSCPBitIndex.Should().Be(0);
            IPv4Packet.Layout.DSCPBitLength.Should().Be(6);

            IPv4Packet.Layout.ECNBegin.Should().Be(1);
            IPv4Packet.Layout.ECNBitIndex.Should().Be(6);
            IPv4Packet.Layout.ECNBitLength.Should().Be(2);

            IPv4Packet.Layout.TotalLengthBegin.Should().Be(2);
            IPv4Packet.Layout.TotalLengthEnd.Should().Be(4);

            IPv4Packet.Layout.IdBegin.Should().Be(4);
            IPv4Packet.Layout.IdEnd.Should().Be(6);

            IPv4Packet.Layout.FlagsBegin.Should().Be(6);
            IPv4Packet.Layout.FlagsEnd.Should().Be(7);
            IPv4Packet.Layout.FlagsDFBitIndex.Should().Be(1);
            IPv4Packet.Layout.FlagsMFBitIndex.Should().Be(2);

            IPv4Packet.Layout.FragmentOffsetBegin.Should().Be(6);
            IPv4Packet.Layout.FragmentOffsetEnd.Should().Be(8);
            IPv4Packet.Layout.FragmentOffsetBitIndex.Should().Be(3);
            IPv4Packet.Layout.FragmentOffsetBitLength.Should().Be(13);

            IPv4Packet.Layout.TTLBegin.Should().Be(8);
            IPv4Packet.Layout.TTLEnd.Should().Be(9);

            IPv4Packet.Layout.TypeBegin.Should().Be(9);
            IPv4Packet.Layout.TypeEnd.Should().Be(10);

            IPv4Packet.Layout.HeaderChecksumBegin.Should().Be(10);
            IPv4Packet.Layout.HeaderChecksumEnd.Should().Be(12);

            IPv4Packet.Layout.SourceIPAddressBegin.Should().Be(12);
            IPv4Packet.Layout.SourceIPAddressEnd.Should().Be(16);

            IPv4Packet.Layout.DestinationIPAddressBegin.Should().Be(16);
            IPv4Packet.Layout.DestinationIPAddressEnd.Should().Be(20);
        }
    }
}
