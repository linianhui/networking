using System;
using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.BlockHeaderTests
{
    public class BlockHeader_Test
    {

        [Fact]
        public void block_header()
        {
            var blockHeader = new BlockHeader
            {
                Bytes = new Byte[]
                {
                    0x00,0x00,0x00,0x01,
                    0x00,0x00,0x00,0x10,
                }
            };

            blockHeader.Type.Should().Be(BlockType.InterfaceDescription);
            blockHeader.TotalLength.Should().Be(16);
            blockHeader.BodyLength.Should().Be(4);
        }
    }
}
