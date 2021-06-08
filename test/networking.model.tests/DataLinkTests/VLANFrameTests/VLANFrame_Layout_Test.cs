using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.VLANFrameTests
{
    public class VLANFrame_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            VLANFrame.Layout.PCPBegin.Should().Be(0);
            VLANFrame.Layout.PCPBitIndex.Should().Be(0);
            VLANFrame.Layout.PCPBitLength.Should().Be(3);

            VLANFrame.Layout.DEIBegin.Should().Be(0);
            VLANFrame.Layout.DEIBitIndex.Should().Be(3);

            VLANFrame.Layout.VIDBegin.Should().Be(0);
            VLANFrame.Layout.VIDBitIndex.Should().Be(4);
            VLANFrame.Layout.VIDBitLength.Should().Be(12);

            VLANFrame.Layout.TypeBegin.Should().Be(2);
            VLANFrame.Layout.TypeEnd.Should().Be(4);

            VLANFrame.Layout.HeaderLength.Should().Be(4);
        }
    }
}
