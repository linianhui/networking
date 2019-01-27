using System;
using FluentAssertions;
using Networking.Model.Internet;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.UDPSegmentTests
{
    public class UDPSegment_Test
    {
        [Fact]
        public void DHCP()
        {
            var udpSegment = new UDPSegment
            {
                Bytes = new Byte[]
                {
                    0x00, 0x44,
                    0x00, 0x43,
                    0x02, 0x2c,
                    0x00, 0x00
                }
            };

            udpSegment.SourcePort.Should().Be(68);
            udpSegment.DestinationPort.Should().Be(67);
            udpSegment.TotalLength.Should().Be(556);
            udpSegment.Checksum.Should().Be(0);
        }
    }
}
