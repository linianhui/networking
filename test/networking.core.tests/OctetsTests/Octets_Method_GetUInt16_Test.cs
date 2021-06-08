using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.OctetsTests
{
    public class Octets_Method_GetUInt16_Test
    {

        [Fact]
        public void GetUInt16()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] {
                    0x01, 0x00,
                    0x00, 0x01
                }
            };

            octets.GetUInt16(0).Should().Be(256);
            octets.GetUInt16(2).Should().Be(1);

            octets.IsLittleEndian = true;
            octets.GetUInt16(0).Should().Be(1);
            octets.GetUInt16(2).Should().Be(256);
        }
    }
}
