using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.BlockTests
{
    public class Block_Test
    {
        [Fact]
        public void constructor()
        {
            var block = new Block(
                BlockHeader.From(new Byte[] {
                    0x00,0x00,0x00,0x01,
                    0x00,0x00,0x00,0x10,
                    0x00,0x00,0x00,0x10
                }),
                new Byte[12]
            );

            block.Header.Type.Should().Be(BlockType.InterfaceDescription);
            block.Header.TotalLength.Should().Be(16);
            block.Header.BodyLength.Should().Be(4);
            block.Body.GetType().Should().Be(typeof(InterfaceDescriptionBody));
        }
    }
}
