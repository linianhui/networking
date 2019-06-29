using System;
using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.ExtensionsTests
{
    public class Octets_Method_SetMAC_Test
    {

        [Fact]
        public void SetMAC()
        {
            var octets = new Octets
            {
                Bytes = new Byte[8]
            };

            octets.SetMAC(1, new MACAddress
            {
                Bytes = new Byte[] { 0x21, 0x43, 0x65, 0x87, 0xA9, 0xCB }
            });

            octets.Bytes.ToArray().Should().Equal(0x00, 0x21, 0x43, 0x65, 0x87, 0xA9, 0xCB, 0x00);
        }
    }
}
