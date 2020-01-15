using System;
using FluentAssertions;
using Networking.Files.Pcap;
using Xunit;

namespace Networking.Files.Tests.PcapTests.PcapPacketHeaderTests
{
    public class PcapPacketHeader_Test
    {
        [Fact]
        public void Get()
        {
            var pcapPacketHeader = new PcapPacketHeader
            {
                IsLittleEndian = true,
                Bytes = new Byte[] {
                    0xBE, 0x8B, 0x55, 0x5C,
                    0xD7, 0x50, 0x0C, 0x00,
                    0x4A, 0x00, 0x00, 0x00,
                    0x4A, 0x00, 0x00, 0x00,
                }
            };

            pcapPacketHeader.IsLittleEndian.Should().Be(true);
            pcapPacketHeader.TimestampSecondPart.Should().Be(1549110206);
            pcapPacketHeader.TimestampMicrosecondPart.Should().Be(807127);
            pcapPacketHeader.CapturedLength.Should().Be(74);
            pcapPacketHeader.OriginalLength.Should().Be(74);
        }
    }
}
