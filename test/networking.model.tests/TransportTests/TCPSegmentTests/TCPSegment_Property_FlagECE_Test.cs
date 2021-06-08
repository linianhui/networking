using System;
using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.TCPSegmentTests
{
    public class TCPSegment_Property_FlagECE_Test
    {
        [Fact]
        public void Get()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };
            tcpSegment.SetByte(13, 0b_0100_0000);

            tcpSegment.FlagECE.Should().Be(true);
        }

        [Fact]
        public void Set()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };

            tcpSegment.FlagECE = true;
            tcpSegment.GetByte(13).Should().Be(0b_0100_0000);

            tcpSegment.FlagECE = false;
            tcpSegment.GetByte(13).Should().Be(0b_0000_0000);
        }
    }
}
