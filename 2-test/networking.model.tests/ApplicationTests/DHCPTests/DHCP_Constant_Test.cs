using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DHCPTests
{
    public class DHCP_Constant_Test
    {
        [Fact]
        public void Constant()
        {
            DHCP.ClientPort.Should().Be(68);
            DHCP.ServerPort.Should().Be(67);
        }
    }
}
