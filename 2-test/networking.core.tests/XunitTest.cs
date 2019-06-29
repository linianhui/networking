using FluentAssertions;
using Xunit;

namespace Networking.Core.Tests
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
