using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPv6PacketTests
{
    public class IPv6Packet_Property_NextHeader_Test
    {
        [Fact]
        public void Get()
        {
            var ipv6Packet = new IPv6Packet
            {
                Bytes = new Byte[40]
            };
            ipv6Packet.SetByte(6, 0x00);

            ipv6Packet.NextHeader.Should().Be(0);
        }

        [Fact]
        public void Set()
        {
            var ipv6Packet = new IPv6Packet
            {
                Bytes = new Byte[40]
            };

            ipv6Packet.NextHeader = 0;

            ipv6Packet.NextHeader.Should().Be(0);
        }
    }
}
