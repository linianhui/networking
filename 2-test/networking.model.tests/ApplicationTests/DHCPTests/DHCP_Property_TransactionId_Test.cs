using System;
using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DHCPTests
{
    public class DHCP_Property_TransactionId_Test
    {
        [Fact]
        public void Get()
        {
            var dhcp = new DHCP
            {
                Bytes = new Byte[32]
            };
            dhcp.SetByte(4, 0x12);
            dhcp.SetByte(5, 0x34);
            dhcp.SetByte(6, 0x56);
            dhcp.SetByte(7, 0x78);

            dhcp.TransactionId.Should().Be(0x12345678);
        }

        [Fact]
        public void Set()
        {
            var dhcp = new DHCP
            {
                Bytes = new Byte[32]
            };

            dhcp.TransactionId = 0x12345678;

            dhcp.TransactionId.Should().Be(0x12345678);
            dhcp.GetByte(4).Should().Be(0x12);
            dhcp.GetByte(5).Should().Be(0x34);
            dhcp.GetByte(6).Should().Be(0x56);
            dhcp.GetByte(7).Should().Be(0x78);
        }
    }
}
