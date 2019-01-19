using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Test.DataLink
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
