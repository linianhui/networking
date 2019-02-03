using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Method_ReadUInt16_Test
    {

        [Fact]
        public void ReadUInt16()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] {
                    0x01, 0x00,
                    0x00, 0x01
                }
            };

            octets.ReadUInt16(0, Endian.Big).Should().Be(256);
            octets.ReadUInt16(0, Endian.Little).Should().Be(1);

            octets.ReadUInt16(2, Endian.Big).Should().Be(1);
            octets.ReadUInt16(2, Endian.Little).Should().Be(256);
        }
    }
}
