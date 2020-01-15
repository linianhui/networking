using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DHCPTests
{
    public class DHCP_Property_ClientIPAddress_Test
    {
        [Fact]
        public void Get()
        {
            var dhcp = new DHCP
            {
                Bytes = new Byte[32]
            };
            dhcp.SetByte(12, 192);
            dhcp.SetByte(13, 168);
            dhcp.SetByte(14, 0);
            dhcp.SetByte(15, 1);

            dhcp.ClientIPAddress.ToString().Should().Be("192.168.0.1");
        }

        [Fact]
        public void Set()
        {
            var dhcp = new DHCP
            {
                Bytes = new Byte[32]
            };

            dhcp.ClientIPAddress = new IPAddress
            {
                Bytes = new Byte[]
                {
                    192, 168, 0, 1
                }
            };

            dhcp.ClientIPAddress.ToString().Should().Be("192.168.0.1");
            dhcp.GetByte(12).Should().Be(192);
            dhcp.GetByte(13).Should().Be(168);
            dhcp.GetByte(14).Should().Be(0);
            dhcp.GetByte(15).Should().Be(1);
        }
    }
}
