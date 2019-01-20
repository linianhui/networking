using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class OctetsTest
    {
        [Fact]
        public void read()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] { 0x12, 0x34, 0x56 }
            };

            octets[0, 1].ToArray().Should().Equal(0x12);
            octets[0, 2].ToArray().Should().Equal(0x12, 0x34);
            octets[1, 2].ToArray().Should().Equal(0x34, 0x56);
        }

        [Fact]
        public void read_out_of_range_should_throw_ArgumentOutOfRangeException()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] { 0x12 }
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => octets[1, 3]);
        }

        [Fact]
        public void write()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] { 0x12, 0x34, 0x56 }
            };

            octets[0, 1] = new Byte[] { 0xAB };
            octets[0, 1].ToArray().Should().Equal(0xAB);

            octets[0, 2] = new Byte[] { 0xCD, 0xEF };
            octets[0, 1].ToArray().Should().Equal(0xCD);
            octets[0, 2].ToArray().Should().Equal(0xCD, 0xEF);
        }

        [Fact]
        public void write_part()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] { 0x12, 0x34, 0x56 }
            };

            octets[0, 2] = new Byte[] { 0xFF };
            octets.Bytes.ToArray().Should().Equal(0xFF, 0x34, 0x56);
        }

        [Fact]
        public void write_out_of_target_range_should_throw_ArgumentException()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] { 0x12, 0x34, 0x56 }
            };

            Assert.Throws<ArgumentException>(() => octets[0, 1] = new Byte[] { 0xCD, 0xEF });
        }

        [Fact]
        public void ReadAsUInt16FromBigEndian()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] { 0x08, 0x00, 0x08, 0x06 }
            };

            octets.ReadAsUInt16FromBigEndian(0).Should().Be(2048);
            octets.ReadAsUInt16FromBigEndian(2).Should().Be(2054);
        }
    }
}
