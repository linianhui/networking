using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPv6PacketTests
{
    public class IPv6Packet_Test
    {
        [Fact]
        public void ICMPV6()
        {
            var icmpv6 = new IPv6Packet
            {
                Bytes = new Byte[]
                {
                    0x61, 0x2d, 0xf6, 0x06,
                    0x00, 0x10,
                    0x3a,
                    0xff,
                    0xfe, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x15, 0x5d, 0xff, 0xfe, 0x02, 0x02, 0x45,
                    0xff, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02,
                    0x85, 0x00, 0xbc, 0x75, 0x00, 0x00, 0x00, 0x00, 0x01, 0x01, 0x00, 0x15, 0x5d, 0x02, 0x02, 0x45
                }
            };

            icmpv6.Version.Should().Be(IPVersion.IPv6);
            icmpv6.TrafficClass.Should().Be(0x12);
            icmpv6.FlowLabel.Should().Be(0xdf606);
            icmpv6.PayloadLength.Should().Be(16);
            icmpv6.NextHeader.Should().Be(58);
            icmpv6.HopLimit.Should().Be(255);
            icmpv6.SourceIPAddress.ToString().Should().Be("FE:80:00:00:00:00:00:00:02:15:5D:FF:FE:02:02:45");
            icmpv6.DestinationIPAddress.ToString().Should().Be("FF:02:00:00:00:00:00:00:00:00:00:00:00:00:00:02");
        }
    }
}
