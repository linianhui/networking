using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.BitsTests
{
    public class Bits_Method_SetUInt32_Test
    {

        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] {0b_0000_1111_0101_1010_0101_1010_1111_0000, 11, 10, 0b_1111_1111_1111_1111_1111_1100_1011_0100, 0b_0000_1111_0100_0101_1010_0010_1111_0000},
            new Object[] {0b_0000_1111_0101_1010_0101_1010_1111_0000, 12, 4, 0b_1111_1111_1111_1111_1111_1111_1111_1111, 0b_0000_1111_0101_1111_0101_1010_1111_0000},
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void UInt32(UInt32 @this, Int32 bitIndex, Int32 bitLength, UInt32 value, UInt32 expected)
        {
            @this.SetUInt32(bitIndex, bitLength, value).Should().Be(expected);
        }
    }
}
