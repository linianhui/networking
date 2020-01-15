using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.BitsTests
{
    public class Bits_Method_SetUInt16_Test
    {

        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] {0b_0101_1010_0101_1010, 3, 10, 0b_1111_1100_1011_0100, 0b_0100_0101_1010_0010},
            new Object[] {0b_0101_1010_0101_1010, 4, 4, 0b_111_1111_1111_1111, 0b_0101_1111_0101_1010},
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void UInt16(UInt16 @this, Int32 bitIndex, Int32 bitLength, UInt16 value, UInt16 expected)
        {
            @this.SetUInt16(bitIndex, bitLength, value).Should().Be(expected);
        }
    }
}
