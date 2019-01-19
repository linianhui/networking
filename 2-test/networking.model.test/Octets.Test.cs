using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Test
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

            octets.Read(0, 1).ToArray().Should().Equal(0x12);
            octets.Read(0, 2).ToArray().Should().Equal(0x12, 0x34);
            octets.Read(1, 2).ToArray().Should().Equal(0x34, 0x56);
        }

        [Fact]
        public void read_out_of_range_should_throw_ArgumentOutOfRangeException()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] { 0x12 }
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => octets.Read(1, 3));
        }

        [Fact]
        public void write()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] { 0x12, 0x34, 0x56 }
            };

            octets.Write(0, 1, new Byte[] { 0xAB });
            octets.Read(0, 1).ToArray().Should().Equal(0xAB);

            octets.Write(0, 2, new Byte[] { 0xCD, 0xEF });
            octets.Read(0, 1).ToArray().Should().Equal(0xCD);
            octets.Read(0, 2).ToArray().Should().Equal(0xCD, 0xEF);
        }

        [Fact]
        public void write_part()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] { 0x12, 0x34, 0x56 }
            };

            octets.Write(0, 2, new Byte[] { 0xFF });
            octets.Bytes.ToArray().Should().Equal(0xFF, 0x34, 0x56);
        }

        [Fact]
        public void write_out_of_target_range_should_throw_ArgumentException()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] { 0x12, 0x34, 0x56 }
            };

            Assert.Throws<ArgumentException>(() => octets.Write(0, 1, new Byte[] { 0xCD, 0xEF }));
        }
    }
}
