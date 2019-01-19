using FluentAssertions;
using Xunit;

namespace Networking.Model.DataLink
{
    public class MACAddressLayoutTest
    {
        [Fact]
        public void layout_is_right()
        {
            MACAddress.Layout.Length.Should().Be(6);
        }
    }
}
