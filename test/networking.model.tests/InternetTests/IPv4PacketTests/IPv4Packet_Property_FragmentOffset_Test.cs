using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPv4PacketTests
{
    public class IPv4Packet_Property_FragmentOffset_Test
    {
        [Fact]
        public void Get()
        {
            var ipv4Packet = new IPv4Packet
            {
                Bytes = new Byte[40]
            };
            ipv4Packet.SetByte(6, 0b_0101_1011);
            ipv4Packet.SetByte(7, 0b_0101_1011);

            ipv4Packet.FragmentOffset.Should().Be(0b_1_1011_0101_1011);
        }

        [Fact]
        public void Set()
        {
            var ipv4Packet = new IPv4Packet
            {
                Bytes = new Byte[40]
            };

            ipv4Packet.SetByte(6, 0b_1010_0000);
            ipv4Packet.FragmentOffset = 0b_1_1011_0101_1011;

            ipv4Packet.GetByte(6).Should().Be(0b_1011_1011);
            ipv4Packet.GetByte(7).Should().Be(0b_0101_1011);
        }
    }
}
