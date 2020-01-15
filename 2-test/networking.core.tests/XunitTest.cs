using FluentAssertions;
using Xunit;

namespace Networking.Tests
{
    public class XunitTest
    {
        [Fact]
        public void Run()
        {
            true.Should().BeTrue();
        }
    }
}
