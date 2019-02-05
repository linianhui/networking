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

            octets.WriteUInt16(0, 1);
            octets.ReadUInt16(0).Should().Be(1);
            octets[0, 2].ToArray().Should().Equal(0x00, 0x01);

            octets.Endian = Endian.Little;
            octets.WriteUInt16(2, 1);
            octets.ReadUInt16(2).Should().Be(1);
            octets[2, 2].ToArray().Should().Equal(0x01, 0x00);
        }
    }
}
