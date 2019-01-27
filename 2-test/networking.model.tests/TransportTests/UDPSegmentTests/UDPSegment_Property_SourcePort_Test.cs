using System;
using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.UDPSegmentTests
{
    public class UDPSegment_Property_SourcePort_Test
    {
        [Fact]
        public void Get()
        {
            var udpSegment = new UDPSegment
            {
                Bytes = new Byte[32]
            };
            udpSegment[0, 2] = new Byte[] {0x00, 0x50};

            udpSegment.SourcePort.Should().Be(80);
        }

        [Fact]
        public void Set()
        {
            var udpSegment = new UDPSegment
            {
                Bytes = new Byte[32]
            };

            udpSegment.SourcePort = 80;

            udpSegment.SourcePort.Should().Be(80);
        }
    }
}
