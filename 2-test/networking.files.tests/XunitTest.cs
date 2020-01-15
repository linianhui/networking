using FluentAssertions;
using Xunit;

namespace Networking.Files.Tests
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
