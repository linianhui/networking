using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.BitsTests
{
    public class Bits_Method_GetSubByte_Test
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
        public void GetSubByte(Byte @this, Byte index, Byte length, Byte expected)
        {
            @this.GetSubByte(index, length).Should().Be(expected);
        }

        [Theory]
        [InlineData(0, 9)]
        [InlineData(1, 8)]
        [InlineData(2, 7)]
        [InlineData(3, 6)]
        [InlineData(4, 5)]
        [InlineData(5, 4)]
        [InlineData(6, 3)]
        [InlineData(7, 2)]
        [InlineData(8, 0)]
        public void GetSubByte_throw_IndexOutOfRangeException(Byte index, Byte length)
        {
            Assert.Throws<IndexOutOfRangeException>(() => ((Byte)1).GetSubByte(index, length).Should());
        }
    }
}
