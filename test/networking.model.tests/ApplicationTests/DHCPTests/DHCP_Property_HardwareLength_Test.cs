using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DHCPTests
{
    public class DHCP_Property_HardwareLength_Test
    {
        [Fact]
        public void Get()
        {
            var dhcp = new DHCP
            {
                Bytes = new Byte[32]
            };
            dhcp.SetByte(2, 6);

            dhcp.HardwareLength.Should().Be(6);
        }

        [Fact]
        public void Set()
        {
            var dhcp = new DHCP
            {
                Bytes = new Byte[32]
            };

            dhcp.HardwareLength = 6;

            dhcp.HardwareLength.Should().Be(6);
            dhcp.GetByte(2).Should().Be(6);
        }
    }
}
