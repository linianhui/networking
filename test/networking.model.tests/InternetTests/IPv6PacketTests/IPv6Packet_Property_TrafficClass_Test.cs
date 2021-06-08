using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPv6PacketTests
{
    public class IPv6Packet_Property_TrafficClass_Test
    {
        [Fact]
        public void Get()
        {
            var ipv6Packet = new IPv6Packet
            {
                Bytes = new Byte[40]
            };
            ipv6Packet.SetByte(0, 0b_0000_1010);
            ipv6Packet.SetByte(1, 0b_0101_0000);

            ipv6Packet.TrafficClass.Should().Be(0b_1010_0101);
        }

        [Fact]
        public void Set()
        {
            var ipv6Packet = new IPv6Packet
            {
                Bytes = new Byte[40]
            };

            ipv6Packet.TrafficClass = 0b_0101_1010;

            ipv6Packet.GetByte(0).Should().Be(0b_0101);
            ipv6Packet.GetByte(1).Should().Be(0b_1010_0000);
        }
    }
}
