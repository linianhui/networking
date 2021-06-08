using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.OctetsTests
{
    public class Octets_Method_GetBytes_Index_Test
    {
        [Fact]
        public void GetBytes()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] { 0x12, 0x34, 0x56 }
            };

            octets.GetBytes(0).ToArray().Should().Equal(0x12, 0x34, 0x56);
            octets.GetBytes(1).ToArray().Should().Equal(0x34, 0x56);
            octets.GetBytes(2).ToArray().Should().Equal(0x56);
            octets.GetBytes(3).Length.Should().Be(0);
            octets.GetBytes(4).Length.Should().Be(0);
        }
    }
}
