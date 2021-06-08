using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.OctetsTests
{
    public class Octets_Method_SetByte_Bits_Test
    {
        [Fact]
        public void SetByte()
        {
            var octets = new Octets
            {
                Bytes = new Byte[]
                {
                    0b_0101_1111,
                    0b_0101_1111,
                    0b_1111_1010,
                    0b_1111_1010,
                }
            };

            octets.SetByte(0, 0, 4, 0b_1010_1010).Should().Be(0b_1010_1111);
            octets.SetByte(1, 1, 3, 0b_1010_1010).Should().Be(0b_0010_1111);
            octets.SetByte(2, 4, 4, 0b_0101_1001).Should().Be(0b_1111_1001);
            octets.SetByte(3, 2, 2, 0b_0101_1001).Should().Be(0b_1101_1010);
        }
    }
}
