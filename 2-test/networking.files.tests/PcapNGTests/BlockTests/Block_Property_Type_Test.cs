using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.BlockTests
{
    public class Block_Property_Type_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] { new Byte[]{ 0x00, 0x00, 0x00, 0x00 }, BlockType.None },
            new Object[] { new Byte[]{ 0x00, 0x00, 0x00, 0x01 }, BlockType.InterfaceDescription },
            new Object[] { new Byte[]{ 0x00, 0x00, 0x00, 0x02 }, BlockType.Packet },
            new Object[] { new Byte[]{ 0x00, 0x00, 0x00, 0x03 }, BlockType.SimplePacket },
            new Object[] { new Byte[]{ 0x00, 0x00, 0x00, 0x04 }, BlockType.NameResolution },
            new Object[] { new Byte[]{ 0x00, 0x00, 0x00, 0x05 }, BlockType.InterfaceStatistics },
            new Object[] { new Byte[]{ 0x0A, 0x0D, 0x0D, 0x0A }, BlockType.SectionHeader },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Get(Byte[] input, BlockType expected)
        {
            var block = new Block
            {
                Bytes = new Byte[12]
            };

            block.SetBytes(0, 4, input);

            block.Type.Should().Be(expected);
        }
    }
}
