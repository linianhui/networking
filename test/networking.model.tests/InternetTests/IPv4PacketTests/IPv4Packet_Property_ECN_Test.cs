using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPv4PacketTests
{
    public class IPv4Packet_Property_ECN_Test
    {
        [Fact]
        public void Get()
        {
            var ipv4Packet = new IPv4Packet
            {
                Bytes = new Byte[40]
            };
            ipv4Packet.SetByte(1, 0b_010110_01);

            ipv4Packet.ECN.Should().Be(0b_01);
        }

        [Fact]
        public void Set()
        {
            var ipv4Packet = new IPv4Packet
            {
                Bytes = new Byte[40]
            };

            ipv4Packet.SetByte(1, 0b_010110_00);
            ipv4Packet.ECN = 0b_101110_11;

            ipv4Packet.GetByte(1).Should().Be(0b_010110_11);
        }
    }
}
