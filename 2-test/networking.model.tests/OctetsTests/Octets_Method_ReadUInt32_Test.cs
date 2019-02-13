using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Method_ReadUInt32_Test
    {

        [Fact]
        public void ReadUInt32()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] {
                    0x01, 0x23, 0x45, 0x67,
                    0x89, 0xAB, 0xCD, 0xEF
                }
            };

            octets.ReadUInt32(0).Should().Be(19088743);
            octets.ReadUInt32(4).Should().Be(2309737967);

            octets.IsLittleEndian = true;
            octets.ReadUInt32(0).Should().Be(1732584193);
            octets.ReadUInt32(4).Should().Be(4023233417);
        }
    }
}
