using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DHCPTests
{
    public class DHCP_Property_GatewayIPAddress_Test
    {
        [Fact]
        public void Get()
        {
            var dhcp = new DHCP
            {
                Bytes = new Byte[32]
            };
            dhcp.SetByte(24, 192);
            dhcp.SetByte(25, 168);
            dhcp.SetByte(26, 0);
            dhcp.SetByte(27, 1);

            dhcp.GatewayIPAddress.ToString().Should().Be("192.168.0.1");
        }

        [Fact]
        public void Set()
        {
            var dhcp = new DHCP
            {
                Bytes = new Byte[32]
            };

            dhcp.GatewayIPAddress = new IPAddress
            {
                Bytes = new Byte[]
                {
                    192, 168, 0, 1
                }
            };

            dhcp.GatewayIPAddress.ToString().Should().Be("192.168.0.1");
            dhcp.GetByte(24).Should().Be(192);
            dhcp.GetByte(25).Should().Be(168);
            dhcp.GetByte(26).Should().Be(0);
            dhcp.GetByte(27).Should().Be(1);
        }
    }
}
