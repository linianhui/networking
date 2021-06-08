using System;
using System.Collections.Generic;
using FluentAssertions;
using Networking.Files.PcapNG;
using Xunit;

namespace Networking.Files.Tests.PcapNGTests.BlockTypeTests
{
    public class BlockType_Test
    {
        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] {  BlockType.None, 0x00000000},
            new Object[] {  BlockType.InterfaceDescription, 0x00000001},
            new Object[] {  BlockType.Packet, 0x00000002},
            new Object[] {  BlockType.SimplePacket, 0x00000003},
            new Object[] {  BlockType.NameResolution, 0x00000004},
            new Object[] {  BlockType.InterfaceStatistics, 0x00000005},
            new Object[] {  BlockType.EnhancedPacket, 0x00000006},
            new Object[] {  BlockType.SectionHeader, 0x0A0D0D0A},
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void type_value(BlockType input, UInt32 expected)
        {
            input.Should().Be(expected);
        }
    }
}
