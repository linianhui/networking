using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DHCPTests
{
    public class DHCP_Property_Flags_Test
    {
        [Fact]
        public void Get()
        {
            var dhcp = new DHCP
            {
                Bytes = new Byte[32]
            };
            dhcp.SetByte(10, 0xAB);
            dhcp.SetByte(11, 0xCD);

            dhcp.Flags.Should().Be(0xABCD);
        }

        [Fact]
        public void Set()
        {
            var dhcp = new DHCP
            {
                Bytes = new Byte[32]
            };

            dhcp.Flags = 0xCDEF;

            dhcp.Flags.Should().Be(0xCDEF);
            dhcp.GetByte(10).Should().Be(0xCD);
            dhcp.GetByte(11).Should().Be(0xEF);
        }
    }
}
