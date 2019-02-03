using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Method_WriteUInt16_Test
    {

        [Fact]
        public void WriteUInt16()
        {
            var octets = new Octets
            {
                Bytes = new Byte[4]
            };

            octets.WriteUInt16(0, 1, Endian.Big);
            octets.WriteUInt16(2, 1, Endian.Little);

            octets.ReadUInt16(0, Endian.Big).Should().Be(1);
            octets[0, 2].ToArray().Should().Equal(0x00, 0x01);

            octets.ReadUInt16(2, Endian.Little).Should().Be(1);
            octets[2, 2].ToArray().Should().Equal(0x01, 0x00);
        }
    }
}
