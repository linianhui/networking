using FluentAssertions;
using Xunit;

namespace Networking.Tests.IPVersionTests
{
    public class IPVersion_Test
    {
        [Fact]
        public void version()
        {
            IPVersion.IPv4.Should().Be(4);
            IPVersion.IPv6.Should().Be(6);
        }
    }
}
