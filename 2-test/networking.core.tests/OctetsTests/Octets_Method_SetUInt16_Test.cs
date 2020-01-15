using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.OctetsTests
{
    public class Octets_Method_SetUInt16_Test
    {

        [Fact]
        public void SetUInt16()
        {
            var octets = new Octets
            {
                Bytes = new Byte[4]
            };

            octets.SetUInt16(0, 1).Should().Be(1);
            octets.GetBytes(0, 2).ToArray().Should().Equal(0x00, 0x01);

            octets.IsLittleEndian = true;
            octets.SetUInt16(2, 1).Should().Be(1);
            octets.GetBytes(2, 2).ToArray().Should().Equal(0x01, 0x00);
        }
    }
}
