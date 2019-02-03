using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Method_WriteUInt32BigEndian_Test
    {

        [Fact]
        public void WriteUInt32BigEndian()
        {
            var octets = new Octets
            {
                Bytes = new Byte[8]
            };

            octets.WriteUInt32BigEndian(0, 0x01234567);
            octets.WriteUInt32BigEndian(4, 0x89ABCDEF);

            octets.ReadUInt32BigEndian(0).Should().Be(19088743);
            octets.ReadUInt32BigEndian(4).Should().Be(2309737967);
        }
    }
}
