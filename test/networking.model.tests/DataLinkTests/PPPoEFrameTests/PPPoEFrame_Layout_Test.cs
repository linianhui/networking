using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.PPPoEFrameTests
{
    public class PPPoEFrame_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            PPPoEFrame.Layout.VersionBegin.Should().Be(0);
            PPPoEFrame.Layout.VersionEnd.Should().Be(1);
            PPPoEFrame.Layout.VersionBitIndex.Should().Be(0);
            PPPoEFrame.Layout.VersionBitLength.Should().Be(4);

            PPPoEFrame.Layout.TypeBegin.Should().Be(0);
            PPPoEFrame.Layout.TypeEnd.Should().Be(1);
            PPPoEFrame.Layout.TypeBitIndex.Should().Be(4);
            PPPoEFrame.Layout.TypeBitLength.Should().Be(4);

            PPPoEFrame.Layout.CodeBegin.Should().Be(1);
            PPPoEFrame.Layout.CodeEnd.Should().Be(2);

            PPPoEFrame.Layout.SessionIdBegin.Should().Be(2);
            PPPoEFrame.Layout.SessionIdEnd.Should().Be(4);

            PPPoEFrame.Layout.PayloadLengthBegin.Should().Be(4);
            PPPoEFrame.Layout.PayloadLengthEnd.Should().Be(6);

            PPPoEFrame.Layout.HeaderLength.Should().Be(6);
        }
    }
}
