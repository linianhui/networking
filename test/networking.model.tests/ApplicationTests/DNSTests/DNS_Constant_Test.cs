using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.DNSTests
{
    public class DNS_Constant_Test
    {
        [Fact]
        public void Constant()
        {
            DNS.ServerPort.Should().Be(53);
        }
    }
}
