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

            octets.WriteUInt32(0, 1);
            octets.ReadUInt32(0).Should().Be(1);
            octets[0, 4].ToArray().Should().Equal(0x00, 0x00, 0x00, 0x01);

            octets.Endian = Endian.Little;
            octets.WriteUInt32(4, 1);
            octets.ReadUInt32(4).Should().Be(1);
            octets[4, 4].ToArray().Should().Equal(0x01, 0x00, 0x00, 0x00);
        }
    }
}
