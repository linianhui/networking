using System;
using FluentAssertions;
using Xunit;

namespace Networking.Tests.MACAddressTests
{
    public class MACAddress_Method_ToString_Test
    {
        [Fact]
        public void ToString_Test()
        {
            var macAddress = new MACAddress
            {
                Bytes = new Byte[]
                {
                    0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC
                }
            };

            macAddress.ToString().Should().Be("12:34:56:78:9A:BC");

            macAddress.SetByte(0, 0xFF);
            macAddress.ToString().Should().Be("FF:34:56:78:9A:BC");
        }
    }
}
