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
            new Object[] { new Byte[] { 0x0A, 0x0D, 0x0D, 0x0A } , typeof(SectionHeaderBody) },
            new Object[] { new Byte[] { 0x00, 0x00, 0x00, 0x01 }, typeof(InterfaceDescriptionBody) },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte[] input, Type excepted)
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

            block[0, 4] = input;

            block.Body.GetType().Should().Be(excepted);
            block.Body.Bytes.ToArray().Should().Equal(0x12, 0x34, 0x56, 0x78);
        }
    }
}
