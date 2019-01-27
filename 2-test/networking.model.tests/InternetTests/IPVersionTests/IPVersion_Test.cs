using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Tests.InternetTests.IPVersionTests
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
