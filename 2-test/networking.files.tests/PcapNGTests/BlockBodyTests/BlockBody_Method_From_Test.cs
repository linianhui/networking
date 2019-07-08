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
            new Object[] { new Byte[] { 0x0A, 0x0D, 0x0D, 0x0A } , typeof(SectionHeaderBody) },
            new Object[] { new Byte[] { 0x01, 0x00, 0x00, 0x00 } , typeof(InterfaceDescriptionBody) },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void From(Byte[] headerBytes, Type excepted)
        {
            var blockHeader = BlockHeader.From(headerBytes.PaddingEndToLength(12));
            blockHeader.IsLittleEndian = true;

            var blockBody = BlockBody.From(blockHeader, new Byte[12]);
            blockBody.IsLittleEndian.Should().Be(true);
            blockBody.GetType().Should().Be(excepted);
        }
    }
}
