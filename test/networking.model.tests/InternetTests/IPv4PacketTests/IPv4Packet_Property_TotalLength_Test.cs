using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPv4PacketTests
{
    public class IPv4Packet_Property_TotalLength_Test
    {
        [Fact]
        public void Get()
        {
            var ipv4Packet = new IPv4Packet
            {
                Bytes = new Byte[32]
            };

            ipv4Packet.SetBytes(2, 2, new Byte[] { 0x00, 0x20 });

            ipv4Packet.TotalLength.Should().Be(32);
        }

        [Fact]
        public void Set()
        {
            var ipv4Packet = new IPv4Packet
            {
                Bytes = new Byte[32]
            };

            ipv4Packet.TotalLength = 32;

            ipv4Packet.TotalLength.Should().Be(32);
        }
    }
}
