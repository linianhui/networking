using System;
using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPAddressTests
{
    public class IPAddress_Method_ToString_Test
    {
        [Fact]
        public void ToString_Test()
        {
            var ipAddress = new IPAddress
            {
                Bytes = new Byte[] { 0xC0, 0xA8, 0x01, 0x01 }
            };

            ipAddress.ToString().Should().Be("192.168.1.1");

            ipAddress[3] = 0xAB;
            ipAddress.ToString().Should().Be("192.168.1.171");
        }
    }
}
