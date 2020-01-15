using System;
using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.TCPSegmentTests
{
    public class TCPSegment_Property_DestinationPort_Test
    {
        [Fact]
        public void Get()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };

            tcpSegment.SetBytes(2, 2, new Byte[] { 0x00, 0x50 });

            tcpSegment.DestinationPort.Should().Be(80);
        }

        [Fact]
        public void Set()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };

            tcpSegment.DestinationPort = 80;

            tcpSegment.DestinationPort.Should().Be(80);
        }
    }
}
