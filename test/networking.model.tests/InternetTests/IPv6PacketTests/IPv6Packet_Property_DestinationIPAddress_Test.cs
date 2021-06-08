using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPv6PacketTests
{
    public class IPv6Packet_Property_DestinationIPAddress_Test
    {
        [Fact]
        public void Get()
        {
            var ipv6Packet = new IPv6Packet
            {
                Bytes = new Byte[40]
            };

            ipv6Packet.SetBytes(24, 16, new Byte[]
            {
                0xff, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02
            });

            ipv6Packet.DestinationIPAddress.ToString().Should().Be("FF:02:00:00:00:00:00:00:00:00:00:00:00:00:00:02");
        }

        [Fact]
        public void Set()
        {
            var ipv6Packet = new IPv6Packet
            {
                Bytes = new Byte[40]
            };

            ipv6Packet.DestinationIPAddress = new IPAddress
            {
                Bytes = new Byte[]
                {
                    0xff, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02
                }
            };

            ipv6Packet.DestinationIPAddress.ToString().Should().Be("FF:02:00:00:00:00:00:00:00:00:00:00:00:00:00:02");
        }
    }
}
