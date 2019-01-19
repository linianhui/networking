using FluentAssertions;
using Xunit;

namespace Networking.Model.Test
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
