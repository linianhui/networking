using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.OctetsTests
{
    public class Octets_Method_GetBoolean_Test
    {

        [Fact]
        public void GetBoolean()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] {
                    0b0101_0101,
                    0b1010_1010,
                }
            };

            octets.GetBoolean(0, 0).Should().Be(false);
            octets.GetBoolean(0, 1).Should().Be(true);
            octets.GetBoolean(0, 2).Should().Be(false);
            octets.GetBoolean(0, 3).Should().Be(true);
            octets.GetBoolean(0, 4).Should().Be(false);
            octets.GetBoolean(0, 5).Should().Be(true);
            octets.GetBoolean(0, 6).Should().Be(false);
            octets.GetBoolean(0, 7).Should().Be(true);


            octets.GetBoolean(1, 0).Should().Be(true);
            octets.GetBoolean(1, 1).Should().Be(false);
            octets.GetBoolean(1, 2).Should().Be(true);
            octets.GetBoolean(1, 3).Should().Be(false);
            octets.GetBoolean(1, 4).Should().Be(true);
            octets.GetBoolean(1, 5).Should().Be(false);
            octets.GetBoolean(1, 6).Should().Be(true);
            octets.GetBoolean(1, 7).Should().Be(false);
        }
    }
}
