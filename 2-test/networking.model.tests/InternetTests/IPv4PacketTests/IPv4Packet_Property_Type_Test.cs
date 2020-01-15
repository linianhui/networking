using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPv4PacketTests
{
    public class IPv4Packet_Property_Type_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { (Byte)0x01, IPPacketType.ICMPv4 },
            new Object[] { (Byte)0x02, IPPacketType.IGMP },
            new Object[] { (Byte)0x06, IPPacketType.TCP },
            new Object[] { (Byte)0x11, IPPacketType.UDP },
            new Object[] { (Byte)0x3a, IPPacketType.ICMPV6 },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte input, IPPacketType expected)
        {
            var ipv4Packet = new IPv4Packet
            {
                Bytes = new Byte[32]
            };

            ipv4Packet.SetByte(9, input);

            ipv4Packet.Type.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Set(Byte expected, IPPacketType input)
        {
            var ipv4Packet = new IPv4Packet
            {
                Bytes = new Byte[32]
            };

            ipv4Packet.Type = input;

            ipv4Packet.GetByte(9).Should().Be(expected);
            ipv4Packet.Type.Should().Be(input);
        }
    }
}
