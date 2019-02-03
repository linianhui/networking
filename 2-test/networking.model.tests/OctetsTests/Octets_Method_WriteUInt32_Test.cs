using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Method_WriteUInt32_Test
    {

        [Fact]
        public void WriteUInt32()
        {
            var octets = new Octets
            {
                Bytes = new Byte[8]
            };

            octets.WriteUInt32(0, 1, Endian.Big);
            octets.WriteUInt32(4, 1, Endian.Little);

            octets.ReadUInt32(0, Endian.Big).Should().Be(1);
            octets[0, 4].ToArray().Should().Equal(0x00, 0x00, 0x00, 0x01);

            octets.ReadUInt32(4, Endian.Little).Should().Be(1);
            octets[4, 4].ToArray().Should().Equal(0x01, 0x00, 0x00, 0x00);
        }
    }
}
