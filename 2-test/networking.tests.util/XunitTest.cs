using FluentAssertions;
using Xunit;

namespace Networking
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
