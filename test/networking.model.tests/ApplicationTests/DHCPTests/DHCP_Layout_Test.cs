using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DHCPTests
{
    public class DHCP_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            DHCP.Layout.OperationCodeBegin.Should().Be(0);
            DHCP.Layout.OperationCodeEnd.Should().Be(1);

            DHCP.Layout.HardwareTypeBegin.Should().Be(1);
            DHCP.Layout.HardwareTypeEnd.Should().Be(2);

            DHCP.Layout.HardwareLengthBegin.Should().Be(2);
            DHCP.Layout.HardwareLengthEnd.Should().Be(3);

            DHCP.Layout.TransactionIdBegin.Should().Be(4);
            DHCP.Layout.TransactionIdEnd.Should().Be(8);

            DHCP.Layout.SecondsBegin.Should().Be(8);
            DHCP.Layout.SecondsEnd.Should().Be(10);

            DHCP.Layout.FlagsBegin.Should().Be(10);
            DHCP.Layout.FlagsEnd.Should().Be(12);

            DHCP.Layout.ClientIPAddressBegin.Should().Be(12);
            DHCP.Layout.ClientIPAddressEnd.Should().Be(16);

            DHCP.Layout.YourClientIPAddressBegin.Should().Be(16);
            DHCP.Layout.YourClientIPAddressEnd.Should().Be(20);

            DHCP.Layout.ServerIPAddressBegin.Should().Be(20);
            DHCP.Layout.ServerIPAddressEnd.Should().Be(24);

            DHCP.Layout.GatewayIPAddressBegin.Should().Be(24);
            DHCP.Layout.GatewayIPAddressEnd.Should().Be(28);

            DHCP.Layout.ClientHardwareAddressBegin.Should().Be(28);
            DHCP.Layout.ClientHardwareAddressEnd.Should().Be(44);

            DHCP.Layout.ServerHostNameBegin.Should().Be(44);
            DHCP.Layout.ServerHostNameEnd.Should().Be(108);

            DHCP.Layout.BootFileNameBegin.Should().Be(108);
            DHCP.Layout.BootFileNameEnd.Should().Be(236);
        }
    }
}
