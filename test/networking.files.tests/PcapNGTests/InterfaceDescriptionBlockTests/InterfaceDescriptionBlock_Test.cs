using System;
using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.InterfaceDescriptionBlockTests
{
    public class InterfaceDescriptionBlock_Test
    {
        [Fact]
        public void interface_description_block()
        {
            var interfaceDescriptionBlock = new InterfaceDescriptionBlock
            {
                Bytes = new Byte[] {
                    0x00,0x00,0x00,0x01,
                    0x00,0x00,0x00,0x14,
                    0x00,0x01,0x00,0x00,
                    0x12,0x34,0x56,0x78
                }
            };

            interfaceDescriptionBlock.Should().NotBeAssignableTo<IPacket>();
            interfaceDescriptionBlock.IsPacket.Should().Be(false);
            interfaceDescriptionBlock.DataLinkType.Should().Be(PacketDataLinkType.Ethernet);
            interfaceDescriptionBlock.MaxCapturedLength.Should().Be(0x12345678);
        }
    }
}
