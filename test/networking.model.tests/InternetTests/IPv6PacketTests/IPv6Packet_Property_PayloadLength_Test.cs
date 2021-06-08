using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPv6PacketTests
{
    public class IPv6Packet_Property_PayloadLength_Test
    {
        [Fact]
        public void Get()
        {
            var ipv6Packet = new IPv6Packet
            {
                Bytes = new Byte[60]
            };

            ipv6Packet.SetBytes(4, 2, new Byte[] { 0x00, 0x10 });

            ipv6Packet.PayloadLength.Should().Be(16);
        }

        [Fact]
        public void Set()
        {
            var ipv6Packet = new IPv6Packet
            {
                Bytes = new Byte[60]
            };

            ipv6Packet.PayloadLength = 16;

            ipv6Packet.PayloadLength.Should().Be(16);
        }
    }
}
