using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.OctetsTests
{
    public class Octets_Property_Bytes_Test
    {
        [Fact]
        public void Bytes()
        {
            var octets = new Octets
            {
                Bytes = new Byte[] { 0x12, 0x34, 0x56 }
            };


            octets.Bytes.ToArray().Should().Equal(0x12, 0x34, 0x56);
        }

        [Fact]
        public void Bytes_IsEmpty()
        {
            new Octets().Bytes.IsEmpty.Should().Be(true);
        }
    }
}
