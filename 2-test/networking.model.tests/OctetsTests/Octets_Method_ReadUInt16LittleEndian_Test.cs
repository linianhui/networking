using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Method_ReadUInt16LittleEndian_Test
    {

        [Fact]
        public void ReadUInt16LittleEndian()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] {
                    0x08, 0x00,
                    0x08, 0x06
                }
            };

            octets.ReadUInt16LittleEndian(0).Should().Be(8);
            octets.ReadUInt16LittleEndian(2).Should().Be(1544);
        }
    }
}
