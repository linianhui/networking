using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPv4PacketTests
{
    public class IPv4Packet_Property_Id_Test
    {
        [Fact]
        public void Get()
        {
            var ipv4Packet = new IPv4Packet
            {
                Bytes = new Byte[32]
            };

            ipv4Packet.SetBytes(4, 2, new Byte[] { 0x00, 0x7B });
            ipv4Packet.Id.Should().Be(123);
        }

        [Fact]
        public void Set()
        {
            var ipv4Packet = new IPv4Packet
            {
                Bytes = new Byte[32]
            };

            ipv4Packet.Id = 123;

            ipv4Packet.Id.Should().Be(123);
        }
    }
}
