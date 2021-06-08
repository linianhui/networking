using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.OctetsTests
{
    public class Octets_Method_SetUInt32_Test
    {

        [Fact]
        public void SetUInt32()
        {
            var octets = new Octets
            {
                Bytes = new Byte[8]
            };

            octets.SetUInt32(0, 1).Should().Be(1);
            octets.GetBytes(0, 4).ToArray().Should().Equal(0x00, 0x00, 0x00, 0x01);

            octets.IsLittleEndian = true;
            octets.SetUInt32(4, 1).Should().Be(1);
            octets.GetBytes(4, 4).ToArray().Should().Equal(0x01, 0x00, 0x00, 0x00);
        }
    }
}
