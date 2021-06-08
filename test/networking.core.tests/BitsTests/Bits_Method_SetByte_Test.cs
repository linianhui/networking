using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.BitsTests
{
    public class Bits_Method_SetByte_Test
    {

        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] {0b_1111_1111, 0, 2, 0b_0111_1110, 0b_1011_1111},
            new Object[] {0b_0111_1101, 1, 5, 0b_1110_1011, 0b_0010_1101},
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void SetByte(Byte @this, Int32 bitIndex, Int32 bitLength, Byte value, Byte expected)
        {
            @this.SetByte(bitIndex, bitLength, value).Should().Be(expected);
        }
    }
}
