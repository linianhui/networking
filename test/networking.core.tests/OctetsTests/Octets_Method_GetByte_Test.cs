using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.OctetsTests
{
    public class Octets_Method_GetByte_Test
    {
        [Fact]
        public void GetByte()
        {
            var octets = new Octets
            {
                Bytes = new Byte[]
                {
                    0x12,
                    0x34,
                    0x56
                }
            };

            octets.GetByte(0).Should().Be(0x12);
            octets.GetByte(1).Should().Be(0x34);
            octets.GetByte(2).Should().Be(0x56);
        }

        [Fact]
        public void GetByte_out_of_range_should_return_0()
        {
            var octets = new Octets();

            octets.GetByte(0).Should().Be(0);
            octets.GetByte(1).Should().Be(0);
            octets.GetByte(2).Should().Be(0);
        }

        [Fact]
        public void GetByte_With_BitIndex_And_BitLength()
        {
            var octets = new Octets
            {
                Bytes = new Byte[]
                {
                    0b0001_0010,
                    0b0011_0100,
                    0b0101_0110
                }
            };

            octets.GetByte(0, 1, 3).Should().Be(0b0000_0001);
            octets.GetByte(1, 2, 4).Should().Be(0b0000_1101);
            octets.GetByte(2, 1, 5).Should().Be(0b0001_0101);
        }
    }
}
