using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.OctetsTests
{
    public class Octets_Method_SetUInt16_Bits_Test
    {

        [Fact]
        public void SetUInt16()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] {
                    0b_0101_1010, 0b_1100_0011,
                    0b_1010_0101, 0b_0011_1100
                }
            };

            octets.SetUInt16(0, 4, 8, 0b_0101_0011).Should().Be(0b_0101_0101_0011_0011);

            octets.IsLittleEndian = true;
            octets.SetUInt16(2, 3, 6, 0b_1100_0111).Should().Be(0b_0010_0011_1010_0101);
        }

    }
}
