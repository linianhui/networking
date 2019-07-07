using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.BlockBodyTests
{
    public class BlockBody_Method_From_Test
    {

        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { BlockType.SectionHeader , typeof(SectionHeaderBody) },
            new Object[] { BlockType.InterfaceDescription, typeof(InterfaceDescriptionBody) },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void From(BlockType blockType, Type excepted)
        {
            BlockBody.From(blockType, new Byte[12]).GetType().Should().Be(excepted);
        }
    }
}
