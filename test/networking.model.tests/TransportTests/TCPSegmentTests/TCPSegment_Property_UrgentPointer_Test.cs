using System;
using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.TCPSegmentTests
{
    public class TCPSegment_Property_UrgentPointer_Test
    {
        [Fact]
        public void Get()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };

            tcpSegment.SetBytes(18, 2, new Byte[] { 0x12, 0x34 });

            tcpSegment.UrgentPointer.Should().Be(4660);
        }

        [Fact]
        public void Set()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };

            tcpSegment.UrgentPointer = 3232;

            tcpSegment.UrgentPointer.Should().Be(3232);
        }
    }
}
