using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Method_ReadUInt16_Test
    {

        [Fact]
        public void ReadUInt16_BigEndian()
        {
            var octets = new Octets
            (
                new Byte[] {
                    0x01, 0x00,
                    0x00, 0x01
                }
            );

            octets.ReadUInt16(0).Should().Be(256);
            octets.ReadUInt16(2).Should().Be(1);
        }

        [Fact]
        public void ReadUInt16_LittleEndian()
        {
            var octets = new Octets
            (
                new Byte[] {
                    0x01, 0x00,
                    0x00, 0x01
                },
                true
            );

            octets.ReadUInt16(0).Should().Be(1);
            octets.ReadUInt16(2).Should().Be(256);
        }
    }
}
