using FluentAssertions;
using Xunit;

namespace Networking.Model
{
    public class XunitTest
    {
        [Fact]
        public void is_true()
        {
            true.Should().BeTrue();
        }
    }
}
