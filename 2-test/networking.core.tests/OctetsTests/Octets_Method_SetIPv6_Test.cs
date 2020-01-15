using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.OctetsTests
{
    public class Octets_Method_SetIPv6_Test
    {

        [Fact]
        public void SetIPv6()
        {
            var octets = new Octets
            {
                Bytes = new Byte[18]
            };

            octets.SetIPv6(1, new IPAddress
            {
                Bytes = new Byte[]
                {
                    0xfe, 0x80, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00,
                    0x02, 0x15, 0x5d, 0xff,
                    0xfe, 0x02, 0x02, 0x45
                }
            });

            octets.Bytes.ToArray().Should().Equal(
                0x00,
                0xfe, 0x80, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00,
                0x02, 0x15, 0x5d, 0xff,
                0xfe, 0x02, 0x02, 0x45,
                0x00
            );
        }
    }
}
