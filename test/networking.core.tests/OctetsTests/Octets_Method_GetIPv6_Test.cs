using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.OctetsTests
{
    public class Octets_Method_GetIPv6_Test
    {

        [Fact]
        public void GetIPv6()
        {
            var octets = new Octets
            {
                Bytes = new Byte[]
                {
                    0x00,
                    0xff, 0x02, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x02,
                    0x00
                }
            };

            octets.GetIPv6(1).ToString().Should().Be("FF:02:00:00:00:00:00:00:00:00:00:00:00:00:00:02");
        }
    }
}
