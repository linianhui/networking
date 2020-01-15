using System;
using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.TCPSegmentTests
{
    public class TCPSegment_Property_FlagSYN_Test
    {
        [Fact]
        public void Get()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };
            tcpSegment.SetByte(13, 0b_0000_0010);

            tcpSegment.FlagSYN.Should().Be(true);
        }

        [Fact]
        public void Set()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };

            tcpSegment.FlagSYN = true;
            tcpSegment.GetByte(13).Should().Be(0b_0000_0010);

            tcpSegment.FlagSYN = false;
            tcpSegment.GetByte(13).Should().Be(0b_0000_0000);
        }
    }
}
