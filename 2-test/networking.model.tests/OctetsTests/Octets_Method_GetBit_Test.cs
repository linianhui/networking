using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Method_GetBit_Test
    {

        [Fact]
        public void GetBit()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] {
                    0b0101_0101,
                    0b1010_1010,
                }
            };

            octets.GetBit(0, 0).Should().Be(false);
            octets.GetBit(0, 1).Should().Be(true);
            octets.GetBit(0, 2).Should().Be(false);
            octets.GetBit(0, 3).Should().Be(true);
            octets.GetBit(0, 4).Should().Be(false);
            octets.GetBit(0, 5).Should().Be(true);
            octets.GetBit(0, 6).Should().Be(false);
            octets.GetBit(0, 7).Should().Be(true);

            
            octets.GetBit(1, 0).Should().Be(true);
            octets.GetBit(1, 1).Should().Be(false);
            octets.GetBit(1, 2).Should().Be(true);
            octets.GetBit(1, 3).Should().Be(false);
            octets.GetBit(1, 4).Should().Be(true);
            octets.GetBit(1, 5).Should().Be(false);
            octets.GetBit(1, 6).Should().Be(true);
            octets.GetBit(1, 7).Should().Be(false);
        }
    }
}
