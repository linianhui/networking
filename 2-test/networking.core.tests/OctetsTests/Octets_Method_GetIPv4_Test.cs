using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.OctetsTests
{
    public class Octets_Method_GetIPv4_Test
    {

        [Fact]
        public void GetIPv4()
        {
            var octets = new Octets
            {
                Bytes = new Byte[]
                {
                    0x00, 0xC0, 0xA8, 0x01, 0x02, 0x00
                }
            };

            octets.GetIPv4(1).ToString().Should().Be("192.168.1.2");
        }
    }
}
