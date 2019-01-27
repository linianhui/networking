using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPv4PacketTests
{
    public class IPv4Packet_Test
    {
        [Fact]
        public void IPv4_Packet()
        {
            var ipv4Packet = new IPv4Packet
            {
                Bytes = new Byte[]
                {
                    0x46, 0xc0, 0x00, 0x20,
                    0xe7, 0xc8, 0x00, 0x00,
                    0x01, 0x02, 0x99, 0xa4,
                    0xc0, 0xa8, 0x02, 0x01,
                    0xe0, 0x00, 0x00, 0x01,
                    0x94, 0x04, 0x00, 0x00,
                    0x11, 0x64, 0xee, 0x9b,
                    0x00, 0x00, 0x00, 0x00
                }
            };

            ipv4Packet.Version.Should().Be(IPVersion.IPv4);
            ipv4Packet.HeaderLength.Should().Be(6);
            ipv4Packet.TotalLength.Should().Be(32);
            ipv4Packet.Id.Should().Be(59336);
            ipv4Packet.TTL.Should().Be(1);
            ipv4Packet.PacketType.Should().Be(IPPacketType.IGMP);
            ipv4Packet.HeaderChecksum.Should().Be(0x99A4);
            ipv4Packet.SourceIPAddress.ToString().Should().Be("192.168.2.1");
            ipv4Packet.DestinationIPAddress.ToString().Should().Be("224.0.0.1");
        }
    }
}
