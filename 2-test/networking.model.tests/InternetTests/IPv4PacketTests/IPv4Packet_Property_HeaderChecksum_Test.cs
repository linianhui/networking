using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPv4PacketTests
{
    public class IPv4Packet_Property_HeaderChecksum_Test
    {
        [Fact]
        public void Get()
        {
            var ipv4Packet = new IPv4Packet
            {
                Bytes = new Byte[32]
            };

            ipv4Packet.SetBytes(10, 2, new Byte[] { 0x99, 0xA4 });

            ipv4Packet.HeaderChecksum.Should().Be(39332);
        }

        [Fact]
        public void Set()
        {
            var ipv4Packet = new IPv4Packet
            {
                Bytes = new Byte[32]
            };

            ipv4Packet.HeaderChecksum = 0x99A4;

            ipv4Packet.HeaderChecksum.Should().Be(39332);
        }
    }
}
