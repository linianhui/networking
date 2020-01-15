using System;
using FluentAssertions;
using Xunit;
using Networking.Model.Internet;

namespace Networking.Model.Tests.InternetTests.IPv4PacketTests
{
    public class IPv4Packet_Property_FlagMF_Test
    {
        [Fact]
        public void Get()
        {
            var ipv4Packet = new IPv4Packet
            {
                Bytes = new Byte[32]
            };
            ipv4Packet.SetByte(6, 0b_0010_0000);

            ipv4Packet.FlagMF.Should().Be(true);
        }

        [Fact]
        public void Set()
        {
            var ipv4Packet = new IPv4Packet
            {
                Bytes = new Byte[32]
            };

            ipv4Packet.FlagMF = true;
            ipv4Packet.GetByte(6).Should().Be(0b_0010_0000);

            ipv4Packet.FlagMF = false;
            ipv4Packet.GetByte(6).Should().Be(0b_0000_0000);
        }
    }
}
