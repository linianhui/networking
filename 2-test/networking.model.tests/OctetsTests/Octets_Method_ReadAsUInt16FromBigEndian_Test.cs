using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Method_ReadAsUInt16FromBigEndian_Test
    {

        [Fact]
        public void ReadAsUInt16FromBigEndian()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] {
                    0x08, 0x00,
                    0x08, 0x06
                }
            };

            octets.ReadAsUInt16FromBigEndian(0).Should().Be(2048);
            octets.ReadAsUInt16FromBigEndian(2).Should().Be(2054);
        }
    }
}
