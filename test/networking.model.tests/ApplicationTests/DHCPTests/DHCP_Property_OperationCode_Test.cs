using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DHCPTests
{
    public class DHCP_Property_OperationCode_Test
    {
        [Fact]
        public void Get()
        {
            var dhcp = new DHCP
            {
                Bytes = new Byte[32]
            };
            dhcp.SetByte(0, 1);

            dhcp.OperationCode.Should().Be(1);
        }

        [Fact]
        public void Set()
        {
            var dhcp = new DHCP
            {
                Bytes = new Byte[32]
            };

            dhcp.OperationCode = 2;

            dhcp.OperationCode.Should().Be(2);
            dhcp.GetByte(0).Should().Be(2);
        }
    }
}
