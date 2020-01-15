using System;
using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.EnhancedPacketBlockTests
{
    public class EnhancedPacketBlock_Test
    {
        [Fact]
        public void enhanced_packet_block()
        {
            var enhancedPacketBlock = new EnhancedPacketBlock
            {
                IsLittleEndian = true,
                Bytes = new Byte[] {
                    0x06,0x00,0x00,0x00,
                    0x38,0x00,0x00,0x00,
                    0x00,0x00,0x00,0x00,
                    0x83,0xEA,0x03,0x00,
                    0x0D,0x8A,0x33,0x35,
                    0x18,0x00,0x00,0x00,
                    0x3A,0x01,0x00,0x00,
                    0xFF,0xFF,0xFF,0xFF,
                    0xFF,0xFF,0x00,0x0B,
                    0x82,0x01,0xFC,0x42,
                    0x08,0x00,0x45,0x00,
                    0x01,0x2C,0xA8,0x36,
                    0x00,0x00,0xFA,0x11,
                    0x38,0x00,0x00,0x00
                }
            };

            enhancedPacketBlock.Should().BeAssignableTo<IPacket>();
            enhancedPacketBlock.IsPacket.Should().Be(true);
            enhancedPacketBlock.TotalLength.Should().Be(0x38);
            enhancedPacketBlock.InterfaceId.Should().Be(0);
            enhancedPacketBlock.CapturedLength.Should().Be(0x18);
            enhancedPacketBlock.OriginalLength.Should().Be(0x013A);
            enhancedPacketBlock.Payload.ToArray().Should().Equal(
                0xFF, 0xFF, 0xFF, 0xFF,
                0xFF, 0xFF, 0x00, 0x0B,
                0x82, 0x01, 0xFC, 0x42,
                0x08, 0x00, 0x45, 0x00,
                0x01, 0x2C, 0xA8, 0x36,
                0x00, 0x00, 0xFA, 0x11);
        }
    }
}
