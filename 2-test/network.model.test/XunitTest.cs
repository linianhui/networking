using FluentAssertions;
using Xunit;

namespace Network.Model.Test
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
