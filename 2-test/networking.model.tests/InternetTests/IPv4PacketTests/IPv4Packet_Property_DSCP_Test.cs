using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPv4PacketTests
{
    public class IPv4Packet_Property_DSCP_Test
    {
        [Fact]
        public void Get()
        {
            var ipv4Packet = new IPv4Packet
            {
                Bytes = new Byte[40]
            };
            ipv4Packet.SetByte(1, 0b_0101_1011);

            ipv4Packet.DSCP.Should().Be(0b_0101_10);
        }

        [Fact]
        public void Set()
        {
            var ipv4Packet = new IPv4Packet
            {
                Bytes = new Byte[40]
            };

            ipv4Packet.SetByte(1, 0b_0101_1011);
            ipv4Packet.DSCP = 0b_1101_1010;

            ipv4Packet.GetByte(1).Should().Be(0b_01_1010_11);
        }
    }
}
