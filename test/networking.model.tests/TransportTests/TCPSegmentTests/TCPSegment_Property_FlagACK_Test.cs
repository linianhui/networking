using System;
using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.TCPSegmentTests
{
    public class TCPSegment_Property_FlagACK_Test
    {
        [Fact]
        public void Get()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };
            tcpSegment.SetByte(13, 0b_0001_0000);

            tcpSegment.FlagACK.Should().Be(true);
        }

        [Fact]
        public void Set()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };

            tcpSegment.FlagACK = true;
            tcpSegment.GetByte(13).Should().Be(0b_0001_0000);

            tcpSegment.FlagACK = false;
            tcpSegment.GetByte(13).Should().Be(0b_0000_0000);
        }
    }
}
