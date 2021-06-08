using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DHCPTests
{
    public class DHCP_Property_Seconds_Test
    {
        [Fact]
        public void Get()
        {
            var dhcp = new DHCP
            {
                Bytes = new Byte[32]
            };
            dhcp.SetByte(8, 0xAB);
            dhcp.SetByte(9, 0xCD);

            dhcp.Seconds.Should().Be(0xABCD);
        }

        [Fact]
        public void Set()
        {
            var dhcp = new DHCP
            {
                Bytes = new Byte[32]
            };

            dhcp.Seconds = 0xCDEF;

            dhcp.Seconds.Should().Be(0xCDEF);
            dhcp.GetByte(8).Should().Be(0xCD);
            dhcp.GetByte(9).Should().Be(0xEF);
        }
    }
}
