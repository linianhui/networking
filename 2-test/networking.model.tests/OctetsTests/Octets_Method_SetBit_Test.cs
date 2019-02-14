using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Method_SetBit_Test
    {

        [Fact]
        public void SetBit()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] {
                    0b0000_0000,
                    0b0000_0000,
                }
            };

            octets.SetBit(0, 0, true).Should().Be(0b1000_0000);
            octets.Bytes.ToArray().Should().Equal(0b1000_0000, 0b0000_0000);
            octets.SetBit(0, 1, true).Should().Be(0b1100_0000);
            octets.Bytes.ToArray().Should().Equal(0b1100_0000, 0b0000_0000);
            octets.SetBit(0, 2, true).Should().Be(0b1110_0000);
            octets.Bytes.ToArray().Should().Equal(0b1110_0000, 0b0000_0000);
            octets.SetBit(0, 3, true).Should().Be(0b1111_0000);
            octets.Bytes.ToArray().Should().Equal(0b1111_0000, 0b0000_0000);
            octets.SetBit(0, 4, true).Should().Be(0b1111_1000);
            octets.Bytes.ToArray().Should().Equal(0b1111_1000, 0b0000_0000);
            octets.SetBit(0, 5, true).Should().Be(0b1111_1100);
            octets.Bytes.ToArray().Should().Equal(0b1111_1100, 0b0000_0000);
            octets.SetBit(0, 6, true).Should().Be(0b1111_1110);
            octets.Bytes.ToArray().Should().Equal(0b1111_1110, 0b0000_0000);
            octets.SetBit(0, 7, true).Should().Be(0b1111_1111);
            octets.Bytes.ToArray().Should().Equal(0b1111_1111, 0b0000_0000);

            octets.SetBit(1, 0, true).Should().Be(0b1000_0000);
            octets.Bytes.ToArray().Should().Equal(0b1111_1111, 0b1000_0000);
            octets.SetBit(1, 1, true).Should().Be(0b1100_0000);
            octets.Bytes.ToArray().Should().Equal(0b1111_1111, 0b1100_0000);
            octets.SetBit(1, 2, true).Should().Be(0b1110_0000);
            octets.Bytes.ToArray().Should().Equal(0b1111_1111, 0b1110_0000);
            octets.SetBit(1, 3, true).Should().Be(0b1111_0000);
            octets.Bytes.ToArray().Should().Equal(0b1111_1111, 0b1111_0000);
            octets.SetBit(1, 4, true).Should().Be(0b1111_1000);
            octets.Bytes.ToArray().Should().Equal(0b1111_1111, 0b1111_1000);
            octets.SetBit(1, 5, true).Should().Be(0b1111_1100);
            octets.Bytes.ToArray().Should().Equal(0b1111_1111, 0b1111_1100);
            octets.SetBit(1, 6, true).Should().Be(0b1111_1110);
            octets.Bytes.ToArray().Should().Equal(0b1111_1111, 0b1111_1110);
            octets.SetBit(1, 7, true).Should().Be(0b1111_1111);
            octets.Bytes.ToArray().Should().Equal(0b1111_1111, 0b1111_1111);

            octets.SetBit(0, 7, false).Should().Be(0b1111_1110);
            octets.Bytes.ToArray().Should().Equal(0b1111_1110, 0b1111_1111);
            octets.SetBit(0, 6, false).Should().Be(0b1111_1100);
            octets.Bytes.ToArray().Should().Equal(0b1111_1100, 0b1111_1111);
            octets.SetBit(0, 5, false).Should().Be(0b1111_1000);
            octets.Bytes.ToArray().Should().Equal(0b1111_1000, 0b1111_1111);
            octets.SetBit(0, 4, false).Should().Be(0b1111_0000);
            octets.Bytes.ToArray().Should().Equal(0b1111_0000, 0b1111_1111);
            octets.SetBit(0, 3, false).Should().Be(0b1110_0000);
            octets.Bytes.ToArray().Should().Equal(0b1110_0000, 0b1111_1111);
            octets.SetBit(0, 2, false).Should().Be(0b1100_0000);
            octets.Bytes.ToArray().Should().Equal(0b1100_0000, 0b1111_1111);
            octets.SetBit(0, 1, false).Should().Be(0b1000_0000);
            octets.Bytes.ToArray().Should().Equal(0b1000_0000, 0b1111_1111);
            octets.SetBit(0, 0, false).Should().Be(0b0000_0000);
            octets.Bytes.ToArray().Should().Equal(0b0000_0000, 0b1111_1111);

            octets.SetBit(1, 7, false).Should().Be(0b1111_1110);
            octets.Bytes.ToArray().Should().Equal(0b0000_0000, 0b1111_1110);
            octets.SetBit(1, 6, false).Should().Be(0b1111_1100);
            octets.Bytes.ToArray().Should().Equal(0b0000_0000, 0b1111_1100);
            octets.SetBit(1, 5, false).Should().Be(0b1111_1000);
            octets.Bytes.ToArray().Should().Equal(0b0000_0000, 0b1111_1000);
            octets.SetBit(1, 4, false).Should().Be(0b1111_0000);
            octets.Bytes.ToArray().Should().Equal(0b0000_0000, 0b1111_0000);
            octets.SetBit(1, 3, false).Should().Be(0b1110_0000);
            octets.Bytes.ToArray().Should().Equal(0b0000_0000, 0b1110_0000);
            octets.SetBit(1, 2, false).Should().Be(0b1100_0000);
            octets.Bytes.ToArray().Should().Equal(0b0000_0000, 0b1100_0000);
            octets.SetBit(1, 1, false).Should().Be(0b1000_0000);
            octets.Bytes.ToArray().Should().Equal(0b0000_0000, 0b1000_0000);
            octets.SetBit(1, 0, false).Should().Be(0b0000_0000);
            octets.Bytes.ToArray().Should().Equal(0b0000_0000, 0b0000_0000);

        }
    }
}
