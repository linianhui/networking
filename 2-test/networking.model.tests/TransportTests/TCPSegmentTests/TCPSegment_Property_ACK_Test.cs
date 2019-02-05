using System;
using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.TCPSegmentTests
{
    public class TCPSegment_Property_ACK_Test
    {
        [Fact]
        public void Get()
        {
            var tcpSegment = new TCPSegment(new Byte[32]);
            tcpSegment[8, 4] = new Byte[] { 0x01, 0x23, 0x45, 0x67 };

            tcpSegment.ACK.Should().Be(19088743);
        }

        [Fact]
        public void Set()
        {
            var tcpSegment = new TCPSegment(new Byte[32]);

            tcpSegment.ACK = 19088743;

            tcpSegment.ACK.Should().Be(19088743);
            tcpSegment[8, 4].ToArray().Should().Equal(0x01, 0x23, 0x45, 0x67);
        }
    }
}
