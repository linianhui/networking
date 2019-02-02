using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Method_ReadAsUInt16FromLittleEndian_Test
    {

        [Fact]
        public void ReadAsUInt16FromLittleEndian()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] {
                    0x08, 0x00,
                    0x08, 0x06
                }
            };

            octets.ReadAsUInt16FromLittleEndian(0).Should().Be(8);
            octets.ReadAsUInt16FromLittleEndian(2).Should().Be(1544);
        }
    }
}
