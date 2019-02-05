using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Method_Slice_Index_Test
    {
        [Fact]
        public void Slice()
        {
            var octets = new Octets
            (
                new Byte[] { 0x12, 0x34, 0x56 }
            );

            octets.Slice(0).ToArray().Should().Equal(0x12, 0x34, 0x56);
            octets.Slice(1).ToArray().Should().Equal(0x34, 0x56);
            octets.Slice(2).ToArray().Should().Equal(0x56);
        }
    }
}
