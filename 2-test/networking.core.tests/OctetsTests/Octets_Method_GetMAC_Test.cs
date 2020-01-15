using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.OctetsTests
{
    public class Octets_Method_GetMAC_Test
    {

        [Fact]
        public void GetMAC()
        {
            var octets = new Octets
            {
                Bytes = new Byte[]
                {
                    0x00, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0x00
                }
            };


            octets.GetMAC(1).ToString().Should().Be("12:34:56:78:9A:BC");
        }
    }
}
