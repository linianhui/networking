using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.OctetsTests
{
    public class Octets_Property_IsLittleEndian_Test
    {
        [Fact]
        public void IsLittleEndian()
        {
            var octets = new Octets
            {
                Bytes = new Byte[0]
            };

            octets.IsLittleEndian.Should().Be(false);
        }
    }
}
