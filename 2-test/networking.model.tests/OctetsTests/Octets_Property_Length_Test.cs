using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Property_Length_Test
    {
        [Fact]
        public void Length()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] { 0x12, 0x34, 0x56 }
            };


            octets.Length.Should().Be(3);
        }
    }
}
