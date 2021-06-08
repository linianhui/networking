using System;
using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.TCPSegmentTests
{
    public class TCPSegment_Property_HeaderLength_Test
    {
        [Fact]
        public void Get()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };
            tcpSegment.SetByte(12, 0x66);

            tcpSegment.HeaderLength.Should().Be(6);
        }

        [Theory]
        [InlineData(0x05)]
        [InlineData(0x06)]
        [InlineData(0x07)]
        [InlineData(0x08)]
        [InlineData(0x09)]
        [InlineData(0x0A)]
        [InlineData(0x0B)]
        [InlineData(0x0C)]
        [InlineData(0x0D)]
        [InlineData(0x0E)]
        [InlineData(0x0F)]
        public void Set(Byte input)
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[32]
            };
            tcpSegment.SetByte(12, 0x05);

            tcpSegment.HeaderLength = input;
            tcpSegment.HeaderLength.Should().Be(input);
            tcpSegment.GetByte(12).Should().Be((Byte)(input << 4 | (0x45 & 0x0F)));
        }
    }
}
