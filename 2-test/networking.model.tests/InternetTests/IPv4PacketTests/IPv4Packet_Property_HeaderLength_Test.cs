using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPv4PacketTests
{
    public class IPv4Packet_Property_HeaderLength_Test
    {
        [Fact]
        public void Get()
        {
            var ipv4Packet = new IPv4Packet
            {
                Bytes = new Byte[32]
            };
            ipv4Packet.SetByte(0, 0x45);

            ipv4Packet.Version.Should().Be(IPVersion.IPv4);
            ipv4Packet.HeaderLength.Should().Be(5);
        }

        [Theory]
        [InlineData(0x06)]
        [InlineData(0x16)]
        [InlineData(0x26)]
        [InlineData(0x36)]
        [InlineData(0x46)]
        [InlineData(0x56)]
        [InlineData(0x66)]
        [InlineData(0x76)]
        [InlineData(0x86)]
        [InlineData(0x96)]
        [InlineData(0xA6)]
        [InlineData(0xB6)]
        [InlineData(0xC6)]
        [InlineData(0xD6)]
        [InlineData(0xE6)]
        [InlineData(0xF6)]
        public void Set(Byte input)
        {
            var ipv4Packet = new IPv4Packet
            {
                Bytes = new Byte[32]
            };
            ipv4Packet.SetByte(0, 0x40);

            ipv4Packet.HeaderLength = input;

            ipv4Packet.GetByte(0).Should().Be(0x46);
            ipv4Packet.Version.Should().Be(IPVersion.IPv4);
            ipv4Packet.HeaderLength.Should().Be(6);
        }
    }
}
