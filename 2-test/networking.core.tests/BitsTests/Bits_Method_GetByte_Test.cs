using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.BitsTests
{
    public class Bits_Method_GetByte_Test
    {

        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] {0b_1111_1111, 0, 0, 0b_0000_0000},
            new Object[] {0b_1111_1111, 0, 1, 0b_0000_0001},
            new Object[] {0b_1111_1111, 0, 2, 0b_0000_0011},
            new Object[] {0b_1111_1111, 0, 3, 0b_0000_0111},
            new Object[] {0b_1011_1111, 0, 3, 0b_0000_0101},
            new Object[] {0b_0011_1111, 0, 3, 0b_0000_0001},
            new Object[] {0b_0011_1111, 4, 3, 0b_0000_0111},
            new Object[] {0b_0001_1010, 4, 3, 0b_0000_0101},
            new Object[] {0b_0001_0010, 4, 3, 0b_0000_0001},
            new Object[] {0b_0001_0010, 4, 4, 0b_0000_0010},
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void GetByte(Byte @this, Int32 bitIndex, Int32 bitLength, Byte expected)
        {
            @this.GetByte(bitIndex, bitLength).Should().Be(expected);
        }
    }
}
