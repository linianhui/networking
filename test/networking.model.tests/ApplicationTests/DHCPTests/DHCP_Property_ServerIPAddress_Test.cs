using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DHCPTests
{
    public class DHCP_Property_ServerIPAddress_Test
    {
        [Fact]
        public void Get()
        {
            var dhcp = new DHCP
            {
                Bytes = new Byte[32]
            };
            dhcp.SetByte(20, 192);
            dhcp.SetByte(21, 168);
            dhcp.SetByte(22, 0);
            dhcp.SetByte(23, 1);

            dhcp.ServerIPAddress.ToString().Should().Be("192.168.0.1");
        }

        [Fact]
        public void Set()
        {
            var dhcp = new DHCP
            {
                Bytes = new Byte[32]
            };

            dhcp.ServerIPAddress = new IPAddress
            {
                Bytes = new Byte[]
                {
                    192, 168, 0, 1
                }
            };

            dhcp.ServerIPAddress.ToString().Should().Be("192.168.0.1");
            dhcp.GetByte(20).Should().Be(192);
            dhcp.GetByte(21).Should().Be(168);
            dhcp.GetByte(22).Should().Be(0);
            dhcp.GetByte(23).Should().Be(1);
        }
    }
}
