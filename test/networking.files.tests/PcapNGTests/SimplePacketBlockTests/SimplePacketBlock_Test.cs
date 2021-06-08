using System;
using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.SimplePacketBlockTests
{
    public class SimplePacketBlock_Test
    {
        [Fact]
        public void simple_packet_block()
        {
            var simplePacketBlock = new SimplePacketBlock
            {
                Bytes = new Byte[] {
                    0x00,0x00,0x00,0x03,
                    0x00,0x00,0x00,0x14,
                    0x00,0x00,0x00,0x80,
                    0x12,0x34,0x56,0x78,
                    0x00,0x00,0x00,0x14
                }
            };

            simplePacketBlock.Should().BeAssignableTo<IPacket>();
            simplePacketBlock.IsPacket.Should().Be(true);
            simplePacketBlock.OriginalLength.Should().Be(0x80);
            simplePacketBlock.Payload.ToArray().Should().Equal(0x12, 0x34, 0x56, 0x78);
        }
    }
}
