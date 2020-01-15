using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.PPPFrameTests
{
    public class PPPFrame_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            PPPFrame.Layout.TypeBegin.Should().Be(0);
            PPPFrame.Layout.TypeEnd.Should().Be(2);

            PPPFrame.Layout.HeaderLength.Should().Be(2);
        }
    }
}
