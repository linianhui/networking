using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Method_WriteUInt16ToBigEndian_Test
    {

        [Fact]
        public void WriteUInt16ToBigEndian()
        {
            var octets = new Octets
            {
                Bytes = new Byte[4]
            };

            octets.WriteUInt16ToBigEndian(0, 2048);
            octets.WriteUInt16ToBigEndian(2, 2054);

            octets.ReadAsUInt16FromBigEndian(0).Should().Be(2048);
            octets.ReadAsUInt16FromBigEndian(2).Should().Be(2054);
        }
    }
}
