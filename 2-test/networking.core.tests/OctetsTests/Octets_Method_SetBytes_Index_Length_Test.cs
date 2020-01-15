using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.OctetsTests
{
    public class Octets_Method_SetBytes_Index_Length_Test
    {
        [Fact]
        public void SetBytes()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] { 0x12, 0x34, 0x56 }
            };

            octets.SetBytes(0, 1, new Byte[] { 0xAB });
            octets.GetBytes(0, 1).ToArray().Should().Equal(0xAB);

            octets.SetBytes(0, 2, new Byte[] { 0xCD, 0xEF });
            octets.GetBytes(0, 1).ToArray().Should().Equal(0xCD);
            octets.GetBytes(0, 2).ToArray().Should().Equal(0xCD, 0xEF);
        }

        [Fact]
        public void SetBytes_part()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] { 0x12, 0x34, 0x56 }
            };

            octets.SetBytes(0, 2, new Byte[] { 0xFF });
            octets.Bytes.ToArray().Should().Equal(0xFF, 0x34, 0x56);
        }

        [Fact]
        public void SetBytes_out_of_target_range_should_throw_ArgumentException()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] { 0x12, 0x34, 0x56 }
            };

            Assert.Throws<ArgumentException>(() => octets.SetBytes(0, 1, new Byte[] { 0xCD, 0xEF }));
        }
    }
}
