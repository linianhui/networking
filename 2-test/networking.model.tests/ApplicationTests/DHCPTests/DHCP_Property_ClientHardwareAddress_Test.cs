using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DHCPTests
{
    public class DHCP_Property_ClientHardwareAddress_Test
    {
        [Fact]
        public void Get()
        {
            var dhcp = new DHCP
            {
                Bytes = new Byte[64]
            };
            dhcp.SetByte(28, 0x12);
            dhcp.SetByte(29, 0x34);
            dhcp.SetByte(30, 0x56);
            dhcp.SetByte(31, 0x78);
            dhcp.SetByte(32, 0x9A);
            dhcp.SetByte(33, 0xBC);

            dhcp.ClientHardwareAddress.ToString().Should().Be("12:34:56:78:9A:BC");
        }

        [Fact]
        public void Set()
        {
            var dhcp = new DHCP
            {
                Bytes = new Byte[64]
            };

            dhcp.ClientHardwareAddress = new MACAddress
            {
                Bytes = new Byte[]
                {
                    0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC
                }
            };

            dhcp.ClientHardwareAddress.ToString().Should().Be("12:34:56:78:9A:BC");
            dhcp.GetByte(28).Should().Be(0x12);
            dhcp.GetByte(29).Should().Be(0x34);
            dhcp.GetByte(30).Should().Be(0x56);
            dhcp.GetByte(31).Should().Be(0x78);
            dhcp.GetByte(32).Should().Be(0x9A);
            dhcp.GetByte(33).Should().Be(0xBC);
        }
    }
}
