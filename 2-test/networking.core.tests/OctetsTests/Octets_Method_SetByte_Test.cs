using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.OctetsTests
{
    public class Octets_Method_SetByte_Test
    {
        [Fact]
        public void SetByte()
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

            octets.SetByte(0, 0xAB).Should().Be(0xAB);
            octets.SetByte(1, 0xCD).Should().Be(0xCD);
            octets.SetByte(2, 0xEF).Should().Be(0xEF);
        }
    }
}
