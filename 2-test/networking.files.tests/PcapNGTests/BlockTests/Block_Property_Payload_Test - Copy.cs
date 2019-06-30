using System;
using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.BlockTests
{
    public class Block_Test
    {

        [Fact]
        public void block()
        {
            var block = new Block
            {
                Bytes = new Byte[]
                {
                    0x00,0x00,0x00,0x01,
                    0x00,0x00,0x00,0x10,
                    0x12,0x34,0x56,0x78,
                    0x00,0x00,0x00,0x10
                }
            };

            block.Type.Should().Be(BlockType.InterfaceDescription);
            block.TotalLength.Should().Be(16);
            block.BodyLength.Should().Be(4);
            block.Body.Bytes.ToArray().Should().Equal(0x12, 0x34, 0x56, 0x78);
        }
    }
}
