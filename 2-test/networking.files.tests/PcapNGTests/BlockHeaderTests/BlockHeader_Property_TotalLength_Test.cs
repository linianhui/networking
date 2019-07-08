using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.BlockHeaderTests
{
    public class BlockHeader_Property_TotalLength_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { new Byte[]{ 0x00, 0x00, 0x00, 0x60 }, 96 },
            new Object[] { new Byte[]{ 0x00, 0x00, 0x00, 0x20 }, 32 },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte[] input, UInt32 expected)
        {
            var blockHeader = BlockHeader.From(new Byte[12]);

            blockHeader[4, 4] = input;

            blockHeader.TotalLength.Should().Be(expected);
        }
    }
}
