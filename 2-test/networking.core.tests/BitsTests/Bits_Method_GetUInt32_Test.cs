using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.BitsTests
{
    public class Bits_Method_GetUInt32_Test
    {

        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] {0b_0000_0000_0000_0000_1111_1111_0011_1100, 16, 0, 0b_0000_0000_0000_0000},
            new Object[] {0b_0000_0000_0000_0000_1111_1111_0011_1100, 16, 1, 0b_0000_0000_0000_0001},
            new Object[] {0b_0000_0000_0000_0000_1111_1111_0011_1100, 16, 2, 0b_0000_0000_0000_0011},
            new Object[] {0b_0000_0000_0000_0000_1111_1111_0011_1100, 16, 3, 0b_0000_0000_0000_0111},
            new Object[] {0b_0000_0000_0000_0000_1011_1111_0011_1100, 16, 3, 0b_0000_0000_0000_0101},
            new Object[] {0b_0000_0000_0000_0000_0011_1111_0011_1100, 28, 3, 0b_0000_0000_0000_0110},
            new Object[] {0b_0000_0000_0000_0000_0011_1111_0011_1100, 25, 2, 0b_0000_0000_0000_0001},
            new Object[] {0b_0000_0000_0000_0000_0001_1010_0011_1100, 24, 5, 0b_0000_0000_0000_0111},
            new Object[] {0b_0000_0000_0000_0000_0001_0010_0011_1100, 24, 4, 0b_0000_0000_0000_0011},
            new Object[] {0b_0000_0000_0000_0000_0001_0010_0011_1100, 20, 9, 0b_0000_0000_0100_0111},
            new Object[] {0b_0000_0000_0000_0000_0001_0010_0011_1100, 19, 10,0b_0000_0010_0100_0111},
            new Object[] {0b_0001_0010_0100_1000_0001_0010_0011_1100, 3, 25,0b_0000_0001_0010_0100_1000_0001_0010_0011},
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void GetUInt32(UInt32 @this, Int32 bitIndex, Int32 bitLength, UInt32 expected)
        {
            @this.GetUInt32(bitIndex, bitLength).Should().Be(expected);
        }
    }
}
