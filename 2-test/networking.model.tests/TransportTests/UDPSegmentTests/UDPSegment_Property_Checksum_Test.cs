using System;
using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.UDPSegmentTests
{
    public class UDPSegment_Property_Checksum_Test
    {
        [Fact]
        public void Get()
        {
            var udpSegment = new UDPSegment
            {
                Bytes = new Byte[32]
            };
            udpSegment[6, 2] = new Byte[] {0x12, 0x34};

            udpSegment.Checksum.Should().Be(4660);
        }

        [Fact]
        public void Set()
        {
            var udpSegment = new UDPSegment
            {
                Bytes = new Byte[32]
            };

            udpSegment.Checksum = 3232;

            udpSegment.Checksum.Should().Be(3232);
        }
    }
}
