using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.BitsTests
{
    public class Bits_Method_GetUInt16_Test
    {

        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] {0b_1111_1111_0011_1100, 0, 0, 0b_0000_0000_0000_0000},
            new Object[] {0b_1111_1111_0011_1100, 0, 1, 0b_0000_0000_0000_0001},
            new Object[] {0b_1111_1111_0011_1100, 0, 2, 0b_0000_0000_0000_0011},
            new Object[] {0b_1111_1111_0011_1100, 0, 3, 0b_0000_0000_0000_0111},
            new Object[] {0b_1011_1111_0011_1100, 0, 3, 0b_0000_0000_0000_0101},
            new Object[] {0b_0011_1111_0011_1100, 12, 3, 0b_0000_0000_0000_0110},
            new Object[] {0b_0011_1111_0011_1100, 9, 2, 0b_0000_0000_0000_0001},
            new Object[] {0b_0001_1010_0011_1100, 8, 5, 0b_0000_0000_0000_0111},
            new Object[] {0b_0001_0010_0011_1100, 8, 4, 0b_0000_0000_0000_0011},
            new Object[] {0b_0001_0010_0011_1100, 4, 9, 0b_0000_0000_0100_0111},
            new Object[] {0b_0001_0010_0011_1100, 3, 10,0b_0000_0010_0100_0111},
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void GetUInt16(UInt16 @this, Int32 bitIndex, Int32 bitLength, UInt16 expected)
        {
            @this.GetUInt16(bitIndex, bitLength).Should().Be(expected);
        }
    }
}
