using System;
using FluentAssertions;
using Xunit;
using Networking.Model;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Property_Endian_Test
    {
        [Fact]
        public void BigEndian()
        {
            var octets = new Octets
            {
                Bytes = new Byte[0]
            };

            octets.Endian.Should().Be(Endian.Big);
        }
    }
}
