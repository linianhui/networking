using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPv4PacketTests
{
    public class IPv4Packet_Property_PacketType_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] {(Byte)0x01, IPPacketType.ICMP},
            new Object[] {(Byte)0x02, IPPacketType.IGMP},
            new Object[] {(Byte)0x06, IPPacketType.TCP},
            new Object[] {(Byte)0x11, IPPacketType.UDP}
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte input, IPPacketType expected)
        {
            var ipv4Packet = new IPv4Packet
            {
                Bytes = new Byte[32]
            };

            ipv4Packet[9] = input;

            ipv4Packet.PacketType.Should().Be(expected);
        }

        [Theory]
        [InlineData(IPPacketType.ICMP)]
        [InlineData(IPPacketType.IGMP)]
        [InlineData(IPPacketType.TCP)]
        [InlineData(IPPacketType.UDP)]
        public void Set(IPPacketType input)
        {
            var ipv4Packet = new IPv4Packet
            {
                Bytes = new Byte[32]
            };

            ipv4Packet.PacketType = input;
            ipv4Packet.PacketType.Should().Be(input);
        }
    }
}
