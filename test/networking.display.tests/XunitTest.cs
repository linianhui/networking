using FluentAssertions;
using Xunit;

namespace Networking.Display.Tests
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
