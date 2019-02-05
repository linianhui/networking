using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Method_WriteUInt16_Test
    {

        [Fact]
        public void WriteUInt16_BigEndian()
        {
            var octets = new Octets(new Byte[4]);

            octets.WriteUInt16(0, 1);
            octets.ReadUInt16(0).Should().Be(1);
            octets[0, 2].ToArray().Should().Equal(0x00, 0x01);
        }

        [Fact]
        public void WriteUInt16_LittleEndian()
        {
            var octets = new Octets(new Byte[4], true);

            octets.WriteUInt16(2, 1);
            octets.ReadUInt16(2).Should().Be(1);
            octets[2, 2].ToArray().Should().Equal(0x01, 0x00);
        }
    }
}
