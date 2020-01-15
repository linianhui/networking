using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.IPAddressTests
{
    public class IPAddress_Method_ToString_Test
    {
        [Fact]
        public void IPv4_ToString_Test()
        {
            var ipAddress = new IPAddress
            {
                Bytes = new Byte[] { 0xC0, 0xA8, 0x01, 0x01 }
            };

            ipAddress.ToString().Should().Be("192.168.1.1");

            ipAddress.SetByte(3, 0xAB);
            ipAddress.ToString().Should().Be("192.168.1.171");
        }

        [Fact]
        public void IPv6_ToString_Test()
        {
            var ipAddress = new IPAddress
            {
                Bytes = new Byte[]
                {
                    0xC0, 0xA8, 0x01, 0x01,
                    0xC0, 0xA8, 0x01, 0x01,
                    0xC0, 0xA8, 0x01, 0x01,
                    0xC0, 0xA8, 0x01, 0x01
                }
            };

            ipAddress.ToString().Should().Be("C0:A8:01:01:C0:A8:01:01:C0:A8:01:01:C0:A8:01:01");
        }
    }
}
