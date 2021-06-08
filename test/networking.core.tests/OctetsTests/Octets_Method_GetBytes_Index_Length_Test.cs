using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.OctetsTests
{
    public class Octets_Method_GetBytes_Index_Length_Test
    {
        [Fact]
        public void GetBytes()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] { 0x12, 0x34, 0x56 }
            };

            octets.GetBytes(0, 1).ToArray().Should().Equal(0x12);
            octets.GetBytes(0, 2).ToArray().Should().Equal(0x12, 0x34);
            octets.GetBytes(1, 2).ToArray().Should().Equal(0x34, 0x56);
        }

        [Fact]
        public void GetBytes_out_of_range_should_return_empty()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] { 0x12 }
            };

            octets.GetBytes(1, 3).ToArray().Should().Equal(0x00, 0x00, 0x00);
        }
    }
}
