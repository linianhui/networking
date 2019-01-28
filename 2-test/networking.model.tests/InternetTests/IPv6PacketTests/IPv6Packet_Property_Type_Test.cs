using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPv6PacketTests
{
    public class IPv6Packet_Property_Type_Test
    {
        [Fact]
        public void Get()
        {
            var ipv6Packet = new IPv6Packet
            {
                Bytes = new Byte[40]
            };
            ipv6Packet[6] = 0x3a;

            ipv6Packet.Type.Should().Be(IPPacketType.ICMPV6);
        }

        [Fact]
        public void Set()
        {
            var ipv6Packet = new IPv6Packet
            {
                Bytes = new Byte[40]
            };

            ipv6Packet.Type = IPPacketType.ICMPV6;

            ipv6Packet.Type.Should().Be(IPPacketType.ICMPV6);
        }
    }
}
