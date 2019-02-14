using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
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
            octets.GetByte(0).Should().Be(0x12);
            octets.GetByte(1).Should().Be(0x34);
            octets.GetByte(2).Should().Be(0x56);


            octets.SetByte(0, 0xAB);
            octets.SetByte(1, 0xCD);
            octets.SetByte(2, 0xEF);


            octets.GetByte(0).Should().Be(0xAB);
            octets.GetByte(1).Should().Be(0xCD);
            octets.GetByte(2).Should().Be(0xEF);
        }
    }
}
