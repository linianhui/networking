using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DHCPTests
{
    public class DHCP_Property_YourClientIPAddress_Test
    {
        [Fact]
        public void Get()
        {
            var dhcp = new DHCP
            {
                Bytes = new Byte[32]
            };
            dhcp.SetByte(16, 192);
            dhcp.SetByte(17, 168);
            dhcp.SetByte(18, 0);
            dhcp.SetByte(19, 1);

            dhcp.YourClientIPAddress.ToString().Should().Be("192.168.0.1");
        }

        [Fact]
        public void Set()
        {
            var dhcp = new DHCP
            {
                Bytes = new Byte[32]
            };

            dhcp.YourClientIPAddress = new IPAddress
            {
                Bytes = new Byte[]
                {
                    192, 168, 0, 1
                }
            };

            dhcp.YourClientIPAddress.ToString().Should().Be("192.168.0.1");
            dhcp.GetByte(16).Should().Be(192);
            dhcp.GetByte(17).Should().Be(168);
            dhcp.GetByte(18).Should().Be(0);
            dhcp.GetByte(19).Should().Be(1);
        }
    }
}
