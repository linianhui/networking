using System;
using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.UDPSegmentTests
{
    public class UDPSegment_Property_TotalLength_Test
    {
        [Fact]
        public void Get()
        {
            var udpSegment = new UDPSegment
            {
                Bytes = new Byte[32]
            };
            udpSegment[4, 2] = new Byte[] {0x00, 0x20};

            udpSegment.TotalLength.Should().Be(32);
        }

        [Fact]
        public void Set()
        {
            var udpSegment = new UDPSegment
            {
                Bytes = new Byte[32]
            };

            udpSegment.TotalLength = 32;

            udpSegment.TotalLength.Should().Be(32);
        }
    }
}
