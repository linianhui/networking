using System;
using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.TCPSegmentTests
{
    public class TCPSegment_Property_FlagPSH_Test
    {
        [Fact]
        public void Get()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };
            tcpSegment.SetByte(13, 0b_0000_1000);

            tcpSegment.FlagPSH.Should().Be(true);
        }

        [Fact]
        public void Set()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };

            tcpSegment.FlagPSH = true;
            tcpSegment.GetByte(13).Should().Be(0b_0000_1000);

            tcpSegment.FlagPSH = false;
            tcpSegment.GetByte(13).Should().Be(0b_0000_0000);
        }
    }
}
