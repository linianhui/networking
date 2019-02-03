using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Method_ReadUInt32LittleEndian_Test
    {

        [Fact]
        public void ReadUInt32LittleEndian()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] {
                    0x01, 0x23, 0x45, 0x67,
                    0x89, 0xAB, 0xCD, 0xEF
                }
            };

            octets.ReadUInt32LittleEndian(0).Should().Be(1732584193);
            octets.ReadUInt32LittleEndian(4).Should().Be(4023233417);
        }
    }
}
