using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DHCPTests
{
    public class DHCP_Property_HardwareType_Test
    {
        [Fact]
        public void Get()
        {
            var dhcp = new DHCP
            {
                Bytes = new Byte[32]
            };
            dhcp.SetByte(1, 1);

            dhcp.HardwareType.Should().Be(1);
        }

        [Fact]
        public void Set()
        {
            var dhcp = new DHCP
            {
                Bytes = new Byte[32]
            };

            dhcp.HardwareType = 1;

            dhcp.HardwareType.Should().Be(1);
            dhcp.GetByte(1).Should().Be(1);
        }
    }
}
