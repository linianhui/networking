using FluentAssertions;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Model.Test.Internet
{
    public class IPAddressLayoutTest
    {
        [Fact]
        public void layout_is_right()
        {
            IPAddress.Layout.V4Length.Should().Be(4);
            IPAddress.Layout.V6Length.Should().Be(16);
        }
    }
}
