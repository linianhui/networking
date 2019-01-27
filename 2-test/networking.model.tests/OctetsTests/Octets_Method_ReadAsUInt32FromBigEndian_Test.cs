using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Method_ReadAsUInt32FromBigEndian_Test
    {

        [Fact]
        public void ReadAsUInt32FromBigEndian()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] {
                    0x01, 0x23, 0x45, 0x67,
                    0x89, 0xAB, 0xCD, 0xEF
                }
            };

            octets.ReadAsUInt32FromBigEndian(0).Should().Be(19088743);
            octets.ReadAsUInt32FromBigEndian(4).Should().Be(2309737967);
        }
    }
}
