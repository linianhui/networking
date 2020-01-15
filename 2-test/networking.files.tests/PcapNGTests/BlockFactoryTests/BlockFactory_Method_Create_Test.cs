using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.BlockFactoryTests
{
    public class BlockFactory_Method_Create_Test
    {

        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { BlockType.SectionHeader , typeof(SectionHeaderBlock) },
            new Object[] { BlockType.InterfaceDescription, typeof(InterfaceDescriptionBlock) },
            new Object[] { BlockType.SimplePacket, typeof(SimplePacketBlock) },
            new Object[] { BlockType.NameResolution, typeof(NameResolutionBlock) },
            new Object[] { BlockType.InterfaceStatistics, typeof(InterfaceStatisticsBlock) },
            new Object[] { BlockType.EnhancedPacket, typeof(EnhancedPacketBlock) },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Create(BlockType blockType, Type excepted)
        {
            var block = BlockFactory.Create(blockType, true, new Byte[12]);
            block.IsLittleEndian.Should().Be(true);
            block.GetType().Should().Be(excepted);
        }
    }
}
