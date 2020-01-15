using System;
using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.TCPSegmentTests
{
    public class TCPSegment_Property_FlagNS_Test
    {
        [Fact]
        public void Get()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };
            tcpSegment.SetByte(12, 0b_0000_0001);

            tcpSegment.FlagNS.Should().Be(true);
        }

        [Fact]
        public void Set()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };

            tcpSegment.FlagNS = true;
            tcpSegment.GetByte(12).Should().Be(0b_0000_0001);

            tcpSegment.FlagNS = false;
            tcpSegment.GetByte(12).Should().Be(0b_0000_0000);
        }
    }
}
