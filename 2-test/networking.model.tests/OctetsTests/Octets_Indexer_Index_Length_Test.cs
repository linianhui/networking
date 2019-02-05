using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Indexer_Index_Length_Test
    {
        [Fact]
        public void Get()
        {
            var octets = new Octets
            (
                new Byte[] { 0x12, 0x34, 0x56 }
            );

            octets[0, 1].ToArray().Should().Equal(0x12);
            octets[0, 2].ToArray().Should().Equal(0x12, 0x34);
            octets[1, 2].ToArray().Should().Equal(0x34, 0x56);
        }

        [Fact]
        public void Get_out_of_range_should_throw_ArgumentOutOfRangeException()
        {
            var octets = new Octets
            (
                new Byte[] { 0x12 }
            );

            Assert.Throws<ArgumentOutOfRangeException>(() => octets[1, 3]);
        }

        [Fact]
        public void Set()
        {
            var octets = new Octets
            (
                new Byte[] { 0x12, 0x34, 0x56 }
            );

            octets[0, 1] = new Byte[] { 0xAB };
            octets[0, 1].ToArray().Should().Equal(0xAB);

            octets[0, 2] = new Byte[] { 0xCD, 0xEF };
            octets[0, 1].ToArray().Should().Equal(0xCD);
            octets[0, 2].ToArray().Should().Equal(0xCD, 0xEF);
        }

        [Fact]
        public void Set_part()
        {
            var octets = new Octets
            (
                new Byte[] { 0x12, 0x34, 0x56 }
            );

            octets[0, 2] = new Byte[] { 0xFF };
            octets.Bytes.ToArray().Should().Equal(0xFF, 0x34, 0x56);
        }

        [Fact]
        public void Set_out_of_target_range_should_throw_ArgumentException()
        {
            var octets = new Octets
            (
                new Byte[] { 0x12, 0x34, 0x56 }
            );

            Assert.Throws<ArgumentException>(() => octets[0, 1] = new Byte[] { 0xCD, 0xEF });
        }
    }
}
