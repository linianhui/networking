using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Method_GetByte_Test
    {
        [Fact]
        public void GetByte()
        {
            var octets = new Octets
            {
                Bytes = new Byte[]
                {
                    0x12,
                    0x34,
                    0x56
                }
            };

            octets.GetByte(0).Should().Be(0x12);
            octets.GetByte(1).Should().Be(0x34);
            octets.GetByte(2).Should().Be(0x56);
        }
    }
}
