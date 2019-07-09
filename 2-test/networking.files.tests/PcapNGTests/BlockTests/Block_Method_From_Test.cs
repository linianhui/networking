using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.BlockTests
{
    public class Block_Method_From_Test
    {

        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { BlockType.SectionHeader , typeof(SectionHeaderBlock) },
            new Object[] { BlockType.InterfaceDescription, typeof(InterfaceDescriptionBlock) },
            new Object[] { BlockType.SimplePacket, typeof(SimplePacketBlock) },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void From(BlockType blockType, Type excepted)
        {
            var block = Block.From(blockType, true, new Byte[12]);
            block.IsLittleEndian.Should().Be(true);
            block.GetType().Should().Be(excepted);
        }
    }
}
