using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Method_WriteUInt32ToBigEndian_Test
    {

        [Fact]
        public void WriteUInt32ToBigEndian()
        {
            var octets = new Octets
            {
                Bytes = new Byte[8]
            };

            octets.WriteUInt32ToBigEndian(0, 0x01234567);
            octets.WriteUInt32ToBigEndian(4, 0x89ABCDEF);

            octets.ReadAsUInt32FromBigEndian(0).Should().Be(19088743);
            octets.ReadAsUInt32FromBigEndian(4).Should().Be(2309737967);
        }
    }
}
