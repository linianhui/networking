using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.BlockHeaderTests
{
    public class BlockHeader_Property_BodyLength_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { new Byte[]{ 0x00, 0x00, 0x00, 0x10 }, 4 },
            new Object[] { new Byte[]{ 0x00, 0x00, 0x00, 0x20 }, 20 },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte[] input, UInt32 expected)
        {
            var blockHeader = BlockHeader.From(new Byte[12]);

            blockHeader[4, 4] = input;

            blockHeader.BodyLength.Should().Be(expected);
        }
    }
}
