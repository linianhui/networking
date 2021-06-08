using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.OctetsTests
{
    public class Octets_Method_SetUInt32_Bits_Test
    {

        [Fact]
        public void SetUInt32()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] {
                    0b_0101_1010, 0b_1100_0011, 0b_1010_0101, 0b_0011_1100,
                    0b_0101_1010, 0b_1100_0011, 0b_1010_0101, 0b_0011_1100,
                }
            };

            octets.SetUInt32(0, 7, 18, 0b_1_0011_1100_0101_1010_1).Should().Be(0b_0101_1011_0011_1100_0101_1010_1011_1100);

            octets.IsLittleEndian = true;

            octets.SetUInt32(4, 7, 18, 0b_1_0101_1010_0011_1100_1).Should().Be(0b_0011_1101_0101_1010_0011_1100_1101_1010);
        }
    }
}
