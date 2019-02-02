using FluentAssertions;
using Xunit;

namespace Networking.Utils.Tests
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
