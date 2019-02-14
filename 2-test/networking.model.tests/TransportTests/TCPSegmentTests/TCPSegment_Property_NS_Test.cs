using System;
using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.TCPSegmentTests
{
    public class TCPSegment_Property_NS_Test
    {
        [Fact]
        public void Get()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };
            tcpSegment[12] = 0b_0000_0001;

            tcpSegment.NS.Should().Be(true);
        }

        [Fact]
        public void Set()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };

            tcpSegment.NS = true;
            tcpSegment[12].Should().Be(0b_0000_0001);

            tcpSegment.NS = false;
            tcpSegment[12].Should().Be(0b_0000_0000);
        }
    }
}
