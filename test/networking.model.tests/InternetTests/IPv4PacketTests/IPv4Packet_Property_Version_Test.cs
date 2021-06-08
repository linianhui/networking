using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPv4PacketTests
{
    public class IPv4Packet_Property_Version_Test
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
        [InlineData(0x04)]
        [InlineData(0x14)]
        [InlineData(0x24)]
        [InlineData(0x34)]
        [InlineData(0x44)]
        [InlineData(0x54)]
        [InlineData(0x64)]
        [InlineData(0x74)]
        [InlineData(0x84)]
        [InlineData(0x94)]
        [InlineData(0xA4)]
        [InlineData(0xB4)]
        [InlineData(0xC4)]
        [InlineData(0xD4)]
        [InlineData(0xE4)]
        [InlineData(0xF4)]
        public void Set(Byte input)
        {
            var ipv4Packet = new IPv4Packet
            {
                Bytes = new Byte[32]
            };
            ipv4Packet.SetByte(0, 0x05);

            ipv4Packet.Version = (IPVersion)input;

            ipv4Packet.GetByte(0).Should().Be(0x45);
            ipv4Packet.Version.Should().Be(IPVersion.IPv4);
            ipv4Packet.HeaderLength.Should().Be(5);
        }
    }
}
