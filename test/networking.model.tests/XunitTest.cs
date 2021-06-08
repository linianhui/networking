using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests
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
