using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.BlockTests
{
    public class Block_Property_TotalLength_Test
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
            var block = new Block
            {
                Bytes = new Byte[12]
            };

            block.SetBytes(4, 4, input);

            block.TotalLength.Should().Be(expected);
        }
    }
}
