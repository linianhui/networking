using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.OctetsTests
{
    public class Octets_Method_SetIPv4_Test
    {

        [Fact]
        public void SetIPv4()
        {
            var octets = new Octets
            {
                Bytes = new Byte[6]
            };

            octets.SetIPv4(1, new IPAddress
            {
                Bytes = new Byte[] { 0xC0, 0xA8, 0x01, 0x02 }
            });

            octets.Bytes.ToArray().Should().Equal(0x00, 0xC0, 0xA8, 0x01, 0x02, 0x00);
        }
    }
}
