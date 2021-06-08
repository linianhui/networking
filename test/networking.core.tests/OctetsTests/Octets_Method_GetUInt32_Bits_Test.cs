using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.OctetsTests
{
    public class Octets_Method_GetUInt32_Bits_Test
    {

        [Fact]
        public void GetUInt32()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] {
                    0b_0101_1010, 0b_1100_0011, 0b_1010_0101, 0b_0011_1100, 0b_1010_0101,
                }
            };

            octets.GetUInt32(0, 4, 8).Should().Be(0b_1010_1100);
            octets.GetUInt32(1, 12, 16).Should().Be(0b_0101_0011_1100_1010);

            octets.IsLittleEndian = true;
            octets.GetUInt32(0, 4, 8).Should().Be(0b_1100_1010);
            octets.GetUInt32(1, 12, 16).Should().Be(0b_1100_1010_0101_1100);
        }
    }
}
