using System;
using FluentAssertions;
using Networking.Model;
using Networking.Utils.Pcap;
using Xunit;

namespace Networking.Utils.Tests.PcapTests.PacketHeaderTests
{
    public class PacketHeader_Test
    {
        [Fact]
        public void Get()
        {
            PacketHeader packetHeader = new PacketHeader
            {
                IsLittleEndian = true,
                Bytes = new Byte[] {
                    0xBE, 0x8B, 0x55, 0x5C,
                    0xD7, 0x50, 0x0C, 0x00,
                    0x4A, 0x00, 0x00, 0x00,
                    0x4A, 0x00, 0x00, 0x00,
                }
            };

            packetHeader.IsLittleEndian.Should().Be(true);
            packetHeader.TimestampSeconds.Should().Be(1549110206);
            packetHeader.TimestampMicroseconds.Should().Be(807127);
            packetHeader.SavedLength.Should().Be(74);
            packetHeader.OriginalLength.Should().Be(74);
        }
    }
}
