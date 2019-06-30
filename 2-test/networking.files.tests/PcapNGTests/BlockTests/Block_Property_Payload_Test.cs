using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.BlockTests
{
    public class Block_Property_Payload_Test
    {

        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { BlockType.SectionHeader , typeof(SectionHeaderBody) },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(BlockType input, Type excepted)
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

            block[0, 4] = BitConverter.GetBytes((UInt32)input);

            block.Body.GetType().Should().Be(excepted);
            block.Body.Bytes.ToArray().Should().Equal(0x12, 0x34, 0x56, 0x78);
        }
    }
}
