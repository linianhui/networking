using System;
using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.TCPSegmentTests
{
    public class TCPSegment_Property_FIN_Test
    {
        [Fact]
        public void Get()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };
            tcpSegment[13] = 0b_0000_0001;

            tcpSegment.FIN.Should().Be(true);
        }

        [Fact]
        public void Set()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };

            tcpSegment.FIN = true;
            tcpSegment[13].Should().Be(0b_0000_0001);

            tcpSegment.FIN = false;
            tcpSegment[13].Should().Be(0b_0000_0000);
        }
    }
}
