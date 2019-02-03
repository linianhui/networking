using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Method_ReadUInt16BigEndian_Test
    {

        [Fact]
        public void ReadUInt16BigEndian()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] {
                    0x08, 0x00,
                    0x08, 0x06
                }
            };

            octets.ReadUInt16BigEndian(0).Should().Be(2048);
            octets.ReadUInt16BigEndian(2).Should().Be(2054);
        }
    }
}
