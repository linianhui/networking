using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.BitsTests
{
    public class Bits_Method_SetBoolean_Test
    {

        public static List<Object[]> Data => new List<Object[]>
        {
            new Object[] {0b_1111_1111, 0, false, 0b_0111_1111},
            new Object[] {0b_1111_1111, 1, false, 0b_1011_1111},
            new Object[] {0b_1111_1111, 2, false, 0b_1101_1111},
            new Object[] {0b_1111_1111, 3, false, 0b_1110_1111},
            new Object[] {0b_1111_1111, 4, false, 0b_1111_0111},
            new Object[] {0b_1111_1111, 5, false, 0b_1111_1011},
            new Object[] {0b_1111_1111, 6, false, 0b_1111_1101},
            new Object[] {0b_1111_1111, 7, false, 0b_1111_1110},
            new Object[] {0b_0111_1111, 0, false, 0b_0111_1111},
            new Object[] {0b_1011_1111, 1, false, 0b_1011_1111},
            new Object[] {0b_1101_1111, 2, false, 0b_1101_1111},
            new Object[] {0b_1110_1111, 3, false, 0b_1110_1111},
            new Object[] {0b_1111_0111, 4, false, 0b_1111_0111},
            new Object[] {0b_1111_1011, 5, false, 0b_1111_1011},
            new Object[] {0b_1111_1101, 6, false, 0b_1111_1101},
            new Object[] {0b_1111_1110, 7, false, 0b_1111_1110},

            new Object[] {0b_0111_1111, 0, true, 0b_1111_1111},
            new Object[] {0b_1011_1111, 1, true, 0b_1111_1111},
            new Object[] {0b_1101_1111, 2, true, 0b_1111_1111},
            new Object[] {0b_1110_1111, 3, true, 0b_1111_1111},
            new Object[] {0b_1111_0111, 4, true, 0b_1111_1111},
            new Object[] {0b_1111_1011, 5, true, 0b_1111_1111},
            new Object[] {0b_1111_1101, 6, true, 0b_1111_1111},
            new Object[] {0b_1111_1110, 7, true, 0b_1111_1111},
            new Object[] {0b_1111_1111, 0, true, 0b_1111_1111},
            new Object[] {0b_1111_1111, 1, true, 0b_1111_1111},
            new Object[] {0b_1111_1111, 2, true, 0b_1111_1111},
            new Object[] {0b_1111_1111, 3, true, 0b_1111_1111},
            new Object[] {0b_1111_1111, 4, true, 0b_1111_1111},
            new Object[] {0b_1111_1111, 5, true, 0b_1111_1111},
            new Object[] {0b_1111_1111, 6, true, 0b_1111_1111},
            new Object[] {0b_1111_1111, 7, true, 0b_1111_1111}
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void SetBoolean(Byte @this, Int32 bitIndex, Boolean value, Byte expected)
        {
            @this.SetBoolean(bitIndex, value).Should().Be(expected);
        }
    }
}
