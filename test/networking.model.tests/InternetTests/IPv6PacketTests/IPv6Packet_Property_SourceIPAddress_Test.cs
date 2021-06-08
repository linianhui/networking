using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPv6PacketTests
{
    public class IPv6Packet_Property_SourceIPAddress_Test
    {
        [Fact]
        public void Get()
        {
            var ipv6Packet = new IPv6Packet
            {
                Bytes = new Byte[40]
            };

            ipv6Packet.SetBytes(8, 16, new Byte[]
            {
                0xfe, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x15, 0x5d, 0xff, 0xfe, 0x02, 0x02, 0x45
            });

            ipv6Packet.SourceIPAddress.ToString().Should().Be("FE:80:00:00:00:00:00:00:02:15:5D:FF:FE:02:02:45");
        }

        [Fact]
        public void Set()
        {
            var ipv6Packet = new IPv6Packet
            {
                Bytes = new Byte[32]
            };

            ipv6Packet.SourceIPAddress = new IPAddress
            {
                Bytes = new Byte[]
                {
                    0xfe, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x15, 0x5d, 0xff, 0xfe, 0x02, 0x02, 0x45
                }
            };

            ipv6Packet.SourceIPAddress.ToString().Should().Be("FE:80:00:00:00:00:00:00:02:15:5D:FF:FE:02:02:45");
        }
    }
}
