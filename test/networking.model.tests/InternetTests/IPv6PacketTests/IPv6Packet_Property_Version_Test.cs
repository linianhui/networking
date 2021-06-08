using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPv6PacketTests
{
    public class IPv6Packet_Property_Version_Test
    {
        [Fact]
        public void Get()
        {
            var ipv6Packet = new IPv6Packet
            {
                Bytes = new Byte[60]
            };
            ipv6Packet.SetByte(0, 0x65);

            ipv6Packet.Version.Should().Be(IPVersion.IPv6);
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
            var ipv6Packet = new IPv6Packet
            {
                Bytes = new Byte[40]
            };
            ipv6Packet.SetByte(0, 0x05);

            ipv6Packet.Version = (IPVersion)input;

            ipv6Packet.GetByte(0).Should().Be(0x65);
            ipv6Packet.Version.Should().Be(IPVersion.IPv6);
        }
    }
}
