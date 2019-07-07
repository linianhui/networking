using System;
using FluentAssertions;
using Networking.Files.Pcap;
using Xunit;

namespace Networking.Files.Tests.PcapTests.PacketHeaderTests
{
    public class PacketHeader_Test
    {
        [Fact]
        public void Get()
        {
            var pcapFileHeader = new PcapFileHeader(new Byte[] {
                0xD4, 0xC3, 0xB2, 0xA1,
                0x02, 0x00,
                0x04, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0xFF, 0xFF, 0x00, 0x00,
                0x01, 0x00, 0x00, 0x00
            });

            var packetHeader = new PacketHeader
            (
                pcapFileHeader,
                new Byte[] {
                    0xBE, 0x8B, 0x55, 0x5C,
                    0xD7, 0x50, 0x0C, 0x00,
                    0x4A, 0x00, 0x00, 0x00,
                    0x4A, 0x00, 0x00, 0x00,
                }
            );

            packetHeader.IsLittleEndian.Should().Be(true);
            packetHeader.TimestampSecond.Should().Be(1549110206);
            packetHeader.TimestampMicrosecond.Should().Be(807127);
            packetHeader.CapturedLength.Should().Be(74);
            packetHeader.OriginalLength.Should().Be(74);
        }
    }
}
