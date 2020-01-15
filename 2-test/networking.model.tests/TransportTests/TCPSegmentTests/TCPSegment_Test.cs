using System;
using FluentAssertions;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Model.Tests.TransportTests.TCPSegmentTests
{
    public class TCPSegment_Test
    {
        [Fact]
        public void FIN()
        {
            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[]
                {
                   0x00, 0x50,
                   0xde, 0x4a,
                   0x36, 0x0f, 0xd2, 0x55,
                   0x48, 0xd6, 0xca, 0x71,
                   0x50, 0x11,
                   0x6f, 0x8c,
                   0x5a, 0x4c,
                   0x00, 0x00,
                   0x01, 0x23, 0x45, 0x67
                }
            };

            tcpSegment.SourcePort.Should().Be(80);
            tcpSegment.DestinationPort.Should().Be(56906);
            tcpSegment.SequenceNumber.Should().Be(907006549);
            tcpSegment.AcknowledgmentNumber.Should().Be(1222036081);
            tcpSegment.FlagACK.Should().Be(true);
            tcpSegment.FlagFIN.Should().Be(true);
            tcpSegment.HeaderLength.Should().Be(5);
            tcpSegment.WindowsSize.Should().Be(28556);
            tcpSegment.Checksum.Should().Be(0x5a4c);
            tcpSegment.UrgentPointer.Should().Be(0);
            tcpSegment.Payload.Bytes.ToArray().Should().Equal(0x01, 0x23, 0x45, 0x67);
        }
    }
}
