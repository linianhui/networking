using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Method_WriteUInt16BigEndian_Test
    {

        [Fact]
        public void WriteUInt16BigEndian()
        {
            var octets = new Octets
            {
                Bytes = new Byte[4]
            };

            octets.WriteUInt16BigEndian(0, 2048);
            octets.WriteUInt16BigEndian(2, 2054);

            octets.ReadUInt16BigEndian(0).Should().Be(2048);
            octets.ReadUInt16BigEndian(2).Should().Be(2054);
        }
    }
}
