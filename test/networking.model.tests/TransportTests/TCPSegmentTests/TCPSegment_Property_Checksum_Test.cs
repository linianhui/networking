using System;
using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.TCPSegmentTests
{
    public class TCPSegment_Property_Checksum_Test
    {
        [Fact]
        public void Get()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };

            tcpSegment.SetBytes(16, 2, new Byte[] { 0x12, 0x34 });

            tcpSegment.Checksum.Should().Be(4660);
        }

        [Fact]
        public void Set()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };

            tcpSegment.Checksum = 3232;

            tcpSegment.Checksum.Should().Be(3232);
        }
    }
}
