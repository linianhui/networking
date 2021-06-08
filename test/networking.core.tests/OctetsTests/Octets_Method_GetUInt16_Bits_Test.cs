using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.OctetsTests
{
    public class Octets_Method_GetUInt16_Bits_Test
    {

        [Fact]
        public void GetUInt16()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] {
                    0b_0101_1010, 0b_1100_0011,
                    0b_1010_0101, 0b_0011_1100
                }
            };

            octets.GetUInt16(0, 4, 8).Should().Be(0b_1010_1100);
            octets.GetUInt16(2, 3, 6).Should().Be(0b_0000_1010);

            octets.IsLittleEndian = true;
            octets.GetUInt16(0, 4, 8).Should().Be(0b_0011_0101);
            octets.GetUInt16(2, 3, 6).Should().Be(0b_0011_1001);
        }
    }
}
