using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.BitsTests
{
    public class Bits_Method_GetBoolean_Test
    {

        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] {0b_1000_0000, 0, true},
            new Object[] {0b_0100_0000, 1, true},
            new Object[] {0b_0010_0000, 2, true},
            new Object[] {0b_0001_0000, 3, true},
            new Object[] {0b_0000_1000, 4, true},
            new Object[] {0b_0000_0100, 5, true},
            new Object[] {0b_0000_0010, 6, true},
            new Object[] {0b_0000_0001, 7, true},

            new Object[] {0b_0111_1111, 0, false},
            new Object[] {0b_1011_1111, 1, false},
            new Object[] {0b_1101_1111, 2, false},
            new Object[] {0b_1110_1111, 3, false},
            new Object[] {0b_1111_0111, 4, false},
            new Object[] {0b_1111_1011, 5, false},
            new Object[] {0b_1111_1101, 6, false},
            new Object[] {0b_1111_1110, 7, false}
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void GetBoolean(Byte @this, Int32 bitIndex, Boolean expected)
        {
            @this.GetBoolean(bitIndex).Should().Be(expected);
        }
    }
}
